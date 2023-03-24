using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04 {
  public class DisplayUI {
    public string FormatMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Start Breathing Excercise\n");
      menu.AppendLine("2. Start Reflection Activity\n");
      menu.AppendLine("3. Start Listing Activity\n");
      menu.AppendLine("4. Exit\n");
      return menu.ToString();
    }
  }
}
