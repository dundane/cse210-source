

using Develop03;

namespace Develop03Tests {
  [TestClass]
  public class ReferenceTests {
    Reference sut;
    [TestInitialize] 
    public void Initialize() { 
      sut= new Reference("Book", "Chapter", 2);
    }

    [TestMethod]
    public void ReferenceContainsBookName() {

      Assert.AreEqual("Book", sut.Book);
      Assert.IsInstanceOfType(sut.Book, typeof(string));
    }

    [TestMethod]
    public void ReferenceContainsChapterName() {

      Assert.AreEqual("Chapter", sut.Chapter);
      Assert.IsInstanceOfType(sut.Chapter, typeof(string));
    }

    [TestMethod]
    public void ReferenceContainsVerseName() {

      Assert.AreEqual(2, sut.Verse);
      Assert.IsInstanceOfType(sut.Verse, typeof(int));
    }
  }
}
