using FinalProject.Business;
using FinalProject.UI;

namespace FinalProjectTests {
  [TestClass]
  public class UIDisplayTests {

    UIDisplay sut;

    [TestInitialize] public void Inititialize() {
      sut = new UIDisplay();
    }


    [TestMethod]
    public void AbleToCreateMenu() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(!String.IsNullOrEmpty(menuResult));
    }

    [TestMethod]
    public void HaveAMenuItemToLoadDeckLibrary() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Load Deck Library"));
    }

    [TestMethod]
    public void HaveAMenuItemToChooseActivity() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Choose Activity"));
    }

    [TestMethod]
    public void HaveAMenuItemToCreateDeck() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Create Deck"));
    }

    [TestMethod]
    public void HasAMenuItemToFindADeck() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Select A Deck"));
    }

    [TestMethod]
    public void HaveAMenuItemToSaveDeckLibrary() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Save Deck Library"));
    }

    [TestMethod]
    public void HaveAMenuItemToExitProgram() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Exit"));
    }

    [TestMethod]
    public void GoalTypeMenuHasManaCurve() {
      string menuResult = sut.FormatActivityTypeMenu();
      Assert.IsTrue(menuResult.Contains("Mana Curve"));
    }

    [TestMethod]
    public void GoalTypeMenuHasCardCompare() {
      string menuResult = sut.FormatActivityTypeMenu();
      Assert.IsTrue(menuResult.Contains("Card Compare"));
    }
  }
}