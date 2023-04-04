using Develop05;
using System.Runtime.InteropServices;

namespace Develop5Tests {
  [TestClass]
  public class ScoreboardTests {

    private Scoreboard sut;

    [TestInitialize]
    public void Initialize() {
      FileIO fileIo = new FileIO();
      sut = new Scoreboard(fileIo);
    }

    [TestMethod]
    public void ScorboardIsAbleToCalculateTheUserScoreOf2() {
      Goal goal = new Goal();
      goal.PointValue = 1;
      Goal goal2 = new Goal();
      goal2.PointValue = 1;
      sut.Results.Add(goal);
      sut.Results.Add(goal2);
      int score = sut.CalculateScore();
      Assert.AreEqual(2, score);
    }

    [TestMethod]
    public void AbleToCalculateScoreFromARegularGoal() {
      Goal goal = new Goal();
      goal.PointValue = 1;
      sut.Results.Add(goal);
      int score = sut.CalculateScore();
      Assert.AreEqual(1, score);
    }

    [TestMethod]
    public void AbleToSaveTheGoalLIstInScoreBoard() {

      sut.SaveGoals();

      Assert.IsTrue(File.Exists("goalScoreboardGoals.xml"));

    }

    [TestMethod]
    public void AbleToLoadTheGoalLIstInScoreBoard() {

      sut.LoadGoals();

      Assert.AreEqual(6, sut.CalculateScore());

    }

  }
}