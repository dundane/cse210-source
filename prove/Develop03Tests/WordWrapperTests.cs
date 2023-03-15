using Develop03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03Tests {
  [TestClass]
  public class WordWrapperTests {
    WordWrapper sut;
    [TestInitialize] 
    public void Initilize() {
      sut = new WordWrapper(-1,"foo", false);
    }

    [TestMethod]
    public void WordWrapperContainsAWordText() {
      Assert.AreEqual("foo", sut.Text);
      Assert.IsInstanceOfType(sut.Text, typeof(string));
    }

    [TestMethod]
    public void WordWrapperIndicatesIfWordIsHidden() {
      Assert.IsFalse(sut.Hidden);
      Assert.IsInstanceOfType(sut.Hidden, typeof(bool));
    }

    [TestMethod]
    public void CanMarkWordAsHidden() {
      sut.Hide();
      Assert.IsTrue(sut.Hidden);
    }

    [TestMethod]
    public void WordHasAnOrderForThisWord() {
      sut.Hide();
      Assert.IsTrue(sut.Hidden);
    }
  }
}
