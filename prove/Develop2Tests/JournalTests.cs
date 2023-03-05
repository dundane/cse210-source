using Develop02;

namespace Develop2Tests {
  [TestClass]
  public class JournalTests {
    public Journal sut;

    [TestInitialize]
    public void Initialize() {
      sut = new Journal();
    }


    [TestMethod]
    public void AbleToAddAnEntryToAJournal() {
      //arrange
      string date = DateTime.Now.ToShortDateString();
      string prompt = "prompt";
      string journalEntry = "Journal Entry";
      Entry entryToAdd = new Entry(date, prompt, journalEntry);

      //Act
      sut.AddJournalEntry(entryToAdd);

      //assert
      Assert.AreEqual(entryToAdd.Prompt, sut.JournalEntries[0].Prompt);
    }

    [TestMethod]
    public void AbleToStoreJournalEntriesInXmlFile() {
      string fileNameGuid = Guid.NewGuid().ToString();
      string fileName = $"TestHelpers\\{fileNameGuid}.xml";
      string date = DateTime.Now.ToShortDateString();
      string prompt = "prompt";
      string journalEntry = "Journal Entry";
      Entry entryToAdd = new Entry(date, prompt, journalEntry);
      string date2 = DateTime.Now.ToShortDateString() + "Two";
      string prompt2 = "prompt Two";
      string journalEntry2 = "Journal Entry Two";
      Entry entryToAdd2 = new Entry(date2, prompt2, journalEntry2);
      sut.AddJournalEntry(entryToAdd);
      sut.AddJournalEntry(entryToAdd2);

      sut.SaveEntries(fileName);

      Assert.IsTrue(File.Exists(fileName));
      File.Delete(fileName);
    }

    [TestMethod]
    public void AbleTLoadJournalEntriesInXmlFile() {
      string fileName = "TestHelpers\\JournalEntriesX.xml";

      sut.LoadEntries(fileName);

      Assert.IsTrue(sut.JournalEntries.Count == 2);

      File.Delete(fileName);
    }

    [TestMethod]
    public void AbleToReturnFomattedJournalText() {
      string date = DateTime.Now.ToShortDateString();
      string prompt = "prompt";
      string journalEntry = "Journal Entry";
      Entry entryToAdd = new Entry(date, prompt, journalEntry);
      string date2 = DateTime.Now.ToShortDateString() + "Two";
      string prompt2 = "prompt Two";
      string journalEntry2 = "Journal Entry Two";
      Entry entryToAdd2 = new Entry(date2, prompt2, journalEntry2);
      sut.AddJournalEntry(entryToAdd);
      sut.AddJournalEntry(entryToAdd2);

      string formattedJournal = sut.GetFormattedJournal();

      Assert.IsTrue(formattedJournal.Contains(date));
      Assert.IsTrue(formattedJournal.Contains(prompt));
      Assert.IsTrue(formattedJournal.Contains(journalEntry));
      Assert.IsTrue(formattedJournal.Contains(date2));
      Assert.IsTrue(formattedJournal.Contains(journalEntry2));
      Assert.IsTrue(formattedJournal.Contains(prompt2));
    }

  }
}