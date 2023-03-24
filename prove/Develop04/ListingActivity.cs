using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Develop04 {
  public class ListingActivity : ActivityBase {

    private List<Tuple<string,string>> answers;
    private Prompts promptList;

    public ListingActivity(int durationSeconds) : base(durationSeconds) {
      answers = new List<Tuple<string, string>>();
      promptList = new Prompts("Data\\listingPrompts.txt");
      ActivityType = "Listing";
      Description = $"This activity will help you reflect on people and things that are important in your life.\nFor each prompt list as many answers as possible in the alloted time.";
    }

    public void AddAnswer(string prompt, string answer) {
      answers.Add(new Tuple<string, string>(prompt, answer));
    }

    public String FormatResultsForDisplay() { 
      StringBuilder results = new StringBuilder();
      List<string> prompts = answers.Select(x => x.Item1).Distinct().ToList();
      foreach(string prompt in prompts) {
        results.AppendLine($"{prompt}\n");
        List<Tuple<string,string>> responses = answers.Where(x => x.Item1 == prompt).ToList();
        foreach (Tuple<string, string> response in responses) {
          results.AppendLine($"  -{response.Item2}\n");
        }
      }
      return results.ToString();
    }

    public Prompts PromptList { get { return promptList; } }

  }
}
