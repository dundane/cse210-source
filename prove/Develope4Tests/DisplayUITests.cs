using Develop04;


namespace Develop04Tests {
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
    public void HaveAMenuItemToStartListingActivity() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Start Listing Activity"));
    }

    [TestMethod]
    public void HasAMenuItemToStartReflectionActivity() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Start Reflection Activity"));
    }

    [TestMethod]
    public void HaveAMenuItemStartBreathingExcercise() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Start Breathing Excercise"));
    }

    [TestMethod]
    public void HaveAMenuItemToExitProgram() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Exit"));
    }

  }
}
