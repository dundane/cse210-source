using FinalProject.Business;

namespace FinalProjectTests {
  [TestClass]
  public class DeckLibraryTests {

    DeckLibrary sut;
    
    [TestInitialize]
    public void Initialize() { 
      sut = new DeckLibrary();
    }

    [TestMethod]
    public void DeckLibraryContainsAListOfDecks() {

      List<Deck> deckList = sut.Decks;
      Assert.IsNotNull(deckList);

    }

    [TestMethod]
    public void DeckLibraryHasAnActiveDeck() {
      Deck deck = new Deck();
      sut.ActiveDeck = deck;
      
      Assert.AreEqual(deck, sut.ActiveDeck);

    }
  }
}