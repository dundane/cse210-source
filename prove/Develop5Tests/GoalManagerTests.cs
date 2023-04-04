using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class GoalManagerTests {

    private GoalManager sut;

    [TestInitialize]
    public void Initialize() {
      FileIO fileIO = new FileIO();
      sut = new GoalManager(fileIO);
    }

    [TestMethod]
    public void GoalManagerContainsAListOfGoals() {

      List<Goal> goals = sut.Goals;
      Assert.IsNotNull(goals);
    }

    [TestMethod]
    public void YouCanAddAGoalToTheGoalManager() {
      Goal myGoal = new Goal();
      sut.Goals.Add(myGoal);
      Assert.IsTrue(sut.Goals.Contains(myGoal));
    }

    [TestMethod]
    public void CanFormatListOfGoalsForDisplay() {
      sut.Goals.Add(new Goal() { Name = "Goal One" });
      sut.Goals.Add(new Goal() { Name = "Goal Two" });
      sut.Goals.Add(new Goal() { Name = "Goal Three" });

      String displayText = sut.FormatGoalsListForDisplay();

      Assert.IsTrue(displayText.Contains("Goal One"));
      Assert.IsTrue(displayText.Contains("Goal Two"));
      Assert.IsTrue(displayText.Contains("Goal Three"));
    }

    [TestMethod]
    public void GoalManagerCanMarkGoalAsComplete() {
      sut.Goals.Add(new Goal() { Name = "Goal One" });
      sut.Goals.Add(new Goal() { Name = "Goal Two" });
      sut.Goals.Add(new Goal() { Name = "Goal Three" });

      sut.CompleteGoal(1);
      Assert.IsTrue(sut.Goals[1].LastCompleteDate > DateTime.Now.Subtract(new TimeSpan(0, 0, 10)));
    }

    [TestMethod]
    public void AbleToSaveTheGoalLIstInManager() {

      sut.SaveGoals("goalManagerGoals.xml");

      Assert.IsTrue(File.Exists("goalManagerGoals.xml"));

    }

    [TestMethod]
    public void AbleToLoadTheGoalLIstInManager() {

      sut.LoadGoals("TestHelperFiles\\testGoals.xml");

      Assert.IsTrue(sut.Goals.Count == 3);

    }


  }
}
