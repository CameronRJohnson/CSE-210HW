using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int pointsPerCompletion) : base (name, description, pointsPerCompletion) {
    }
    public override string CompletedText()
    {
        return " ";
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
