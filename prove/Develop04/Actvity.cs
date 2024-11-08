using System;
using System.Threading;

class Activity
{
    private string _activityName;
    private string _descriptionMessage;
    private int _activityDuration;
    private static Random _random = new Random();

    public Activity(string activityName, int activityDuration, string descriptionMessage) {
        _activityName = activityName;
        _descriptionMessage = descriptionMessage;
        _activityDuration = activityDuration;
    }
    
    // Getters
    public string GetDescriptionMessage() {
        return _descriptionMessage;
    }
    public string GetActivityName() {
        return _activityName;
    }
    public int GetActivityDuration () {
        return _activityDuration;
    }

    // Displays the message you see as soon as you start
    public void DisplayStartMessage(string activityName, string startMessage) {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}.\n");
        Console.WriteLine(startMessage);
    }

    // Asks the user for how long they want to use the program
    public void AskForDuration()
    {
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _activityDuration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("Get ready...\n");
        DisplaySpinner(3);
        Console.Write("\n");
    }
    
    // Displays a spinner on the screen
    public void DisplaySpinner(int seconds)
    {
        char[] spinnerChars = new char[] { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        
        while (DateTime.Now < endTime)
        {
            foreach (char c in spinnerChars)
            {
                Console.Write(c);
                Thread.Sleep(200);
                Console.Write("\b \b");
            }
        }
    }

    // Randomly selected an object inside of a list
    public string RandomlySelectObject(List<string> options)
    {
        if (options == null || options.Count == 0)
        {
            throw new ArgumentException("The list cannot be null or empty.");
        }

        int randomIndex = _random.Next(options.Count);
        return options[randomIndex];
    }
    
    // Displays the inputed prompt on the screen
    public void DisplayPromptQuestion(string prompt) {
        Console.WriteLine($" --- {prompt} --- \n");
    }
    
    // Counts down from the inputed interger and disapears
    public void CountDown(int seconds)
{
    for (int i = seconds; i >= 1; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
            Console.Write("\b \b");
    }
    Console.WriteLine();
}
    
    // Displays the message at the end of the program
    public void DisplayEndMessage(int duration, string activityName) {
        Console.WriteLine("Well done!!\n");
        DisplaySpinner(3);
        Console.WriteLine($"You have completed another {duration} seconds of the {activityName}.");
        DisplaySpinner(3);
        Program.Run();  
    }
}
