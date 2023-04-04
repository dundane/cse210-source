using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class UIClassTests {

    private UIClass sut;

    [TestInitialize]
    public void Initialize() {
      sut = new UIClass();
    }
    [TestMethod]
    public void AbleToCreateMenu() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(!String.IsNullOrEmpty(menuResult));
    }

    [TestMethod]
    public void HaveAMenuItemToLoadScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Load Goals"));
    }

    [TestMethod]
    public void HaveAMenuItemToDisplayScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("List Goals"));
    }

    [TestMethod]
    public void HaveAMenuItemToAddANewScripture() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Add New Goal"));
    }

    [TestMethod]
    public void HasAMenuItemToSelectAScriptureToPractice() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Complete Goal"));
    }

    [TestMethod]
    public void HaveAMenuItemToSaveScriptures() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Save Goals"));
    }

    [TestMethod]
    public void HaveAMenuItemToExitProgram() {
      string menuResult = sut.FormatMenu();
      Assert.IsTrue(menuResult.Contains("Exit"));
    }

    [TestMethod]
    public void GoalTypeMenuHasSimpleGoal() {
      string menuResult = sut.FormatGoalTypeMenu();
      Assert.IsTrue(menuResult.Contains("Simple Goal"));
    }

    [TestMethod]
    public void GoalTypeMenuHasEternalGoal() {
      string menuResult = sut.FormatGoalTypeMenu();
      Assert.IsTrue(menuResult.Contains("Eternal Goal"));
    }

    [TestMethod]
    public void GoalTypeMenuHasChecklistGoal() {
      string menuResult = sut.FormatGoalTypeMenu();
      Assert.IsTrue(menuResult.Contains("Checklist Goal"));
    }

  }
}