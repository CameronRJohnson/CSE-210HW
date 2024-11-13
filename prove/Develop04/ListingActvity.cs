using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _questionPrompts = new List<string>() {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string activityName, int activityDuration, string descriptionMessage)
        : base(activityName, activityDuration, descriptionMessage)
    {}

    private void AskQuestion()
    {
        Console.Write(">");
        Console.ReadLine();
    }

    public void Run()
    {
        string activityName = GetActivityName();
        string descriptionMessage = GetDescriptionMessage();
        string prompt = RandomlySelectObject(_questionPrompts);

        DisplayStartMessage(activityName, descriptionMessage);
        AskForDuration();

        int activityDuration = GetActivityDuration();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        DisplayPromptQuestion(prompt);
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < activityDuration)
        {
            AskQuestion();
        }

        Console.WriteLine();

        DisplayEndMessage(activityDuration, activityName);
    }
}
