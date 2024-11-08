using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity(string activityName, int activityDuration, string descriptionMessage) 
        : base(activityName, activityDuration, descriptionMessage)
    {}
    
    public void BreathIn(int seconds)
    {
        Console.Write("Breath In... ");
        CountDown(seconds);
    }

    public void BreathOut(int seconds)
    {
        Console.Write("Breath Out... ");
        CountDown(seconds);
        Console.Write("   ");
        Console.WriteLine();

    }


    public void Run()
    {
        string activityName = GetActivityName();
        string descriptionMessage = GetDescriptionMessage();
        
        DisplayStartMessage(activityName, descriptionMessage);
        
        AskForDuration();
        int activityDuration = GetActivityDuration();
        
        int elapsedTime = 0;
        int breathInterval = 2;

        while (elapsedTime < activityDuration)
        {
            BreathIn(breathInterval);
            BreathOut(breathInterval);
            elapsedTime += breathInterval * 2;
            if (breathInterval < 8)
            {
                breathInterval += 2;
            }
        }
        Console.Write("\n");
        DisplayEndMessage(activityDuration, activityName);
    }
}
