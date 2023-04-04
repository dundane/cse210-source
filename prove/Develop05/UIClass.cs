using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05 {
  public class UIClass {
    public string FormatMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Load Goals");
      menu.AppendLine("2. List Goals");
      menu.AppendLine("3. Add New Goal");
      menu.AppendLine("4. Complete Goal");
      menu.AppendLine("5. Save Goals");
      menu.AppendLine("6. Exit");
      return menu.ToString();
    }

    public string FormatGoalTypeMenu() {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("1. Simple Goal");
      menu.AppendLine("2. Eternal Goal");
      menu.AppendLine("3. Checklist Goal");
      return menu.ToString();
    }

  }
}
