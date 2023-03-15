using Develop03;
using System.ComponentModel.Design;
using System.Security.Cryptography;

class Program {

  private static DisplayUI ui = null;
  static void Main(string[] args) {
    ui = new DisplayUI();
    Library currentLibrary = null;
    String currentSelection = "";
    while (currentSelection != "6") {
      Console.WriteLine("Please select an option.");
      Console.Write(ui.FormatMenu());
      currentSelection = Console.ReadLine();
      currentLibrary = ProcessMenu(currentSelection, currentLibrary);
    }


  }

  private static Library ProcessMenu(string currentSelection, Library currentLibrary) {
    switch (currentSelection) {
      case "1":
        return ProcessLoadScriptures();
      case "2":
        return ProcessDisplayScripturesList(currentLibrary);
      case "3":
        return ProcessAddNewScripture(currentLibrary);
      case "4":
      SelectVerseToMemorize(currentLibrary);
        return ProcessMemorization(currentLibrary);
      case "5":
        return ProcessSaveScriptures(currentLibrary);
      case "6":
        return currentLibrary;
      default:
        Console.WriteLine("Invalid selection please select from the menu items (1-6)");
        return currentLibrary;
    }
  }

  private static Library ProcessLoadScriptures() {
    string scripturePath = "scriptures.xml";
    Console.WriteLine("Enter the path of the library xml file you wish to load (or press enter for default)");
    string submittedScripturePath = Console.ReadLine();
    if (File.Exists(submittedScripturePath)) {
      scripturePath = submittedScripturePath;
    } else {
      Console.WriteLine("Unable to find specified file loading the default file.");
    }
    return Library.LoadScriptures(scripturePath);
  }

  private static Library ProcessDisplayScripturesList(Library currentLibrary) {
    int scriptureIndex = 0;
    foreach (Scripture scripture in currentLibrary.Scriptures) {
      Console.WriteLine($"{scriptureIndex + 1}, {scripture.FormatRefrenceForDisplay()}");
      scriptureIndex++;
    }
    return currentLibrary;
  }

  private static Library ProcessAddNewScripture(Library currentLibrary) {
    Library library;
    Scripture newScripture = new Scripture();
    if (currentLibrary == null) {
      library = new Library();
    } else {
      library = currentLibrary;
    }
    bool endEntry = false;
    Console.WriteLine("Create a new scripture to memorize");
    Console.WriteLine("Through this process you will add individual verses to a scripture.");
    Console.WriteLine("We will ask for individual verse information until you tell use to end.");
    int verseCount = 1;
    while (!endEntry) {
      Console.WriteLine("Enter the full text of the verse without the verse number.");
      Console.WriteLine($"Starting Verse {verseCount}.");
      if (verseCount > 1) {
        Console.WriteLine("Or type end if you have no more verses to add to this scripture");
      }
      string originalText = Console.ReadLine();
      if (originalText.ToLower().Trim() == "end") {
        library.AddScripture(newScripture);
        return library;
      }
      Console.WriteLine("Please enter the book (ie, Acts, 1 Nephi) for this verse");
      string verseBook = Console.ReadLine();
      Console.WriteLine("Please enter the Chapter or Section for this verse");
      string verseChapter = Console.ReadLine();
      Console.WriteLine("Please enter the verse number for this verse");
      string verseNumber = Console.ReadLine();
      int verseNumberInteger = 0;
      int.TryParse(verseNumber, out verseNumberInteger);

      newScripture.AddVerse(verseBook, verseChapter, verseNumberInteger, originalText);
      verseCount++;
    }

    return library;
  }

  private static Library SelectVerseToMemorize(Library currentLibrary) {
    bool validSelection = false;
    int scriptureIndex = -1;
    while (!validSelection) {

      ProcessDisplayScripturesList(currentLibrary);
      Console.WriteLine($"Please select the number of the verse you wish to practice. (between 1 and {currentLibrary.Scriptures.Count})");
      string scriptureSelection = Console.ReadLine();
      validSelection = int.TryParse(scriptureSelection, out scriptureIndex);
      if (validSelection) {
        if (scriptureIndex <= currentLibrary.Scriptures.Count) {
          currentLibrary.SetCurrentScripture(scriptureIndex - 1);
        } else {
          Console.WriteLine("The Scripture number you selected is invalid please try again.");
        }
      }

    }
    return currentLibrary;
  }

  private static Library ProcessMemorization(Library library) {
    MemorizationHelper helper = new MemorizationHelper();
    bool exitMemorization = false;
    int hideNumber = 5;
    ShowInstructions();
    while (!exitMemorization) {
      Scripture scriptureToMemorize = library.GetCurrentScripture();
      Console.Clear();
      Console.WriteLine(scriptureToMemorize.FormatRefrenceForDisplay());
      Console.WriteLine(scriptureToMemorize.FormatScriptureForDisplay());
      string option = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(option)) {
        helper.HideWords(scriptureToMemorize);
      } else if (int.TryParse(option, out hideNumber)) {
        helper.HideWords(scriptureToMemorize, hideNumber);
      } else {
        if (option.ToLower().StartsWith("end")) {
          exitMemorization = true;
        } else {
          ShowInstructions();
        }
      }
    }
    return library;
  }

  private static void ShowInstructions() {
    Console.WriteLine(ui.FormatMemorizationInstructions());
    Console.WriteLine("Press Enter to Continue");
    Console.ReadLine();
  }

  private static Library ProcessSaveScriptures(Library currentLibrary) {
    string scripturePath = "scriptures.xml";
    Console.WriteLine("Enter the path of the library xml file you wish to save (or press enter for default)");
    string submittedScripturePath = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(submittedScripturePath)) {
      scripturePath = submittedScripturePath;
    }
    currentLibrary.SaveScriptures(scripturePath);
    return currentLibrary;
  }

}