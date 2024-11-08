using System;
using System.Threading;

class VisualActivity : Activity
{
    public VisualActivity(string activityName, int activityDuration, string descriptionMessage) 
        : base(activityName, activityDuration, descriptionMessage)
    {}

    // Genertated by ChatGPT 4.0
    private void DisplayImage(int frameIndex)
    {
        string[] frames = new string[]
        {
            @"
                 _______
              .-'       '-.
             /             \
            |               |
            |,  .-.  .-.  ,|
            | )(_o/  \o_)( |
            |/     /\     \|
            (_     ^^     _)
             \__|IIIIII|__/
              | \IIIIII/ |
              \          /
               `--------`
            ",
            @"
                 _______
              .-'       '-.
             /             \
            |               |
            |,  .o0o  o0o. ,|
            | )(_o/  \o_)( |
            |/     /\     \|
            (_     ^^     _)
             \__|IIIIII|__/
              | \IIIIII/ |
              \          /
               `--------`
            ",
            @"
                 _______
              .-'       '-.
             /             \
            |               |
            |,  .ooo  ooo. ,|
            | )(_o/  \o_)( |
            |/     /\     \|
            (_     ^^     _)
             \__|IIIIII|__/
              | \IIIIII/ |
              \          /
               `--------`
            ",
            @"
                 _______
              .-'       '-.
             /             \
            |               |
            |,  .OOO  OOO. ,|
            | )(_o/  \o_)( |
            |/     /\     \|
            (_     ^^     _)
             \__|IIIIII|__/
              | \IIIIII/ |
              \          /
               `--------`
            "
        };

        Console.Clear();
        Console.WriteLine(frames[frameIndex]);
    }

    public void Run()
    {
        string activityName = GetActivityName();
        string descriptionMessage = GetDescriptionMessage();
        
        DisplayStartMessage(activityName, descriptionMessage);
        
        AskForDuration();
        int activityDuration = GetActivityDuration();

        DateTime startTime = DateTime.Now;
        int frameIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < activityDuration)
        {
            DisplayImage(frameIndex);
            frameIndex = (frameIndex + 1) % 4;
            Thread.Sleep(200);
        }

        Console.Write("\n");
        DisplayEndMessage(activityDuration, activityName);
    }
}
