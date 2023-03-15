using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class Verse {
    private string originalText;
    private string hiddenPlaceholder = "**************************************************";
    private Reference reference;
    private List<WordWrapper> words = new List<WordWrapper>();

    public Verse() {
    }
    public Verse(string originalText, Reference reference) {
      this.originalText = originalText;
      this.reference = reference;
      words = new List<WordWrapper>();
      ParseOriginalText();
    }

    public Verse(string verseBook, string verseChapter, int verseNumber, string originalText) {
      reference = new Reference(verseBook, verseChapter, verseNumber);
      this.originalText = originalText;
      this.words = new List<WordWrapper>();
      ParseOriginalText();
    }

    public string OriginalText { get { return originalText; } set { originalText = value; } }

    public List<WordWrapper> Words {
      get {
        words.Sort(delegate (WordWrapper one, WordWrapper two) {
          return one.WordIndex.CompareTo(two.WordIndex);
        });
        return words;
      }
      set { words = value; }
    }

    public Reference Reference { get { return reference; } set { reference = value; } }

    public string FormatNewTextForDisplay() {
      StringBuilder stringBuilder = new StringBuilder();
      for (int wordIndex = 0; wordIndex < Words.Count; wordIndex++) {
        if (Words[wordIndex].Hidden) {
          stringBuilder.Append($" {hiddenPlaceholder.Substring(1, Words[wordIndex].Text.Length)}");
        } else {
          stringBuilder.Append($" {Words[wordIndex].Text}");
        }
      }
      return stringBuilder.ToString().Trim();
    }

    private void ParseOriginalText() {
      Words = new List<WordWrapper>();
      List<String> wordsFromText = originalText.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList<String>();
      for (int wordIndex = 0; wordIndex < wordsFromText.Count; wordIndex++) {
        Words.Add(new WordWrapper(wordIndex, wordsFromText[wordIndex], false));
      }
    }
  }
}
