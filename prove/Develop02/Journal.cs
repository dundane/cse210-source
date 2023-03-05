using System.Text;
using System.Xml.Serialization;

namespace Develop02 {
  public class Journal {

    private List<Entry> journalEntries;

    public Journal() {
      journalEntries = new List<Entry>();
    }

    public List<Entry> JournalEntries { get { return journalEntries; } }

    public void AddJournalEntry(Entry entryToAdd) {
      JournalEntries.Add(entryToAdd);
    }

    public string GetFormattedJournal() {
      StringBuilder journalText = new StringBuilder();
      foreach(Entry entry in JournalEntries) {
        journalText.AppendLine(entry.FormatForDisplay());
        journalText.AppendLine("");
      }
      return journalText.ToString();
    }

    public void LoadEntries(string fileName) {
      XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
      FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
      journalEntries = (List<Entry>)serializer.Deserialize(fileStream);
      fileStream.Close();
    }

    public void SaveEntries(string fileName) {
      XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
      FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
      serializer.Serialize(fileStream, JournalEntries);
      fileStream.Close();
    }
  }
}
