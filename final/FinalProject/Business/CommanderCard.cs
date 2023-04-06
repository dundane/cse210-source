using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business {
  public class CommanderCard : Card {
    public CommanderCard() : base() { }

    public bool IsLegalCommander() {
      return Types.Contains("Legendary") && Legalities.CommanderLegal;
    }
  }
}
