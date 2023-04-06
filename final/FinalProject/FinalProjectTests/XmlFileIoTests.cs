

using FinalProject.Business;

namespace FinalProjectTests {
  [TestClass]
  public class XmlFileIoTests {

    DeckLibraryXmlFileIo sut;

    [TestInitialize]
    public void Initialize() {
      sut = new DeckLibraryXmlFileIo();
    }

    [TestMethod]
    public void AbleToSaveDeckLibraryAsXml() {
      String filePath = "TestHelpers\\decklist.xml";
      DeckLibrary library = new DeckLibrary();
      Deck deck = new Deck();
      deck.Commander = new CommanderCard() { Name = "My Commander" };
      deck.AddCard(new Card() { Name = "Basic Card One" });
      deck.AddCard(new Card() { Name = "Basic Card Two" });
      library.Decks.Add(deck);

      sut.SaveDeckLibrary(library, filePath);
      Assert.IsTrue(File.Exists(filePath));

    }

    [TestMethod]
    public void AbleToLoadDeckListFromXml() {
      String filePath = "TestHelpers\\loadList.xml";
      Deck deck = new Deck();
      deck.Commander = new CommanderCard() { Name = "My Commander" };
      deck.AddCard(new Card() { Name = "Basic Card One" });
      deck.AddCard(new Card() { Name = "Basic Card Two" });

      DeckLibrary library = sut.LoadDeckLibrary(filePath);
      Assert.AreEqual(1, library.Decks.Count);
      Assert.AreEqual("My Commander", library.Decks[0].Commander.Name);

    }

  }
}