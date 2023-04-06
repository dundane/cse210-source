using FinalProject.Business;
using RestSharp;

namespace FinalProjectTests {
  [TestClass]
  public class ScryfallApiTests {

    ScryfallApi sut = new ScryfallApi();


    [TestMethod]
    public void CanMakeARequestToReturnACardInfoFromScryfall() {
      Card returnedCard = sut.FindCard("The Scarab God");
      Assert.AreEqual("The Scarab God", returnedCard.Name);
      Assert.AreEqual(5, returnedCard.ConvertedManaCost);
      Assert.AreEqual("B", returnedCard.ColorIdentitites[0]);
      Assert.AreEqual("B", returnedCard.Colors[0]);
      Assert.AreEqual("{3}{U}{B}", returnedCard.ManaCost);
      Assert.IsTrue(returnedCard.OracleText.Contains("Zombie"));
      Assert.AreEqual("Creature", returnedCard.Types[1]);
      Assert.AreEqual("Scry", returnedCard.Keywords[0]);
    }

    [TestMethod]
    public void ReturnsNullIfWeCanNotFindTheCard() {
      Card returnedCard = sut.FindCard("Volo");
      Assert.IsNull(returnedCard);
    }

    [TestMethod]
    public void CanMakeARequestToReturnACommanderCardInfoFromScryfall() {
      CommanderCard returnedCard = sut.FindCommanderCard("The Scarab God");
      Assert.AreEqual("The Scarab God", returnedCard.Name);
      Assert.AreEqual(5, returnedCard.ConvertedManaCost);
      Assert.AreEqual("B", returnedCard.ColorIdentitites[0]);
      Assert.AreEqual("B", returnedCard.Colors[0]);
      Assert.AreEqual("{3}{U}{B}", returnedCard.ManaCost);
      Assert.IsTrue(returnedCard.OracleText.Contains("Zombie"));
      Assert.AreEqual("Creature", returnedCard.Types[1]);
      Assert.AreEqual("Scry", returnedCard.Keywords[0]);
    }

  }
}