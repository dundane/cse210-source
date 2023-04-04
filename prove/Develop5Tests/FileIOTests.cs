using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class FileIOTests {

    private FileIO sut;

    [TestInitialize]
    public void Initialize() {
      sut = new FileIO();
    }

    [TestMethod]
    public void AbleToStoreAListOfGoals() {
      FileIO fileIO = new FileIO();
      GoalManager goalManager = new GoalManager(fileIO);

      goalManager.Goals.Add(new Goal("Goal One", "Description One", 1));
      goalManager.Goals.Add(new Goal("Goal Two", "Description Two", 2));
      goalManager.Goals.Add(new Goal("Goal Three", "Description Three", 3));

      sut.SaveGoalList("goals.xml", goalManager.Goals);

      Assert.IsTrue(File.Exists("goals.xml"));

    }

    [TestMethod]
    public void AbleToLoadAListOfGoals() {

      List<Goal> loadedGoals =  sut.LoadGoalList("TestHelperFiles\\testGoals.xml");

      Assert.IsTrue(loadedGoals.Count == 3);

    }


    [TestMethod]
    public void AbleToStoreAListOfAllGoalTypes() {
      FileIO fileIO = new FileIO();
      GoalManager goalManager = new GoalManager(fileIO);

      goalManager.Goals.Add(new Goal("Goal One", "Description One", 1));
      goalManager.Goals.Add(new EternalGoal("Goal Two", "Description Two", 2));
      goalManager.Goals.Add(new ChecklistGoal("Goal Three", "Description Three", 3, 5, 100));

      sut.SaveGoalList("allgoals.xml", goalManager.Goals);

      Assert.IsTrue(File.Exists("allgoals.xml"));

    }


    [TestMethod]
    public void AbleToLoadAListOfAllGoalTypes() {

      List<Goal> loadedGoals = sut.LoadGoalList("TestHelperFiles\\allgoals.xml");

      Assert.IsInstanceOfType(loadedGoals[0], typeof(Goal));
      Assert.IsInstanceOfType(loadedGoals[1], typeof(EternalGoal));
      Assert.IsInstanceOfType(loadedGoals[2], typeof(ChecklistGoal));
      Assert.IsNotInstanceOfType(loadedGoals[2], typeof(EternalGoal));

    }

  }
}