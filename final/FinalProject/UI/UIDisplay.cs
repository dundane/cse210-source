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
      menu.AppendLine("4. Find A Deck");
      menu.AppendLine("5. Save Deck Library");
      menu.AppendLine("6. Exit");
      return menu.ToString();
    }

    public string FormatActivityTypeMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Mana Curve");
      menu.AppendLine("2. Card Compare");
      return menu.ToString();
    }


  }
}
