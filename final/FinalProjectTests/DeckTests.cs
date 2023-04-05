using FinalProject.Business;

namespace FinalProjectTests {
  [TestClass]
  public class DeckTests {

    Deck sut;

    [TestInitialize]
    public void Initialize() {
      sut = new Deck();
    }


    [TestMethod]
    public void DecksContainAListOfCards() {
    }
  }
}