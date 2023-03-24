using Learning04;
using System;

class Program
{
    static void Main(string[] args)
    {
    Assignment assignment = new Assignment("Jared Doerr", "Programming");
    Console.WriteLine(assignment.GetSummary());
    MathAssignment mathAssignment = new MathAssignment("Chapter 4", "1-20", "William", "Math");
    Console.WriteLine(mathAssignment.GetSummary());
    Console.WriteLine(mathAssignment.GetHomeworkList());

    WritingAssignment writingAssignemnt = new WritingAssignment("Doing stuff with things", "Bryce Doerr", "writing");

    Assignment myAssignment = (Assignment) new WritingAssignment("Stuff", "Logan", "Writing");

    Console.WriteLine(writingAssignemnt.GetSummary());
    Console.WriteLine(writingAssignemnt.GetWritingInformation());



    }
}