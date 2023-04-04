using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class GoalTests {

    private Goal sut;

    [TestInitialize]
    public void Initialize() {
      sut = new Goal("SimpleGoal", "This is a simple goal.", 10);
    }

    [TestMethod]
    public void GoalsHaveAName() {
      sut.Name = "My Goal";
      string goalName = sut.Name;

      Assert.AreEqual("My Goal", goalName);
    }

    [TestMethod]
    public void GoalsHaveADescription() {
      sut.Description = "My Goal Description";
      string goalDescription = sut.Description;

      Assert.AreEqual("My Goal Description", goalDescription);
    }

    [TestMethod]
    public void GoalsHaveAPointValue() {
      sut.PointValue = 10;
      int goalPointValue = sut.PointValue;

      Assert.AreEqual(10, goalPointValue);
    }

    [TestMethod]
    public void GoalsHaveCompletionCount() {
      sut.CompletionCount = 10;
      int count = sut.CompletionCount;

      Assert.AreEqual(10, count);
    }


    [TestMethod]
    public void GoalsCanComplete() {
      sut.PointValue = 10;
      sut.Complete();

      Assert.IsTrue(sut.LastCompleteDate > DateTime.Now.Subtract(new TimeSpan(0, 0, 10)));
      Assert.AreEqual(1, sut.CompletionCount);
    }

    [TestMethod]
    public void GoalKnowsHowToCalculateItsValue() {
      sut.PointValue = 10;
      sut.Complete();
      int pointValue = sut.CalculatePoints();

      Assert.AreEqual(10, pointValue);
    }


  }
}