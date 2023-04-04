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

    public override bool SingleUse { get { return false; } }

    public override bool Complete() {
      return base.Complete();
    }

  }
}
