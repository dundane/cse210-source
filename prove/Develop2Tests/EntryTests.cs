using Develop02;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop2Tests {
  [TestClass]
  public class EntryTests {
    private Entry sut; 
    [TestInitialize]
    public void Initialize() { 
      sut= new Entry();
    }

    [TestMethod]
    public void EntryCanBeInstantiatedWithDatePromptAndJournalEntry() {
      string date = DateTime.Now.ToShortDateString();
      string prompt = "prompt";
      string journalEntry = "Journal Entry";

      sut = new Entry(date, prompt, journalEntry);

      Assert.IsNotNull(sut);
      Assert.AreEqual(date, sut.Date);
      Assert.AreEqual(prompt, sut.Prompt);
      Assert.AreEqual(journalEntry, sut.JournalEntry);
    }

    [TestMethod]
    public void EntryCanFormatItselfForDisplay() {
      string date = DateTime.Now.ToShortDateString();
      string prompt = "prompt";
      string journalEntry = "Journal Entry";
      sut = new Entry(date, prompt, journalEntry);

      string displayString = sut.FormatForDisplay();

      Assert.IsTrue(displayString.Contains(date));
      Assert.IsTrue(displayString.Contains(prompt));
      Assert.IsTrue(displayString.Contains(journalEntry));

    }

  }
}
