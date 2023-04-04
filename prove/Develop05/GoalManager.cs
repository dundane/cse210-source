using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Develop05 {
  public class GoalManager {
    private List<Goal> goals;
    private FileIO fileIO;
    private Scoreboard scoreboard;

    public GoalManager(FileIO fileIO, Scoreboard scoreboard) {
      goals = new List<Goal>();
      this.fileIO = fileIO;
      this.scoreboard = scoreboard;
    }

    public List<Goal> Goals { get { return goals; } }

    public void CompleteGoal(int goalIndex) {
      if (goals.Count > goalIndex) {
        goals[goalIndex].Complete();
        scoreboard.Results.Add(goals[goalIndex]);
      }
    }

    public string FormatGoalsListForDisplay() {
      StringBuilder goalsToDisplay = new StringBuilder();
      
      for(int goalIndex = 0; goalIndex < goals.Count; goalIndex++) {
        goalsToDisplay.Append($"[ ]{goalIndex}. {goals[goalIndex].Name}\n");
      }

      return goalsToDisplay.ToString();
    }

    public void LoadGoals(string fileName) {
      goals = fileIO.LoadGoalList(fileName);
    }

    public void SaveGoals(string fileName) {
      fileIO.SaveGoalList(fileName, goals);
    }

    public T CreateGoal<T>(string name, string description, int pointValue, int bonusRequirement = 0, int bonusAward = 0 ) where T : Goal {
      if (typeof(T) == typeof(EternalGoal)) {
        return new EternalGoal(name,description,pointValue) as T;
      } else if (typeof(T) == typeof(ChecklistGoal)) {
        return new ChecklistGoal(name, description,pointValue, bonusRequirement, bonusAward) as T;
      } else { 
        return new Goal(name,description, pointValue) as T;
      }

    }

  }
}
