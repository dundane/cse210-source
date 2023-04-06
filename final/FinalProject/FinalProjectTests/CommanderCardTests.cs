using FinalProject.Business;

namespace FinalProjectTests
{
    [TestClass]
  public class CommanderCardTests {

    CommanderCard sut;


    [TestInitialize]
    public void Initialize() {
      sut = new CommanderCard();
    }

    [TestMethod]
    public void CommanderCardContainsListOfKeywords() {
      List<string> keywords = sut.Keywords;
      Assert.IsNotNull(keywords);
    }

    [TestMethod]
    public void CommanderCardContainsName() {
      sut.Name = "Test";
      string name = sut.Name;
      Assert.AreEqual("Test", name);
    }

    [TestMethod]
    public void CommanderCardContainsManaCost() {
      sut.ManaCost = "Test";
      string manaCost = sut.ManaCost;
      Assert.AreEqual("Test", manaCost);
    }

    [TestMethod]
    public void CommanderCardContainsConvertedManaCost() {
      sut.ConvertedManaCost = 1.0;
      double manaCost = sut.ConvertedManaCost;
      Assert.AreEqual(1.0, manaCost);
    }

    [TestMethod]
    public void CommanderCardContainsType() {
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
      Assert.AreEqual(3, types.Count);
    }


    [TestMethod]
    public void CommanderCardContainsOracleText() {
      sut.OracleText = "Test";
      string oracleText = sut.OracleText;
      Assert.AreEqual("Test", oracleText);
    }

    [TestMethod]
    public void CommanderCardContainsTypeLine() {
      sut.TypeLine = "Test";
      string typeLine = sut.TypeLine;
      Assert.AreEqual("Test", typeLine);
    }

    [TestMethod]
    public void CommanderCardContainsColors() {
      List<string> colors = sut.Colors;
      Assert.IsNotNull(colors);
    }

    [TestMethod]
    public void CommanderCardContainsColorIdentities() {
      List<string> colors = sut.ColorIdentitites;
      Assert.IsNotNull(colors);
    }

    [TestMethod]
    public void CommanderCardContainsLegalities() {
      Legality legalities = sut.Legalities;
      Assert.IsNotNull(legalities);
    }

    [TestMethod]
    public void CardContainsLegalities() {
      Legality legalities = sut.Legalities;
      Assert.IsNotNull(legalities);
    }

    [TestMethod]
    public void CanDetermineIfCardIsALegalCommander() {
      sut.Legalities.Commander="legal";
      sut.TypeLine = "Legendary Creature — Human Wizard";
      bool legalCommander = sut.IsLegalCommander();
      Assert.IsTrue(legalCommander);
    }

    [TestMethod]
    public void CanDetermineIfCardIsNotALegalCommanderNotLegendary() {
      sut.Legalities.Commander = "legal";
      sut.TypeLine = "Creature — Human Wizard";
      bool legalCommander = sut.IsLegalCommander();
      Assert.IsFalse(legalCommander);
    }

    [TestMethod]
    public void CanDetermineIfCardIsNotALegalCommanderLegality() {
      sut.Legalities.Commander = "not_legal";
      sut.TypeLine = "Legendary Creature — Human Wizard";
      bool legalCommander = sut.IsLegalCommander();
      Assert.IsFalse(legalCommander);
    }

  }
}