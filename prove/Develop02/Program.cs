using Develop02;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

class Program {
  private static Journal activeJournal { get; set; }
  private static Prompts prompts { get; set; }
  private static String activePrompt { get; set; }
  private static Entry activeEntry { get; set; }
  static void Main(string[] args) {
    activeJournal = new Journal();
    prompts = new Prompts();
    prompts.LoadProptsFile("JournalData\\prompts.txt");
    while (true) {
      DisplayMenuOptions();
      string menuAction = PromptForMenuSelection();
      TakeMenuAction(menuAction);
    }
  }

  static void MenuSelectionLoadJournal() {
    string journalFileName = PromptForFile();
    activeJournal.LoadEntries(journalFileName);
  }

  static void MenuSelectionDisplayJournal() {
    Console.WriteLine("*******Beginning of Journal********");
    Console.WriteLine(activeJournal.GetFormattedJournal());
    Console.WriteLine("**********End of Journal***********");
  }

  static void MenuSelectionGetPrompt() {
    activePrompt = prompts.GetRandomWritingPrompt();
    Console.WriteLine();
    Console.WriteLine($"Prompt : {activePrompt}");
    Console.WriteLine();
  }

  static void MenuSelectionStartJournalEntry() {
    StringBuilder entryText = new StringBuilder();
    String currentLine = "";
    Console.WriteLine();
    Console.WriteLine("While journal entry is active you can type whatever you want.");
    Console.WriteLine("To end your journal entry type \"end\"");
    while (currentLine.ToLower() != "end") {
      currentLine = Console.ReadLine();
      if (currentLine.ToLower() != "end") {
        entryText.Append(currentLine);
      }
    }

    Entry newEntry = new Entry(DateTime.Now.ToShortDateString(), activePrompt, entryText.ToString());

    Console.WriteLine();
    Console.WriteLine("Your journal entry reads.....");
    Console.WriteLine();
    Console.WriteLine(newEntry.FormatForDisplay());
    Console.WriteLine();
    Console.WriteLine("Would you like to keep this entry? (enter no to discard this entry)");
    String keepEntry = Console.ReadLine();

    if (keepEntry.ToLower().Trim() != "no") {
      activeJournal.AddJournalEntry(newEntry);
    } else {
      Console.WriteLine("Journal Entry Discarded");
    }
  }

  static void MenuSelectionSaveJournal() {
    string journalFileName = PromptForFile();
    string overwriteSelection = "";
    if (File.Exists(journalFileName)) {

      while (!overwriteSelection.ToLower().StartsWith("n") && !overwriteSelection.ToLower().StartsWith("y")) {
        Console.WriteLine("The journal file you created already exists would you like to overwrite it?");
        Console.WriteLine($"Overwrite file (y/n)?");
        Console.WriteLine(journalFileName);
        overwriteSelection = Console.ReadLine();
      }
    }
    if (overwriteSelection.ToLower().StartsWith("n")) {
      Console.WriteLine("Aborting Save...");
    } else {
      activeJournal.SaveEntries(journalFileName);
    }

  }

  static void DisplayMenuOptions() {
    StringBuilder menu = new StringBuilder();
    menu.AppendLine("**** Journal Menu ****");
    menu.AppendLine("1. Load Journal File");
    menu.AppendLine("2. Display Journal Entries");
    menu.AppendLine("3. Get New Writing Prompt");
    menu.AppendLine("4. Create Journal Entry");
    menu.AppendLine("5. Save Journal");
    menu.AppendLine("6. Exit Program");
    Console.WriteLine(menu.ToString());

  }

  static void MenuSelectionExit() {
    string exitAnswer = "";
    while (!exitAnswer.ToLower().StartsWith("n") && !exitAnswer.ToLower().StartsWith("y")) {
      Console.WriteLine("Are you sure you want to exit? (y/n)");
      Console.WriteLine("Select no if you have not saved your journal entry and want to.");
      exitAnswer = Console.ReadLine();
    }
    if (exitAnswer.ToLower().StartsWith("y")) {
      Environment.Exit(0);
    }
    
  }

  static string PromptForFile() {
    string defaultFile = "JournalData\\JournalEntries.xml";
    string fileToUse = "";
    while (!fileToUse.EndsWith(".xml")) {
      Console.WriteLine($"Please enter the file you want for your journal entries or press enter for detault. {defaultFile}");
      Console.WriteLine("journal files must be .xml files");
      fileToUse = Console.ReadLine();
      if (fileToUse.Trim() == string.Empty) {
        fileToUse = defaultFile;
      }
    }
    return fileToUse;
  }

  static string PromptForMenuSelection() {

    List<string> options = new List<string>() { "1", "2", "3", "4", "5", "6" };
    string selectedMenuItem = "0";
    while (!options.Contains(selectedMenuItem)) {
      Console.WriteLine("Please select a menu item.");
      selectedMenuItem = Console.ReadLine();
    }
    return selectedMenuItem;
  }

  static void TakeMenuAction(string menuSelection) {
    switch (menuSelection) {
      case "1":
        MenuSelectionLoadJournal();
        break;
      case "2":
        MenuSelectionDisplayJournal();
        break;
      case "3":
        MenuSelectionGetPrompt();
        break;
      case "4":
        MenuSelectionStartJournalEntry();
        break;
      case "5":
        MenuSelectionSaveJournal();
        break;
      case "6":
        MenuSelectionExit();
        break;
      default:
        Console.WriteLine("Invalid Menu Selection please select from...");
        DisplayMenuOptions();
        PromptForMenuSelection();
        break;
    }
  }

}