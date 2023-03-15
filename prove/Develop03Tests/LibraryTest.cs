using Develop03;

namespace Develop03Tests {
  [TestClass]
  public class LibraryTest {
    Library sut;

    [TestInitialize] 
    public void Initialize() { 
      sut = new Library();
    }

    [TestMethod]
    public void HasAListOfScriptures() {
      List<Scripture> scriptures = sut.Scriptures;
      Assert.IsInstanceOfType(scriptures, typeof(List<Scripture>));
    }

    [TestMethod] 
    public void AbleToAddAScriptureToLibrary() {
      Scripture scriptureToAdd = new Scripture();

      sut.AddScripture(scriptureToAdd);
    }

    [TestMethod]
    public void AbleToStoreAListOfScriptures() {
      String fileName = "c:\\school\\testScriptures.xml";
      Scripture scripture = new Scripture();
      scripture.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      scripture.AddVerse("Logan", "5", 13, "Also do some other stuff");
      scripture.AddVerse("Logan", "5", 14, "Do all kinds of stuff");
      Scripture scriptureTwo = new Scripture();
      scriptureTwo.AddVerse("Bryce", "7", 13, "For the emporor");

      sut.AddScripture(scripture);
      sut.AddScripture(scriptureTwo);

      sut.SaveScriptures(fileName);

      Assert.IsTrue(File.Exists(fileName));

    }

    [TestMethod]
    public void AbleToLoadAListOfScriptures() {
      String fileName = "TestHelpers\\testScriptures.xml";

      sut = Library.LoadScriptures(fileName);

      Assert.AreEqual(2, sut.Scriptures.Count());

    }

    [TestMethod]
    public void AbleToSetCurrentScriptureIndex() {
      String fileName = "c:\\school\\testScriptures.xml";
      Scripture scripture = new Scripture();
      scripture.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      scripture.AddVerse("Logan", "5", 13, "Also do some other stuff");
      scripture.AddVerse("Logan", "5", 14, "Do all kinds of stuff");
      Scripture scriptureTwo = new Scripture();
      scriptureTwo.AddVerse("Bryce", "7", 13, "For the emporor");

      sut.AddScripture(scripture);
      sut.AddScripture(scriptureTwo);

      Scripture currentScripture = sut.SetCurrentScripture(1);

      Assert.AreEqual(currentScripture.FormatScriptureForDisplay(), scriptureTwo.FormatScriptureForDisplay());

    }

    [TestMethod]
    public void AbleToGetCurrentScripture() {
      String fileName = "c:\\school\\testScriptures.xml";
      Scripture scripture = new Scripture();
      scripture.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      scripture.AddVerse("Logan", "5", 13, "Also do some other stuff");
      scripture.AddVerse("Logan", "5", 14, "Do all kinds of stuff");
      Scripture scriptureTwo = new Scripture();
      scriptureTwo.AddVerse("Bryce", "7", 13, "For the emporor");

      sut.AddScripture(scripture);
      sut.AddScripture(scriptureTwo);

      sut.SetCurrentScripture(1);
      Scripture currentScripture = sut.GetCurrentScripture();

      Assert.AreEqual(currentScripture.FormatScriptureForDisplay(), scriptureTwo.FormatScriptureForDisplay());

    }

  }
}