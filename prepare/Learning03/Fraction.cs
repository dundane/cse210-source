using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning03 {
  public class Fraction {
    private int topOfFraction = 1;
    private int bottomOfFraction = 1;

    public Fraction() { 
      topOfFraction = 1;
      bottomOfFraction = 1;
    }
    public Fraction(int wholeNumber) { 
      topOfFraction= wholeNumber;
      bottomOfFraction = 1;
    }
    public Fraction(int topNumber, int bottomNumber) {
      this.topOfFraction = topNumber;
      this.bottomOfFraction = bottomNumber;
    }

    public int GetTopNumber() {
      return topOfFraction;
    }

    public int GetBottomNumber() {  
      return bottomOfFraction;
    }

    public void SetTopNumber(int topNumber) {
      topOfFraction = topNumber;
    }

    public void SetBottomNumber(int bottomNumber) { 
      bottomOfFraction = bottomNumber;
    }

    public string GetFractionString() {
      return $"{topOfFraction}/{bottomOfFraction}";
    }

    public double GetDecimalValue() { 
      return Convert.ToDouble(topOfFraction)/Convert.ToDouble(bottomOfFraction);
    }

  }
}
