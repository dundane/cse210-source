using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05 {
  public class UIClass {
    public string FormatMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Load Goals\n");
      menu.AppendLine("2. List Goals\n");
      menu.AppendLine("3. Add New Goal\n");
      menu.AppendLine("4. Complete Goal\n");
      menu.AppendLine("5. Save Goals\n");
      menu.AppendLine("6. Exit\n");
      return menu.ToString();
    }

    public string FormatGoalTypeMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Simple Goal\n");
      menu.AppendLine("2. Eternal Goal\n");
      menu.AppendLine("3. Checklist Goal\n");
      return menu.ToString();
    }

  }
}
