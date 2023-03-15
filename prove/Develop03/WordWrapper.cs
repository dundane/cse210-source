using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class WordWrapper {
    private string wordText = "";
    private int wordIndex;
    public WordWrapper() { }
    public WordWrapper(int wordIndex, string text, bool hidden) {
      this.wordText = text;
      this.Hidden = hidden;
      this.wordIndex = wordIndex;
    }

   public  String Text { 
      get { return wordText; } 
      set { wordText = value; } 
    }

    public bool Hidden { get; set; }

    public int WordIndex { 
      get { return wordIndex;}
      set {
        wordIndex = value;
      }
    }

    public void Hide() {
      Hidden = true;
    }
  }
}
