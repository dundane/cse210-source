using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business {
  public class Activity {
    internal Deck activityDeck;
    public Activity(Deck deckForActivity) { 
      activityDeck = deckForActivity;
    }

    public virtual string ActivityDescription() {
      return "This is a generic activity";
    }

    public virtual string RunActivity() {
      return activityDeck.FormatNameForDisplay();
    }

  }
}
