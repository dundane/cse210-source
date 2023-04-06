using FinalProject.Business;

namespace FinalProjectTests
{
    [TestClass]
  public class CardTests {

    Card sut;
    [TestInitialize]
    public void Initialize() {
      sut = new Card();
    }

    [TestMethod]
    public void CardContainsListOfKeywords() {
      List<string> keywords = sut.Keywords;
      Assert.IsNotNull(keywords);
    }

    [TestMethod]
    public void CardContainsName() {
      sut.Name = "Test";
      string name = sut.Name;
      Assert.AreEqual("Test", name);
    }

    [TestMethod]
    public void CardContainsManaCost() {
      sut.ManaCost = "Test";
      string manaCost = sut.ManaCost;
      Assert.AreEqual("Test", manaCost);
    }

    [TestMethod]
    public void CardContainsConvertedManaCost() {
      sut.ConvertedManaCost = 1.0;
      double manaCost = sut.ConvertedManaCost;
      Assert.AreEqual(1.0, manaCost);
    }

    [TestMethod]
    public void CardContainsType() {
      List<string> types = sut.Types;
      Assert.IsNotNull(types);
    }

    [TestMethod]
    public void TypesParseFromTypeLine() {
      sut.TypeLine = "Legendary Creature — God";
      List<string> types = sut.Types;
      Assert.IsTrue(types.Contains("Legendary"));
      Assert.IsTrue(types.Contains("Creature"));
      Assert.IsTrue(types.Contains("God"));
      Assert.AreEqual(3, sut.Types.Count);
    }


    [TestMethod]
    public void CardContainsOracleText() {
      sut.OracleText = "Test";
      string oracleText = sut.OracleText;
      Assert.AreEqual("Test", oracleText);
    }

    [TestMethod]
    public void CardContainsTypeLine() {
      sut.TypeLine = "Test";
      string typeLine = sut.TypeLine;
      Assert.AreEqual("Test", typeLine);
    }

    [TestMethod]
    public void CardContainsColors() {
      List<string> colors = sut.Colors;
      Assert.IsNotNull(colors);
    }

    [TestMethod]
    public void CardContainsColorIdentities() {
      List<string> colors = sut.ColorIdentitites;
      Assert.IsNotNull(colors);
    }

    [TestMethod]
    public void CardContainsLegalities() {
      Legality legalities = sut.Legalities;
      Assert.IsNotNull(legalities);
    }

    [TestMethod]
    public void DeterminsIfACardIsInAColorIdentityTrue() {
      sut.ColorIdentitites.Add("B");
      sut.ColorIdentitites.Add("U");
      bool result = sut.IsInColorIdentity("WBU");
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void DeterminsIfACardIsInAColorIdentityFalse() {
      sut.ColorIdentitites.Add("G");
      sut.ColorIdentitites.Add("U");
      bool result = sut.IsInColorIdentity("WBU");
      Assert.IsFalse(result);
    }


  }
}