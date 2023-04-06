using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.UI {
  public class UIDisplay {


    public string FormatMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Load Deck Library");
      menu.AppendLine("2. Choose Activity");
      menu.AppendLine("3. Create Deck");
      menu.AppendLine("4. Select A Deck");
      menu.AppendLine("5. Display Current Deck");
      menu.AppendLine("6. Save Deck Library");
      menu.AppendLine("7. Exit");
      return menu.ToString();
    }

    public string FormatActivityTypeMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Mana Curve");
      menu.AppendLine("2. Card Compare");
      return menu.ToString();
    }

    public string CreateDeckInstructions() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("Welcome to the deck creator.");
      menu.AppendLine("You can enter ? anywhere in the process to repeat these instructions.");
      menu.AppendLine("You will start by giving your deck a name.");
      menu.AppendLine("After that you will go through the process of adding cards to your deck.");
      menu.AppendLine("You will be asked for your commander card.");
      menu.AppendLine("Then you will be able to search for and add cards to your deck.");
      menu.AppendLine("If a card is not legal for your deck (based on your commander) it will not be added.");
      menu.AppendLine("You can type 123 any time you wish to return to the main menu.");
      menu.AppendLine("Once you complete your deck you will want to save it using option 5 from the main menu.");
      return menu.ToString();
    }

  }
}
