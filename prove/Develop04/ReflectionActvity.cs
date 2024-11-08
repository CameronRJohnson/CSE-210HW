using System;

class ReflectionActivity : Activity
{

    public ReflectionActivity(string activityName, int activityDuration, string descriptionMessage) 
     : base(activityName, activityDuration, descriptionMessage)
    {}


    private List<string> _questionPrompts = new List<string>() {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>() {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void Run() {
        string prompt = RandomlySelectObject(_questionPrompts);
        string activityName = GetActivityName();
        string descriptionMessage = GetDescriptionMessage();
        
        DisplayStartMessage(activityName, descriptionMessage);
        AskForDuration();

        Console.WriteLine("Consider the prompt:\n");
        DisplayPromptQuestion(prompt);
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder of each of the following questions as they relate to this experience.");

        Console.Write("You may begin in: ");
        CountDown(5);

        Console.Clear();

        int activityDuration = GetActivityDuration();
        int elapsedTime = 0;
        while (elapsedTime < activityDuration)
        {
            Console.Write($"{RandomlySelectObject(_questions)} ");
            DisplaySpinner(12);
            Console.WriteLine();
            elapsedTime += 10;
        }
        Console.WriteLine();

        DisplayEndMessage(GetActivityDuration(), activityName);
    }
}
