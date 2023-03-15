using Develop03;

namespace Develop03Tests {
  [TestClass]
  public class VerseTests {

    Verse sut;
    [TestInitialize]
    public void Initialize() {
      Reference verseReference = new Reference("Jared", "1", 14);
      sut = new Verse("Original Text", verseReference);
    }

    [TestMethod]
    public void VerseHasOriginalText() {
      Assert.AreEqual("Original Text", sut.OriginalText);
    }

    [TestMethod]
    public void VearseCanParseOriginalTextInToWords() { 
      Assert.AreEqual(2, sut.Words.Count);
      Assert.AreEqual("Original", sut.Words[0].Text);
      Assert.AreEqual("Text", sut.Words[1].Text);
    }

    [TestMethod]
    public void VerseCanFormatWordsInToAssembledVerse() {
      string returnedText = sut.FormatNewTextForDisplay();
      Assert.AreEqual(sut.OriginalText,returnedText );
    }

    [TestMethod]
    public void CanFormatVerseWithHiddentText() {
      sut.Words[0].Hide();
      string returnedText = sut.FormatNewTextForDisplay();
      Assert.AreEqual("******** Text", returnedText);
    }

    [TestMethod]
    public void VerseContainsAReference() {

      Assert.AreEqual("Jared", sut.Reference.Book);
      Assert.AreEqual("1", sut.Reference.Chapter);
      Assert.AreEqual(14, sut.Reference.Verse);
    }

    [TestMethod]
    public void WeCanBuildAVerseByPassingInReferenceDetials() {

      sut = new Verse("Tiffany", "3", 1, "Thou shalt obey your mother.");

      Assert.AreEqual("Tiffany", sut.Reference.Book);
      Assert.AreEqual("3", sut.Reference.Chapter);
      Assert.AreEqual(1, sut.Reference.Verse);
    }


  }
}
