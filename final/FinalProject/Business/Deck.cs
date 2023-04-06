using System.Drawing;
using System.Text;

namespace FinalProject.Business {
  public class Deck {
    private List<Card> cards;

    public Deck() {
      cards = new List<Card>();
    }

    public List<Card> Cards {
      get { return cards; }
      set {
        cards = value;
      }
    }

    public CommanderCard Commander { get; set; }
    public List<string> ColorIdentity { 
      get {
        if (Commander == null) {
          return null;
        }
        return Commander.ColorIdentitites;
      } 
    }

    public string Name { get; set; }

    public string GetColorIdentityString() {
      string colorIdentityString = "";
      if (Commander != null) {
        foreach (string color in Commander.ColorIdentitites) { 
          colorIdentityString += color;
        }
      }
      return colorIdentityString;
    }

    public void AddCard(Card cardToAdd) {
      cards.Add(cardToAdd);
    }

    public string FormatNameForDisplay() {
      string commanderName = (Commander != null) ? $"({Commander.Name})" : "";
      return $"{Name} {commanderName}".Trim();
    }

    public string FormatDeckListForDisplay() { 
      StringBuilder deckCards = new StringBuilder();
      if (Commander != null) {
        deckCards.AppendLine($"Commander : {Commander.Name} {Commander.ManaCost}");
      }
      foreach (Card card in cards) {
        deckCards.AppendLine($"{card.Name} {card.ManaCost}");
      }
      return deckCards.ToString();
    }

  }
}
