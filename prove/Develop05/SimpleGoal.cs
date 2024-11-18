using System;

public class SimpleGoal : Goal
{
    private bool _isCompleted = false;
    public SimpleGoal(bool isCompleted, string name, string description, int pointsPerCompletion) : base (name, description, pointsPerCompletion) {
        _isCompleted = isCompleted;
    }

    public bool CheckIfCompleted() {
        if (_isCompleted) {
            return true;
        } else return false;
    }

    public override string CompletedText()
    {
        if (_isCompleted) {
            return "X";
        } else return " ";
    }

    public void MarkAsCompleted() {
        _isCompleted = true;
    }

    public void UndoCompletion() {
        _isCompleted = false;
    }
    
    public override void CreateGoal()
    {
        GetGoalInfo();
    }

    public override string GetTimesCompleted()
    {
        return "";
    }
}
