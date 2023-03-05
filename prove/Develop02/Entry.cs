using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop02 {
  public class Entry {

    public Entry() { }

    public Entry(string date, string prompt, string journalEntry) { 
      Date = date;
      Prompt = prompt;
      JournalEntry = journalEntry;
    }

    public string Date { get; set; }
    public string Prompt { get; set; }
    public string JournalEntry { get; set; }

    public string FormatForDisplay() {
      StringBuilder formattedEntry = new StringBuilder();
      formattedEntry.AppendLine($"Date : {Date}");
      formattedEntry.AppendLine($"Prompt : {Prompt}");
      formattedEntry.AppendLine(JournalEntry);

      return formattedEntry.ToString();
    }
  }
}
