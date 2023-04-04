using System.ComponentModel;

namespace Develop05 {
  public class EternalGoal : Goal {
    public EternalGoal() : base() { 
    
    }
    public EternalGoal(string name, string description, int pointValue) : base(name, description, pointValue) {
    }

    public override bool Complete() {
      base.Complete();
      return IsComplete();
    }

    public override bool IsComplete() {
      return false;
    }

    public override int CalculatePoints() {
      return PointValue * CompletionCount;
    }

    public override string FormatForDisplay() {
      string completeDate = (CompletionCount > 0) ? $"Last Completed {LastCompleteDate.ToShortDateString()}" : "";
      return base.FormatForDisplay() + $"Completed {CompletionCount} times. " + completeDate;
    }

  }
}
