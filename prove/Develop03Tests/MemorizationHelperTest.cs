using Develop03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03Tests {
  [TestClass]
  public class MemorizationHelperTest {
    MemorizationHelper sut;
    [TestInitialize] 
    public void Initialize() {
      sut = new MemorizationHelper();
    }

    [TestMethod]
    public void AbleToHide5ItemsInAScripture() { 
      Scripture scripture = new Scripture();
      scripture.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      scripture.AddVerse("Logan", "5", 13, "Also do some other stuff");
      scripture.AddVerse("Logan", "5", 14, "Do all kinds of stuff");

      sut.HideWords(scripture);

      Assert.IsTrue(scripture.FormatScriptureForDisplay().Count(x=> x == '*') > 4);

    }

    [TestMethod]
    public void AbleToHideNItemsInAScripture() {
      Scripture scripture = new Scripture();
      scripture.AddVerse("Logan", "5", 12, "Do the stuff with the things");
      scripture.AddVerse("Logan", "5", 13, "Also do some other stuff");
      scripture.AddVerse("Logan", "5", 14, "Do all kinds of stuff");

      sut.HideWords(scripture, 10);

      Assert.IsTrue(scripture.FormatScriptureForDisplay().Count(x => x == '*') > 4);

    }
  }
}
