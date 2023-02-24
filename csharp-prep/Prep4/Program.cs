using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int enteredValue = 0;
        List<int> enteredValues = new List<int>();
        do{
            Console.Write("Enter any integer (enter 0 to quit): ");
            string enteredText = Console.ReadLine();
            bool validInteger = int.TryParse(enteredText, out enteredValue);
            if(validInteger){
                if(enteredValue != 0){
                    enteredValues.Add(enteredValue);
                }
            } else {
                Console.WriteLine("You entered an invalid value...");
            }

        }while(enteredValue != 0);
        Console.WriteLine("List Complete.");
        PrintListDetails(enteredValues);
    }
    static void PrintListDetails(List<int> valuesList){
        Console.WriteLine();
        
        Console.WriteLine($"The number of values in the list is {valuesList.Count()}");
        Console.WriteLine($"The sum of all values in the list is {valuesList.Sum()}");
        Console.WriteLine($"The Maximum value in the list is {valuesList.Max()}");
        Console.WriteLine($"The Minimum value in the list is {valuesList.Min()}");
        int minimumPositive = valuesList.Where(values => values >= 0 ).Min();
        Console.WriteLine($"The Minimum postive value in the list is {minimumPositive}");
        valuesList.Sort((value1, value2) => value2.CompareTo(value1));
        Console.WriteLine("The values in this list in descending order are...");
        foreach(int value in valuesList){
            Console.WriteLine(value.ToString());
        }

        Console.WriteLine();
    }
}