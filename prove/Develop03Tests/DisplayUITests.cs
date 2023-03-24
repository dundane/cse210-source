using Develop03;


namespace Develop03Tests {
  [TestClass]
  public class DisplayUITests {

    DisplayUI sut;
    [TestInitialize]
    public void Initialize() {
      sut = new DisplayUI();
    }
    [TestMethod]
    public void AbleToCreateMenu() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(!String.IsNullOrEmpty(menuResult));
    }

    [TestMethod]
    public void HaveAMenuItemToLoadScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Load Scriptures"));
    }

    [TestMethod]
    public void HaveAMenuItemToDisplayScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Display Scriptures List"));
    }

    [TestMethod]
    public void HaveAMenuItemToAddANewScripture() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Add Scripture"));
    }

    [TestMethod]
    public void HasAMenuItemToSelectAScriptureToPractice() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Practice A Scripture"));
    }

    [TestMethod]
    public void HaveAMenuItemToSaveScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Save Scriptures"));
    }

    [TestMethod]
    public void HaveAMenuItemToExitProgram() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Save Scriptures"));
    }

  }
}
