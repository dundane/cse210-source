using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class Scripture {
    private List<Verse> verses;
    public Scripture() { 
      verses = new List<Verse>();
    }

    public List<Verse> Verses { get { return verses; } set { verses = value; } }

    public void AddVerse(string book, string chapter, int verse, string origionalText) {
      verses.Add(new Verse(book, chapter, verse, origionalText));
    }

    public void AddVerse(Verse verseToAdd) {
      verses.Add(verseToAdd);
    }

    public string FormatRefrenceForDisplay() {
      StringBuilder buildRefrence = new StringBuilder();
      buildRefrence.Append(Verses[0].Reference.Book);
      string startChapter = Verses[0].Reference.Chapter;
      string endChapter = Verses[0].Reference.Chapter;
      int startVerseNumber = Verses[0].Reference.Verse;
      int endVerseNumber = Verses[0].Reference.Verse;
      foreach (Verse verse in verses) {
        if (verse.Reference.Chapter != startChapter) {
          endChapter = verse.Reference.Chapter;
        }
        if (verse.Reference.Verse != endVerseNumber) {
          endVerseNumber = verse.Reference.Verse;
        }
      }
      buildRefrence.Append($" {startChapter}");

      if (startVerseNumber == endVerseNumber) {
        buildRefrence.Append($":{startVerseNumber.ToString()}");
      } else {
        buildRefrence.Append($":{startVerseNumber.ToString()}-{endVerseNumber.ToString()}");
      }
      return buildRefrence.ToString();
    }

    public string FormatScriptureForDisplay() {
      StringBuilder buildScripture = new StringBuilder();
      foreach (Verse verse in verses) {
        buildScripture.Append($"{verse.Reference.Verse.ToString()}. ");
        buildScripture.Append(verse.FormatNewTextForDisplay());
        buildScripture.Append('\n');
      }
      return buildScripture.ToString().Trim();
    }
  }
}
