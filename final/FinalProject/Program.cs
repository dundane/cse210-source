using System;
using System.Data;

class Program {
  static void Main(string[] args) {
    while (true) {
      String menuEntry = Console.ReadLine();
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
        HandleSaveLibrary();
        break;
      case "6":
        Console.WriteLine("Exiting Application");
        Environment.Exit(0);
        break;
    }

  }

  private static void HandleSaveLibrary() {
    throw new NotImplementedException();
  }

  private static void HandleFindDeck() {
    throw new NotImplementedException();
  }

  private static void HandleCreateDeck() {
    throw new NotImplementedException();
  }

  private static void HandleChooseActivity() {
    throw new NotImplementedException();
  }

  private static void HandleLoadLibrary() {
    throw new NotImplementedException();
  }
}