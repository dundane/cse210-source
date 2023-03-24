using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04 {
  public class ReflectionActivity : ActivityBase {
    private int durrationBetweenPrompts;
    private Prompts primaryPrompts;
    private Prompts secondaryPrompts;
    public ReflectionActivity(int durationSeconds, int durrationBetweenPrompts) : base(durationSeconds) {
      this.durrationBetweenPrompts = durrationBetweenPrompts;
      primaryPrompts = new Prompts("Data\\reflectionPromptsPrimary.txt");
      secondaryPrompts = new Prompts("Data\\reflectionPromptsSecondary.txt");
      ActivityType = "Reflection";
      Description = $"This activity will help you reflect on good and bad times in your life then follows up to prompt addition insight.\nThis will allow you to be introspective about many aspects of your life.";
    }

    public int DurationBetweenPrompts { get { return durrationBetweenPrompts; } set { durrationBetweenPrompts=value; } }

    public Prompts PrimaryPrompt { get { return primaryPrompts; } }
    public Prompts SecondaryPrompt { get { return secondaryPrompts; } }

  }
}
