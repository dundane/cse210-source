using Develop04;
using System;
using System.Diagnostics;
using System.Net.Mime;

class Program {
  static void Main(string[] args) {
    DisplayUI displayUI = new DisplayUI();
    List<string> options = new List<string>() { "1", "2", "3" };
    int activityDuration = 0;
    int activityFrequency = 0;
    while (true) {
      Console.WriteLine(displayUI.FormatMenu());
      string menuChoice = Console.ReadLine();
      if(options.Contains(menuChoice) ){
        Console.WriteLine($"How long in seconds would you like this activity to last? (press enter for default 120 seconds)");
        string activtyDurationResonse = Console.ReadLine();
        activityDuration = 0;
        if (!int.TryParse(activtyDurationResonse, out activityDuration)) {
          activityDuration = 120;
        }
        Console.WriteLine($"What frequency in seconds do you want for steps in this activity? (press enter for default 1/10th of duration)");
        string activtyFrequencyResonse = Console.ReadLine();
        activityFrequency = 0;
        if (!int.TryParse(activtyFrequencyResonse, out activityFrequency)) {
          activityFrequency = activityDuration / 10;
        } 
      }
      ProcessMenu(menuChoice, activityDuration, activityFrequency);
    }
  }

  static void ProcessMenu(string menuChoice, int activityDuration, int activityFrequency) {
    int parsedMenuChoice;
    bool choiceParsable = Int32.TryParse(menuChoice, out parsedMenuChoice);
    if (choiceParsable) {
      switch (parsedMenuChoice) {
        case 1:
          HandleBreathingExercise(activityDuration, activityFrequency);
          break;
        case 2:
          HandleReflectionExcercise(activityDuration, activityFrequency);
          break;
        case 3:
          HandleListingExercise(activityDuration, activityFrequency);
          break;
        case 4:
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

  public static void displaySpinner(int numSecondsToRun) {
    int spinnerCounter = 0;
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    while (stopwatch.ElapsedMilliseconds / 1000 < numSecondsToRun) {
      spinnerCounter++;
      switch (spinnerCounter % 4) {
        case 0: Console.Write("/"); break;
        case 1: Console.Write("-"); break;
        case 2: Console.Write("\\"); break;
        case 3: Console.Write("|"); break;
      }
      Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
      Thread.Sleep(200);
    }

    Console.Write(" ");
  }

  public static void displayCountDown(int numSecondsToRun) {
    for (int i = numSecondsToRun; i >= 1; i--) {
      Console.Write($"{i}...");
      Console.SetCursorPosition(0, Console.CursorTop);
      Thread.Sleep(1000);
    }
  }

  static void HandleBreathingExercise(int duration, int frequency) {
    BreathingActivity breathingActivity = new BreathingActivity(duration);
    int cycles = duration / frequency;
    Console.WriteLine(breathingActivity.Description);
    Console.WriteLine("Starting in...");
    displayCountDown(10);
    while (cycles > 0) {
      cycles--;
      Console.WriteLine(breathingActivity.GetBreathMessage());
      displayCountDown(frequency);
    }
    Console.WriteLine(breathingActivity.EndingMessage);

  }

  static void HandleListingExercise(int duration, int frequency) { 
    ListingActivity listingActivity = new ListingActivity(duration);
    int cycles = duration / frequency;
    Console.WriteLine(listingActivity.Description);
    Console.WriteLine("Starting in...");
    displayCountDown(10);
    DateTime activityStartTime = DateTime.Now;
    while (cycles > 0 && (DateTime.Now - activityStartTime).TotalSeconds < duration) {
      cycles--;
      DateTime startTime = DateTime.Now;
      string prompt = listingActivity.PromptList.GetRandomPrompt();
      Console.WriteLine(prompt);
      while ((DateTime.Now - startTime).TotalSeconds < frequency) { 
        listingActivity.AddAnswer(prompt, Console.ReadLine());
      }
    }
    Console.WriteLine(listingActivity.EndingMessage);
    Console.WriteLine("Here are your results...");
    Console.WriteLine(listingActivity.FormatResultsForDisplay());
  }

  static void HandleReflectionExcercise(int duration, int frequency) {
    ReflectionActivity reflectionActivity = new ReflectionActivity(duration, frequency);

    int cycles = duration / frequency;
    int remainderOfFrequency = frequency % 3;
    int secondaryDuration = frequency / 3;
    int primaryDuration = secondaryDuration + remainderOfFrequency;
    
    Console.WriteLine(reflectionActivity.Description);
    Console.WriteLine("Starting in...");
    displayCountDown(10);
    while (cycles > 0) {
      cycles--;
      Console.WriteLine(reflectionActivity.PrimaryPrompt.GetRandomPrompt());
      displayCountDown(primaryDuration);
      for(int i = 0; i < 2; i++) {
        Console.WriteLine(reflectionActivity.SecondaryPrompt.GetRandomPrompt());
        displayCountDown(secondaryDuration);
      }

    }
    Console.WriteLine(reflectionActivity.EndingMessage);
  }
}