using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03 {
  public class MemorizationHelper {
    public void HideWords(Scripture scripture, int numberOfWordsToHide = 5) {
      Random random = new Random();
      for (int hideCount = 0; hideCount < numberOfWordsToHide; hideCount++) {
        int verse = random.Next(scripture.Verses.Count);
        int word = random.Next(scripture.Verses[verse].Words.Count);
        scripture.Verses[verse].Words[word].Hide();
      }
    }
  }
}
