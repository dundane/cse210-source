using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class Reference {
    private string book = string.Empty;
    private string chapter = string.Empty;
    private int verse = -1;
    public Reference() { }

    public Reference(string book, string chapter, int verse) {
      this.book = book;
      this.chapter = chapter;
      this.verse = verse;
    }

    public string Book { get { return book; } set { book = value; } }
    public string Chapter { get { return chapter; } set { chapter = value; } }
    public int Verse { get { return verse; } set {  verse = value; } }

  }
}
