using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("name", "topic");
        Console.Write(assignment1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Math Name", "Math Topic", "Math101", "82.9");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("WA Name", "WA Topic", "Book title");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetStudentTopic());
    }
}