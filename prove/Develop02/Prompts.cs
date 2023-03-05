﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop02 {
  public class Prompts {
    private List<string> promptList;
    public Prompts() { 
      promptList = new List<string>();
    }

    public void LoadProptsFile(string promptsFile) {
      if(File.Exists(promptsFile)) {
        using (FileStream filestream = File.OpenRead(promptsFile)) {
          using (StreamReader reader = new StreamReader(filestream)) {
            while (!reader.EndOfStream) {

              promptList.Add(reader.ReadLine());
            }
          }
        }
      }
    }

    public string GetRandomWritingPrompt() {
      if(promptList!= null && promptList.Count > 0) {
        Random random = new Random(DateTime.Now.Millisecond);
        return PromptList[random.Next(promptList.Count)];
      }
      return "What was the highlight of your day?";
    }

    public List<string> PromptList { get { return promptList; } }

  }
}
