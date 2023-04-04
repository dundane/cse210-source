using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class EternalGoalTests{

    private EternalGoal sut;

    [TestInitialize]
    public void Initialize() {
      sut = new EternalGoal("EternalGoal", "This is an eternal goal.", 5);
    }

    [TestMethod]
    public void EternalGoalIsDerivedFromGoal() {
      Assert.IsInstanceOfType(sut, typeof(Goal));
    }


  }
}