using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05 {
  public class ChecklistGoal : Goal {
    private int bonusCount;
    private int bonusAward;

    public ChecklistGoal() : base() {
    }

    public ChecklistGoal(string name, string description, int pointValue, int bonusCount, int bonusAward) : base(name, description, pointValue) {
      this.bonusCount = bonusCount;
      this.bonusAward = bonusAward;
    }

    public int BonusCount {
      get { return bonusCount; }
      set {
        bonusCount = value;
      }
    }

    public int BonusAward {
      get { return bonusAward; }
      set {
        bonusAward = value;
      }
    }

    public override bool Complete() {
      return base.Complete();
    }

    public override bool IsComplete() {
      if (CompletionCount >= BonusCount) {
        return true;
      }
      return false;
    }

    public override int CalculatePoints() {
      int pointTotal = 0;
      if (CompletionCount > 1) {
        pointTotal += PointValue * CompletionCount;
      }
      if (CompletionCount >= BonusCount) {
        pointTotal += BonusAward;
      }
      return pointTotal;
    }

    public override string FormatForDisplay() {
      string completeDate = (CompletionCount > 0) ? $"Last Recorded {LastCompleteDate.ToShortDateString()}" : "";
      return base.FormatForDisplay() + $"({CompletionCount}/{BonusCount})" + completeDate;
    }

  }
}
