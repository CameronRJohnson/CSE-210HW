using System;

public class ChecklistGoal : Goal
{
    private int _extraPoints;
    private int _timesToComplete;
    private int _timesCompleted;
    public ChecklistGoal(int extraPoints, int timesToComplete, int timesCompleted, string name, string description, int pointsPerCompletion) : base (name, description, pointsPerCompletion) {
        _extraPoints = extraPoints;
        _timesToComplete = timesToComplete;
        _timesCompleted = timesCompleted;
    }

    public void CompleteChecklistGoal() {
        _timesCompleted++;
    }

    public void UndoChecklistGoal() {
        _timesCompleted--;
    }
    
    public override string CompletedText()
    {
        if (CheckIfCompleted()) {
            return "X";
        } else return " ";
    }
    
    public bool CheckIfCompleted() {
        if (_timesCompleted == _timesToComplete) {
            return true;
        } else return false;
    }

    public void DisplayExtraPointsCongratulations() {
        Console.WriteLine($"Congratulations! You have earned {_pointsPerCompletion} points plus an extra {_extraPoints} points for completing this goal {_timesToComplete} times!\n");
        Console.Write("Press enter to continue. ");
        Console.ReadLine();
    }
    
    public int GetExtraPoints() {
        return _extraPoints + _pointsPerCompletion;
    }

    public int GetTimesCompletedText() {
        return _timesCompleted;
    }
    public int GetTimesToComplete() {
        return _timesToComplete;
    }

    public override string GetTimesCompleted() {
        return $"-- Currently Completed: {_timesCompleted}/{_timesToComplete}";
    }

    public override void CreateGoal()
    {
        GetGoalInfo();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _timesToComplete = int.Parse(Console.ReadLine());

        Console.Write("What is the bonus for accomplishing it that many times? ");
        _extraPoints = int.Parse(Console.ReadLine());
    }
}
