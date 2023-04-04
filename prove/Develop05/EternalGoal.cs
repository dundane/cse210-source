namespace Develop05 {
  public class EternalGoal : Goal {
    public EternalGoal() : base() { 
    
    }
    public EternalGoal(string name, string description, int pointValue) : base(name, description, pointValue) {
    }

    public override bool Complete() {
      return base.Complete();
    }

    public override bool SingleUse { get { return false; } }
  }
}
