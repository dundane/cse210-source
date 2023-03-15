using Develop03;

namespace Develop03Tests {
  [TestClass]
  public class ScriptureTests {

    Scripture sut;
    [TestInitialize]
    public void Initialize() {
      sut = new Scripture();
    }

    [TestMethod]
    public void WeCanAddAVerseToToAScriptureWithAttributes() {
      sut.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      Assert.AreEqual("Logan", sut.Verses[0].Reference.Book);
      Assert.AreEqual("5", sut.Verses[0].Reference.Chapter);
      Assert.AreEqual(12, sut.Verses[0].Reference.Verse);
      Assert.AreEqual("Do the stuff with the things", sut.Verses[0].OriginalText);
    }

    [TestMethod]
    public void WeCanAddAVerseToToAScriptureByJustAVerse() {
      Verse verseToAdd = new Verse("Bryce", "7", 13, "For the emporor");

      sut.AddVerse(verseToAdd);

      Assert.AreEqual("Bryce", sut.Verses[0].Reference.Book);
      Assert.AreEqual("7", sut.Verses[0].Reference.Chapter);
      Assert.AreEqual(13, sut.Verses[0].Reference.Verse);
      Assert.AreEqual("For the emporor", sut.Verses[0].OriginalText);
    }

    [TestMethod]
    public void CanCalculateTheReferenceSingleVerse() {
      sut.AddVerse("Logan", "5", 12, "Do the stuff with the things");

      String returnedReference = sut.FormatRefrenceForDisplay();

      Assert.AreEqual("Logan 5:12", returnedReference);
    }

    [TestMethod]
    public void CanCalculateTheReferenceTwoVersesConsecutive() {
      sut.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      sut.AddVerse("Logan", "5", 13, "Also do some other stuff");

      String returnedReference = sut.FormatRefrenceForDisplay();

      Assert.AreEqual("Logan 5:12-13", returnedReference);
    }

    [TestMethod]
    public void CanCalculateTheReferenceThreeVersesConsecutive() {
      sut.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      sut.AddVerse("Logan", "5", 13, "Also do some other stuff");
      sut.AddVerse("Logan", "5", 14, "Do all kinds of stuff");

      String returnedReference = sut.FormatRefrenceForDisplay();

      Assert.AreEqual("Logan 5:12-14", returnedReference);
    }
    [TestMethod]
    public void CanDisplayThreeConsecutiveVerses() {
      sut.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      sut.AddVerse("Logan", "5", 13, "Also do some other stuff");
      sut.AddVerse("Logan", "5", 14, "Do all kinds of stuff");

      String returnedText = sut.FormatScriptureForDisplay();

      Assert.IsTrue(returnedText.StartsWith("12. Do the stuff"));
      Assert.IsTrue(returnedText.Trim().EndsWith("14. Do all kinds of stuff"));
    }

  }
}
