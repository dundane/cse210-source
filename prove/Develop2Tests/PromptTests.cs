using Develop02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop2Tests {
  [TestClass]
  public class PromptTests {

    Prompts sut;
    string promptsFile = "TestHelpers\\prompts.txt";

    [TestInitialize]
    public void Initialize() {
      sut = new Prompts();
    }

    [TestMethod]
    public void AbleToLoadAListOfPrompts() {

      sut.LoadProptsFile(promptsFile);

      Assert.IsTrue(sut.PromptList.Count > 0);

    }

    [TestMethod]
    public void AbleToGetARandomPrompt() {

      sut.LoadProptsFile(promptsFile);

      string returnedPrompt = sut.GetRandomWritingPrompt();

      Assert.IsTrue(sut.PromptList.Contains(returnedPrompt));

    }

  }
}
