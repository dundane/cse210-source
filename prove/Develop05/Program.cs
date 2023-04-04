using Develop05;

class Program {

  private static GoalManager Manager { get; set; }
  static void Main(string[] args) {
    FileIO fileIO = new FileIO();
    Scoreboard scoreboard = new Scoreboard(fileIO);
    scoreboard.LoadGoals();
    Manager = new GoalManager(fileIO , scoreboard);
    UIClass userInterface = new UIClass();
    while (true) {
      Console.WriteLine(userInterface.FormatMenu());
      String menuChoice = Console.ReadLine();
      ProcessMainMenu(menuChoice);
    }
  }

  static void ProcessMainMenu(string menuChoice) {
    int parsedMenuChoice;
    bool choiceParsable = Int32.TryParse(menuChoice, out parsedMenuChoice);
    if (choiceParsable) {
      switch (parsedMenuChoice) {
        case 1:
          Manager.LoadGoals("Data\\goals.xml");
          break;
        case 2:
          Console.WriteLine(Manager.FormatGoalsListForDisplay());
          break;
        case 3:
          HandleNewGoal();
          break;
        case 4:
          HandleCompleteGoal();
          break;
        case 5:
          Manager.SaveGoals("Data\\goals.xml");
          break;
        case 6:
          Console.WriteLine("Exiting Application");
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid selection please select from the menu items (1-4)");
          break;
      }
    } else {
      Console.WriteLine("Invalid Selection... Please select a number from the menu.");
    }
  }


  public static void HandleCompleteGoal() {
    Console.WriteLine("Select goal to complete.");
    Console.WriteLine(Manager.FormatGoalsListForDisplay());
    string selectedGoal = Console.ReadLine();
    int goalIndex;
    if (Int32.TryParse(selectedGoal, out goalIndex)) {
      Manager.CompleteGoal(goalIndex - 1);
    } else {
      Console.WriteLine($"{selectedGoal} is an invalid selection.");
    }
  }
  public static void HandleNewGoal() {
    UIClass ui = new UIClass();
    bool validSelection = false;
    while (!validSelection) {
      Console.WriteLine("Select the type of goal you would like to create.");
      Console.WriteLine(ui.FormatGoalTypeMenu());
      String selection = Console.ReadLine();
        switch (selection) {
        case "1":
          validSelection = true;
          break;
        case "2":
          validSelection = true;
          break;
        case "3":
          validSelection = true;
          break;
        default:
          Console.WriteLine("Invalid goal selection please try again. (1-3)");
          break;
      }
    }
  }

}
