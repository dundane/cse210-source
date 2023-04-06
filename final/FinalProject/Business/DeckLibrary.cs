using Newtonsoft.Json;
using System.Text;

namespace FinalProject.Business {
  public class DeckLibrary {
    private List<Deck> decks;
    private Deck activeDeck;

    public DeckLibrary() {
      decks = new List<Deck>();
    }
    public List<Deck> Decks { get { return decks; } set { decks = value; } }

    [JsonIgnore]
    public Deck ActiveDeck {
      get { return activeDeck; }
      set {
        activeDeck = value;
      }
    }

    public Deck ActivateDeck(int deckIndex) { 
      if(deckIndex < decks.Count) {
        activeDeck = decks[deckIndex];
      }
      return activeDeck;
    }

    public string FormatDeckListForDisplay() { 
      StringBuilder deckList = new StringBuilder();
      for(int deckIndex  = 0;deckIndex < decks.Count;deckIndex++) {
        deckList.AppendLine($"{deckIndex + 1}. {decks[deckIndex].FormatNameForDisplay()}");
      }
      return deckList.ToString();
    }

    public void AddDeck(Deck deck) {
      activeDeck = deck;
      decks.Add(activeDeck);
    }
  }
}
