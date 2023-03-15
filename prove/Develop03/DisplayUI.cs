using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class DisplayUI {
    public string FormatMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Load Scriptures\n");
      menu.AppendLine("2. Display Scriptures List\n");
      menu.AppendLine("3. Add Scripture\n");
      menu.AppendLine("4. Practice A Scripture\n");
      menu.AppendLine("5. Save Scriptures\n");
      menu.AppendLine("6. Exit\n");
      return menu.ToString();
    }

    public String FormatMemorizationInstructions() {
      StringBuilder instructions = new StringBuilder();
      instructions.AppendLine("***Instructions***\n");
      instructions.AppendLine("This will dispay the current scripture you have selected.\n");
      instructions.AppendLine("If you press enter it will hide 5 words and show you again.\n");
      instructions.AppendLine("If you enter any number it will hide that many words.\n");
      instructions.AppendLine("If you type end it will end this session and return you to the main menu.\n");
      instructions.AppendLine("If you enter any other value it will give you these instructions again.\n");
      instructions.AppendLine("If you save after exiting it will save your current session with hidden words.\n");
      return instructions.ToString();

    }
  }
}
