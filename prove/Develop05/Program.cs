using Develop05;
using System.Runtime.InteropServices;

class Program {

  private static GoalManager Manager { get; set; }
  static void Main(string[] args) {
    FileIO fileIO = new FileIO();
    Manager = new GoalManager(fileIO);
    UIClass userInterface = new UIClass();
    Console.WriteLine("Welcome to progress tracker!!!");
    while (true) {
      Console.WriteLine($"You currently have {Manager.CaclulateScore()} points!!!");
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
          HandleLoadGoal();
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

  public static void HandleLoadGoal() {
    Console.WriteLine("Please enter the name of the xml goal file you would like to load (Press Enter to load default goals.xml)");
    String fileResult = Console.ReadLine();
    if (File.Exists(fileResult)) {
      Manager.LoadGoals(fileResult);
    } else {
      Console.WriteLine("Loading default file.");
      Manager.LoadGoals("Data\\goals.xml");
    }
  }


  public static void HandleCompleteGoal() {
    Console.WriteLine("Select goal to complete.");
    Console.WriteLine(Manager.FormatGoalsListForDisplay());
    string selectedGoal = Console.ReadLine();
    int goalIndex;
    int previousScore = Manager.CaclulateScore();
    if (Int32.TryParse(selectedGoal, out goalIndex)) {
      Manager.CompleteGoal(goalIndex - 1);
    } else {
      Console.WriteLine($"{selectedGoal} is an invalid selection.");
    }
    Console.WriteLine($"You just earned {Manager.CaclulateScore() - previousScore} points!!!");
  }
  public static void HandleNewGoal() {
    UIClass ui = new UIClass();
    bool validSelection = false;
    String goalType = "Goal";
    Goal newGoal = null;
    while (!validSelection) {
      Console.WriteLine("Select the type of goal you would like to create.");
      Console.WriteLine(ui.FormatGoalTypeMenu());
      String selection = Console.ReadLine();
      switch (selection) {
        case "1":
          goalType = "Standard";
          newGoal = new Goal();
          validSelection = true;
          break;
        case "2":
          goalType = "Eternal";
          newGoal = new EternalGoal();
          validSelection = true;
          break;
        case "3":
          goalType = "Checklist";
          newGoal = new ChecklistGoal();
          validSelection = true;
          break;
        default:
          Console.WriteLine("Invalid goal selection please try again. (1-3)");
          break;
      }



      Console.WriteLine($"Please enter the information for your {goalType} goal.");
      Console.WriteLine("Please enter a name for your goal.");
      string goalName = Console.ReadLine();
      Console.WriteLine("Please enter a brief description of your goal.");
      string goalDescription = Console.ReadLine();
      bool isNumber = false;
      int awardPointsValue = 0;
      while (!isNumber) {
        Console.WriteLine("Please enter the number of points you are awarded for one time completion of this goal.");
        string awardPoints = Console.ReadLine();

        isNumber = int.TryParse(awardPoints, out awardPointsValue);
        if (isNumber) {
          newGoal.PointValue = awardPointsValue;
        } else {
          Console.WriteLine("Invalid number try again.");
        }
      }

      int bonusCountValue = 0;

      int bonusPointsValue = 0;
      newGoal.CompletionCount = 0;
      if (goalType == "Checklist") {
        ChecklistGoal newChecklistGoal = (ChecklistGoal)newGoal;
        isNumber = false;
        while (!isNumber) {
          Console.WriteLine("Please enter the number of times this goal needs to be completed for bonus.");
          string bonusCount = Console.ReadLine();

          isNumber = int.TryParse(bonusCount, out bonusCountValue);
          if (isNumber) {
            newChecklistGoal.BonusCount = bonusCountValue;
          } else {
            Console.WriteLine("Invalid number try again.");
          }
        }


        isNumber = false;
        while (!isNumber) {
          Console.WriteLine("Please enter the number of bonus points when you fully complete this goal.");
          string bonusPoints = Console.ReadLine();

          isNumber = int.TryParse(bonusPoints, out bonusPointsValue);
          if (isNumber) {
            newChecklistGoal.BonusAward = bonusPointsValue;
          } else {
            Console.WriteLine("Invalid number try again.");
          }
        }
      }

      switch (goalType) {
        case "Eternal":
          Manager.CreateGoal<EternalGoal>(goalName, goalDescription, awardPointsValue);
          break;
        case "Checklist":
          Manager.CreateGoal<ChecklistGoal>(goalName, goalDescription, awardPointsValue, bonusCountValue, bonusPointsValue);
          break;
        default:
          Manager.CreateGoal<Goal>(goalName, goalDescription, awardPointsValue);
          break;
      }
    }
  }

}
