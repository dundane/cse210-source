using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalProject.Business
{
    public class ManaCurveActivity : Activity
    {
      public ManaCurveActivity(Deck deckForActivity) : base(deckForActivity) { }

    public override string ActivityDescription() {
      StringBuilder instructions = new StringBuilder();
      instructions.AppendLine("This activity will inform you about your mana curve.");
      return instructions.ToString();
    }

    public override string RunActivity() {
      double totalMana = 0;
      StringBuilder manaCurveInfo = new StringBuilder();
      Dictionary<string, double> manaCurve = new Dictionary<string, double>();
      manaCurve.Add("W", 0);
      manaCurve.Add("U", 0);
      manaCurve.Add("B", 0);
      manaCurve.Add("R", 0);
      manaCurve.Add("G", 0);
      manaCurve.Add("C", 0);
      totalMana += activityDeck.Commander.ConvertedManaCost;
      manaCurve["W"] += ManaFoundOfType(activityDeck.Commander, "W");
      manaCurve["U"] += ManaFoundOfType(activityDeck.Commander, "U");
      manaCurve["B"] += ManaFoundOfType(activityDeck.Commander, "B");
      manaCurve["R"] += ManaFoundOfType(activityDeck.Commander, "R");
      manaCurve["G"] += ManaFoundOfType(activityDeck.Commander, "G");
      manaCurve["C"] += ManaFoundOfType(activityDeck.Commander, "C");
      foreach (Card card in activityDeck.Cards) {
        totalMana += card.ConvertedManaCost;
        manaCurve["W"] += ManaFoundOfType(card, "W");
        manaCurve["U"] += ManaFoundOfType(card, "U");
        manaCurve["B"] += ManaFoundOfType(card, "B");
        manaCurve["R"] += ManaFoundOfType(card, "R");
        manaCurve["G"] += ManaFoundOfType(card, "G");
        manaCurve["C"] += ManaFoundOfType(card, "C");
      }
      manaCurveInfo.AppendLine($"You have a total of {totalMana} in your deck");
      manaCurveInfo.AppendLine($"This is an avarage of {totalMana / (activityDeck.Cards.Count + 1)} per card");
      manaCurveInfo.AppendLine($"You have {manaCurve["W"]} white mana cost in your deck");
      manaCurveInfo.AppendLine($"Your white mana represents {(manaCurve["W"] / totalMana) * 100} percent of the mana in your deck.");
      manaCurveInfo.AppendLine($"You have {manaCurve["B"]} black mana cost in your deck");
      manaCurveInfo.AppendLine($"Your black mana represents {(manaCurve["B"] / totalMana) * 100} percent of the mana in your deck.");
      manaCurveInfo.AppendLine($"You have {manaCurve["U"]} blue mana cost in your deck");
      manaCurveInfo.AppendLine($"Your blue mana represents {(manaCurve["U"] / totalMana) * 100} percent of the mana in your deck.");
      manaCurveInfo.AppendLine($"You have {manaCurve["R"]} red mana cost in your deck");
      manaCurveInfo.AppendLine($"Your red mana represents {(manaCurve["R"] / totalMana) * 100} percent of the mana in your deck.");
      manaCurveInfo.AppendLine($"You have {manaCurve["G"]} green mana cost in your deck");
      manaCurveInfo.AppendLine($"Your green mana represents {(manaCurve["G"] / totalMana) * 100} percent of the mana in your deck.");
      manaCurveInfo.AppendLine($"You have {manaCurve["C"]} colorless mana cost in your deck");
      manaCurveInfo.AppendLine($"Your white mana represents {(manaCurve["C"] / totalMana) * 100} percent of the mana in your deck.");
      return manaCurveInfo.ToString();
    }

    private double ManaFoundOfType(Card card, String manaType) {
      double found = 0;
      if (card.ManaCost != null) {
        
        if (manaType != "C") {
          foreach (char letter in card.ManaCost) {
            if (letter == Convert.ToChar(manaType)) {
              found++;
            }
          }
        } else {
          foreach (char letter in card.ManaCost) {
            if (double.TryParse(letter.ToString(), out found)) {
              return found;
            }
          }
        }
      }
      return found;
    }



  }
}
