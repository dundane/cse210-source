using Develop05;

namespace Develop5Tests {
  [TestClass]
  public class ChecklistGoalTests {

    private ChecklistGoal sut;

    [TestInitialize] 
    public void Initialize() {
      sut = new ChecklistGoal("CheckListGoal", "This is a checklist goal.", 10, 5, 100);
    }

    [TestMethod]
    public void ChecklistGoalIsDerivedFromGoal() {

      Assert.IsInstanceOfType(sut, typeof(Goal));

    }

    [TestMethod]
    public void ChecklistGoalsHaveBonusCount() {
      sut.BonusCount = 10;
      int count = sut.BonusCount;

      Assert.AreEqual(10, count);
    }

    [TestMethod]
    public void ChecklistGoalsHaveBonusAward() {
      sut.BonusAward = 100;
      int award = sut.BonusAward;

      Assert.AreEqual(100, award);
    }

  }
}