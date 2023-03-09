using Learning03;
using System;

class Program {
  static void Main(string[] args) {
    Fraction constructorOne = new Fraction();
    Fraction constructorTwo = new Fraction(5);
    Fraction constructorThree = new Fraction(3, 4);
    Fraction constructorFour = new Fraction();
    constructorFour.SetTopNumber(1);
    constructorFour.SetBottomNumber(3);
    List<Fraction> fractions = new List<Fraction>() { constructorOne, constructorTwo, constructorThree, constructorFour };
    int listCounter = 0;
    foreach (Fraction fraction in fractions) {
      listCounter++;
      Console.WriteLine($"Constructor {listCounter} String: {fraction.GetFractionString()}");
      Console.WriteLine($"Constructor {listCounter} Decimal: {fraction.GetDecimalValue()}");
    }
  }
}