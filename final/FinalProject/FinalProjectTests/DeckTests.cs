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
      List<Card> cards = sut.Cards;
      Assert.IsNotNull(cards);
    }


    [TestMethod]
    public void DecksContainACommanderCard() {
      sut.Commander = new CommanderCard() { Name = "MyCommander" };
      CommanderCard commander  = (CommanderCard) sut.Commander;
      Assert.IsNotNull(commander);
      Assert.IsInstanceOfType(commander, typeof(CommanderCard));
    }

    [TestMethod]
    public void DecksHasAColorIdentity() {
      sut.Commander = new CommanderCard() { Name = "MyCommander", ColorIdentitites = new List<string>() { "B", "G" } };
      List<String> colorIdentity = sut.ColorIdentity;
      Assert.IsTrue(colorIdentity.Contains("B"));
      Assert.IsTrue(colorIdentity.Contains("G"));
      Assert.IsFalse(colorIdentity.Contains("U"));
    }

    [TestMethod]
    public void DecksHasAName() {
      sut.Name = "Test";
      String name = sut.Name;
      Assert.AreEqual("Test", name);
    }

    [TestMethod]
    public void AbleToFormatDeckForDisplay() {
      sut.Commander = new CommanderCard() { Name = "My Commander" };
      CommanderCard commander = (CommanderCard)sut.Commander;
      sut.Name = "Test";
      String name = sut.FormatNameForDisplay();
      Assert.AreEqual("Test (My Commander)", name);
    }

    [TestMethod]
    public void AbleToAddACardToDeck() {
      CommanderCard cardToAdd = new CommanderCard() { Name = "Darkest Hour" };
      sut.AddCard(cardToAdd);
      Assert.IsTrue(sut.Cards.Contains(cardToAdd));
    }

    [TestMethod]
    public void AbleToGetTheColorIdentyStringForDeck() {
      CommanderCard cardToAdd = new CommanderCard() { Name = "Darkest Hour", ColorIdentitites = new List<string>() {"W","B","U" } };
      sut.Commander = cardToAdd;
      String colorIdentityString = sut.GetColorIdentityString();
      Assert.IsTrue(colorIdentityString.Contains("W"));
      Assert.IsTrue(colorIdentityString.Contains("B"));
      Assert.IsTrue(colorIdentityString.Contains("U"));
      Assert.IsTrue(!colorIdentityString.Contains("R"));
      Assert.IsTrue(!colorIdentityString.Contains("G"));
    }

  }
}
