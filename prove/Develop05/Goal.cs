using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

public abstract class Goal
{
    protected  string _name;
    protected string _description;
    protected int _pointsPerCompletion;
    
    public Goal(string name, string description, int pointsPerCompletion) {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
    }

    public abstract string CompletedText();

    public string GetName() {
        return _name;
    }

    public string GetDescription() {
        return _description;
    }

    public void DisplayCongratulations() {
        Console.WriteLine($"Congratulations! You have earned {_pointsPerCompletion} points!\n");
        Console.Write("Press enter to continue. ");
        Console.ReadLine();
    }

    public int GetPointsPerCompletion() {
        return _pointsPerCompletion;
    }

    public abstract string GetTimesCompleted();

    public void GetGoalInfo() {
        Console.Write("\nWhat is the name of your goal? ");
        _name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();

        Console.Write("What is the amount of points assiociated with it? ");
        _pointsPerCompletion = int.Parse(Console.ReadLine());
    }

    public abstract void CreateGoal();
}