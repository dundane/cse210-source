using System;

class Program
{
    static void Main(string[] args)
    {
        bool ableToParseGradeValue = false;
        double parsedGradeValue = 0;
        string enteredGradeValue = "";
        while (!ableToParseGradeValue)
        {
            Console.Write("What is your numeric grade value ? : ");
            enteredGradeValue = Console.ReadLine();

            ableToParseGradeValue = double.TryParse(enteredGradeValue, out parsedGradeValue);
            if (!ableToParseGradeValue)
            {
                Console.WriteLine("The value you entered is not a numeric value please try again.");
            }
        }
        Console.WriteLine($"Your entered numeric grade value {enteredGradeValue.ToString()} is a {GetGradeLetterFromNumericValue(parsedGradeValue)}");
    }

    static string GetPlusOrMinusInidicator(double numericGradeValue)
    {
        double onesRemainder = numericGradeValue % 10;
        string plusOrMinusIndicator = "";
        if (onesRemainder >= 7)
        {
            if (numericGradeValue < 90)
            {
                plusOrMinusIndicator = "+";
            }
        }

        if (onesRemainder < 3)
        {
            plusOrMinusIndicator = "-";

        }
        return plusOrMinusIndicator;
    }

    static string GetGradeLetterFromNumericValue(double numericGradeValue)
    {

        if (numericGradeValue >= 90)
        {
            return "A" + GetPlusOrMinusInidicator(numericGradeValue);
        }
        if (numericGradeValue >= 80)
        {
            return "B" + GetPlusOrMinusInidicator(numericGradeValue);
        }
        if (numericGradeValue >= 70)
        {
            return "C" + GetPlusOrMinusInidicator(numericGradeValue);
        }
        if (numericGradeValue >= 60)
        {
            return "D" + GetPlusOrMinusInidicator(numericGradeValue);
        }
        return "F";
    }

}