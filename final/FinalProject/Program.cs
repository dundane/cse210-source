using FinalProject.Business;
using FinalProject.Business.Interfaces;
using FinalProject.UI;

class Program {
  private static UIDisplay Display { get; set; }
  private static DeckLibrary Library { get; set; }
  static void Main(string[] args) {
    Display = new UIDisplay();
    Library = new DeckLibrary();
    Console.WriteLine("Welcome to the Magic the Gathering deck Analyzer!!!");
    while (true) {
      Console.WriteLine(Display.FormatMenu());
      String menuEntry = Console.ReadLine();
      HandleMenu(menuEntry);
    }
  }

  public static void HandleMenu(string menuSelection) {

    switch (menuSelection) {
      case "1":
        HandleLoadLibrary();
        break;
      case "2":
        HandleChooseActivity();
        break;
      case "3":
        HandleCreateDeck();
        break;
      case "4":
        HandleFindDeck();
        break;
      case "5":
        HandleDisplayDeck();
        break;
      case "6":
        HandleSaveLibrary();
        break;
      case "7":
        Console.WriteLine("Exiting Application");
        Environment.Exit(0);
        break;
      default:
        Console.WriteLine("Invalid Selection please try again.");
        break;
    }

  }

  private static void HandleSaveLibrary() {
    IFileIo fileIo = new DeckLibraryXmlFileIo();
    Console.WriteLine("Please enter the file path where you want to save your deck library path or press enter to choose default. (Data\\decklist.xml)");
    String savePath = Console.ReadLine();
    if (String.IsNullOrEmpty(savePath)) {
      savePath = "Data\\decklist.xml";
    }
    fileIo.Save<DeckLibrary>(Library, savePath);
  }

  private static void HandleFindDeck() {
    bool validIndex = false;
    while (!validIndex) {
      Console.WriteLine("Select the deck you want to make your active deck.");
      Console.WriteLine(Library.FormatDeckListForDisplay());
      String deckIndexEntry = Console.ReadLine();
      int deckIndex = 0;
      validIndex = Int32.TryParse(deckIndexEntry, out deckIndex);

      if (validIndex) {
        validIndex = deckIndex - 1 < Library.Decks.Count;
        if (validIndex) {
          Library.ActivateDeck(deckIndex - 1);
        }
      }
      if (!validIndex) {
        Console.WriteLine("Invalid deck number selected");
      }
    }
  }


  private static void HandleDisplayDeck() {
    Console.WriteLine(Library.ActiveDeck.FormatDeckListForDisplay());
  }

  private static void HandleCreateDeck() {
    Deck deck = new Deck();
    Console.WriteLine(Display.CreateDeckInstructions());
    Console.WriteLine("");
    Console.WriteLine("Create a name for your deck.");
    deck.Name = Console.ReadLine();
    CommanderCard commander = HandleFindCommander();
    if (commander == null) {
      return;
    } else {
      deck.Commander = commander;
    }
    Boolean continueDeckBuilding = true;
    while (continueDeckBuilding) {
      Card cardToAdd = HandleFindCard(deck.GetColorIdentityString());
      if (cardToAdd == null) {
        continueDeckBuilding = false;
      } else {
        deck.AddCard(cardToAdd);
      }
    }
    Library.AddDeck(deck);
    
  }

  private static CommanderCard HandleFindCommander() {
    bool validCommander = false;
    CommanderCard commander = null;
    ScryfallApi api = new ScryfallApi();
    while (!validCommander) {
      Console.WriteLine("Enter the name of the commander you wish to add to your deck.");
      String commanderName = Console.ReadLine();
      if (commanderName == "123") {
        return null;
      }
      commander = api.FindCommanderCard(commanderName);
      if (commander != null) {
        Console.WriteLine($"The commander we found is {commander.Name} is this correct (Y/N)");
        String successRespone = Console.ReadLine();
        if (successRespone.ToUpper().StartsWith("Y")) {
          validCommander = commander.IsLegalCommander();
          if (validCommander) {
            Console.WriteLine($"Great adding {commander.Name} as your commander.");
          } else {
            Console.WriteLine($"We are sorry {commander.Name} is not a valid commander.");
          }
        } else {
          Console.WriteLine("We are sorry please search again with a more specific commander name.");
        }
      } else {
        Console.WriteLine($"We are sorry we could not find a commander with the name {commanderName}.");
        Console.WriteLine($"Please search again with a more specific commander name.");
      }
    }
    return commander;
  }

  private static Card HandleFindCard(string colorIdentity = "WUBRG") {
    bool validCard = false;
    Card card = null;
    ScryfallApi api = new ScryfallApi();
    while (!validCard) {
      Console.WriteLine("Enter the name of the card you wish to add to your deck.");
      String cardName = Console.ReadLine();
      if (cardName == "123") {
        return null;
      }
      card = api.FindCommanderCard(cardName);
      if (card != null) {
        Console.WriteLine($"The card we found is {card.Name} is this correct (Y/N)");
        String successRespone = Console.ReadLine();
        if (successRespone.ToUpper().StartsWith("Y")) {
          validCard = card.IsInColorIdentity(colorIdentity) && card.Legalities.CommanderLegal;
          if (validCard) {
            Console.WriteLine($"Great adding {card.Name} to your deck.");
          } else {
            Console.WriteLine($"We are sorry {card.Name} is not a valid card in this deck.");
            Console.WriteLine($"The color identity of your deck is {colorIdentity}");
          }
        } else {
          Console.WriteLine("We are sorry please search again with a more specific card name.");
        }
      } else {
        Console.WriteLine($"We are sorry we could not find a card with the name {cardName}.");
        Console.WriteLine($"Please search again with a more specific card name.");
      }
    }
    return card;

  }

  private static void HandleChooseActivity() {
    String enteredValue = String.Empty;
    bool validSelection = false;
    Activity activityToPerform = null;
    while (!validSelection) {
      Console.WriteLine("Select the activity to perform on the current deck");
      Console.WriteLine(Display.FormatActivityTypeMenu());
      String selection = Console.ReadLine();


      switch (selection) {
        case "1":
          activityToPerform = new ManaCurveActivity(Library.ActiveDeck);
          validSelection = true;
          break;
        case "2":
          activityToPerform = new CardCompareActivity(Library.ActiveDeck);
          validSelection = true;
          break;
        case "123":
          validSelection = true;
          return;
        default:
          Console.WriteLine("Invalid selection please select another value");
          break;
      }
    }

    while(enteredValue != "123" && activityToPerform != null) {
      Console.WriteLine(activityToPerform.ActivityDescription());
      Console.WriteLine(activityToPerform.RunActivity());
      Console.WriteLine("Press Enter to run activity again or enter 123 to exit actiivty.");
      enteredValue = Console.ReadLine();
    }
  }

  private static void HandleLoadLibrary() {
    String loadPath = string.Empty;
    IFileIo fileIo = new DeckLibraryXmlFileIo();
    while (!File.Exists(loadPath)) {
      loadPath = string.Empty;
      Console.WriteLine("Please enter the file path of the deck list xml you wish to load or press enter to choose default. (Data\\decklist.xml)");
      loadPath = Console.ReadLine();
      if (String.IsNullOrEmpty(loadPath)) {
        loadPath = "Data\\decklist.xml";
      }
      if (File.Exists(loadPath)) {
        Library = fileIo.Load<DeckLibrary>(loadPath);
      } else {
        Console.WriteLine($"File {loadPath} does not exist.");
      }
    }
  }
}