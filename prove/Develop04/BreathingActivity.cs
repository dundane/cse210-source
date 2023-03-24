using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04 {

  
  public class BreathingActivity : ActivityBase {
    private string inMessage = "Slowly Inhale...";
    private string outMessage = "Slowly Exhale...";
    private bool lastMessageWasInMessage = false;

    public BreathingActivity(int durationSeconds) : base(durationSeconds) {
      ActivityType = "Breathing";
      Description = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus only on breathing.";
    }

    private string BreathMessage(bool isInMessage) { 
      if (isInMessage) {
        return inMessage;
      } else {
        return outMessage;
      }
    }


    public string GetBreathMessage() { 
        lastMessageWasInMessage = !lastMessageWasInMessage;
    
      return BreathMessage(lastMessageWasInMessage);
    }

  }
}
