using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        String stringGradePercentage = Console.ReadLine();
        int gradePercentage = int.Parse(stringGradePercentage);

        String letterGrade = "";
        String textResult = "";

        if (gradePercentage >= 90) {
            letterGrade = "A";
        } else if (gradePercentage >= 80) {
            letterGrade = "B";
        } else if (gradePercentage >= 70) {
            letterGrade = "C";
        } else if (gradePercentage >= 60) {
            letterGrade = "D";
        } else if (gradePercentage < 60 ) {
            letterGrade = "F";
        }

        if (gradePercentage >= 70) {
            textResult = "Congrats you passed!!!";
        } else {
            textResult = "Womp womp, try again next year maybe...";
        }

        Console.WriteLine($"\nYou finished with a {letterGrade}");
        Console.WriteLine($"{textResult}");
    }
}