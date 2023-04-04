using System.Xml.Serialization;

namespace Develop05 {
  [XmlInclude(typeof(EternalGoal))]
  [XmlInclude(typeof(ChecklistGoal))]
  public class Goal {
    private int pointValue;
    private string name;
    private string description;
    private DateTime lastCompleteDate;
    private int completionCount;

    public Goal() { 
    }
    public Goal(string name, string description, int pointValue) {
      this.name = name;
      this.description = description;
      this.pointValue = pointValue;
    }
    public int PointValue {
      get { 
        return pointValue; 
      }
      set {
        pointValue = value;
      }
    }
    public String Name {
      get { 
        return name; 
      }
      set {
        name = value;
      }
    }
    public string Description {
      get {
        return description;
      }
      set {
        description = value;
      }
    }
    public DateTime LastCompleteDate {
      get { 
        return lastCompleteDate; 
      }
      set {
        lastCompleteDate = value;
      }
    }
    public int CompletionCount {
      get { 
        return completionCount; 
      }
      set {
        completionCount = value;
      }
    }

    public virtual bool Complete() {
      LastCompleteDate = DateTime.Now;
      CompletionCount += 1;
      return true;
    }

    public virtual bool SingleUse { get { return true; } }

  }
}
