using FinalProject.Business;

namespace FinalProjectTests {
  [TestClass]
  public class CardTests {

    Card sut;
    [TestInitialize]
    public void Initialize() {
      sut = new Card();
    }

    [TestMethod]
    public void CardContainsListOfKeywords() {
    }
  }
}