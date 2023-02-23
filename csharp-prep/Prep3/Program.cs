using System;

class Program
{
    static void Main(string[] args)
    {
        string continuePlaying = "";
        do
        {
            Random getRandomNumber = new Random(DateTime.Now.Millisecond);
            int magicNumber = getRandomNumber.Next(1, 100);
            int currentGuessInteger = -1;
            int guessCount = 0;
            while (currentGuessInteger != magicNumber)
            {
                guessCount++;
                Console.WriteLine($"This is guess number {guessCount.ToString()}");
                Console.Write("What is your guess between 1 and 100 (no decimals) : ");
                string currentGuess = Console.ReadLine();

                bool validGuess = int.TryParse(currentGuess, out currentGuessInteger);
                if (validGuess)
                {
                    if (currentGuessInteger > magicNumber)
                    {
                        Console.WriteLine($"Nope you guess of {currentGuess} is too high! Try again.");
                    }
                    if (currentGuessInteger < magicNumber)
                    {
                        Console.WriteLine($"Nope you guess of {currentGuess} is too low! Try again.");
                    }
                    if (currentGuessInteger == magicNumber)
                    {
                        Console.WriteLine($"You guessed the correct number on guess number {guessCount.ToString()}!!!");
                        Console.Write("Would you like to play again? : (yes or no) : ");
                        continuePlaying = Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("The guess you entered must be a numic integer between 1 and 100. Please try again.");
                }
            }
        }
        while (continuePlaying.ToLower().StartsWith("y"));
    }
}