using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05 {
  public class Scoreboard {

    List<Goal> results;
    FileIO fileIo;
    private string scoreboardFilePath = "";
    public Scoreboard(FileIO fileIo, String scoreboardPath = "Data\\completeGoals.xml") { 
      this.fileIo = fileIo;
      scoreboardFilePath = scoreboardPath;
      results = new List<Goal>();
    }
    public int CalculateScore() {
      int score = 0;
      foreach (Goal result in results) { 
        score += result.PointValue;
      }
      return score;
    }

    public void SaveGoals() {
      fileIo.SaveGoalList(scoreboardFilePath, results);
    }

    public void LoadGoals() {
      results = fileIo.LoadGoalList(scoreboardFilePath);
    }

    public List<Goal> Results { get { return results; } }
  }
}
