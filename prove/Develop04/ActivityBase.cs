using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04 {
  public class ActivityBase {
    private string description;
    private string startingMessage;
    private string endingMessage;
    private int durationSeconds;
    private string activityType;

    public ActivityBase(int durationSeconds) {
      this.startingMessage = $"You have chosen \"{activityType} Activity\".\nThis activity will last for {durationSeconds.ToString()} seconds.";
      this.endingMessage = $"Thank you for participating in a \"{activityType} Activity\". Return again any time!";
      this.durationSeconds = durationSeconds;
    }

    public String Description { get { return description; } set { description = value; } }
    public string StartingMessage { get {  return startingMessage; } set {  startingMessage = value; } }
    public string EndingMessage { get { return endingMessage; } set {  endingMessage = value; } }
    public int DurationSeconds { get {  return durationSeconds; } set {  durationSeconds = value; } }

    public string ActivityType { get { return activityType; } set { activityType = value; } }
  }
}
