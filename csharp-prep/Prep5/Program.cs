using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        decimal favoriteNumber = PromptUserNumber();
        decimal valueSquared = SquareNumber(favoriteNumber);
        DisplayResult(userName, valueSquared);
    }

    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName(){
        Console.Write("Please enter your name. : ");
        return Console.ReadLine();
    }

    static decimal PromptUserNumber(){
        bool isValidNumber = false;
        decimal parsedNumber = 0;
        while(!isValidNumber){
            Console.Write("Please enter your favorite number. : ");
            string enteredNumber = Console.ReadLine();
            isValidNumber = decimal.TryParse(enteredNumber, out parsedNumber);
            if(!isValidNumber){
                Console.WriteLine($"The value you entered \"{enteredNumber}\" is not a valid number.");
                Console.WriteLine("Please try again.");
            }
        }
        return parsedNumber;
    }

    static decimal SquareNumber(decimal valueToSquare){
        return valueToSquare * valueToSquare;
    }

    static void DisplayResult(string userName, decimal squaredNumber){
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber.ToString()}");
    }
}