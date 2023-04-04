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

    public GoalManager(FileIO fileIO) {
      goals = new List<Goal>();
      this.fileIO = fileIO;
    }

    public List<Goal> Goals { get { return goals; } }

    public void CompleteGoal(int goalIndex) {
      if (goals.Count > goalIndex) {
        goals[goalIndex].Complete();
      }
    }

    public string FormatGoalsListForDisplay() {
      StringBuilder goalsToDisplay = new StringBuilder();
      
      for(int goalIndex = 0; goalIndex < goals.Count; goalIndex++) {
        Goal goal = goals[goalIndex];
        string completeMark = goal.IsComplete() ? "X" : " ";
        goalsToDisplay.Append($"[{completeMark}]{goalIndex + 1}. {goal.FormatForDisplay()}\n");
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
        EternalGoal eternalGoal = new EternalGoal(name,description,pointValue);
        goals.Add(eternalGoal);
        return eternalGoal as T;

      } else if (typeof(T) == typeof(ChecklistGoal)) {
        ChecklistGoal checklistGoal =  new ChecklistGoal(name, description,pointValue, bonusRequirement, bonusAward);
        goals.Add(checklistGoal);
        return checklistGoal as T;
      } else { 
        Goal goal = new Goal(name,description, pointValue);
        goals.Add(goal);
        return goal as T;
      }
    }

    public int CaclulateScore() {
      int totalScore = 0;
      foreach (var goal in goals) {
        totalScore += goal.CalculatePoints();
      }
      return totalScore;
    }

  }
}
