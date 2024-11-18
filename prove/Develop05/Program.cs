using System;

class Program
{
    // Runs the program
    static void Main(string[] args)
    {
        Console.Clear();
        Run();
    }

    // Declare Varibles
    static int _points = 0;
    static List<Goal> _goals = new List<Goal>();

    // Displays the start message
    private static void Run()
    {
        string selectedOption;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Current points: {_points}\n");
            Console.Write("Menu Options:\n"
                + "  1. Create New Goal\n"
                + "  2. List Goals\n"
                + "  3. Save Goals\n"
                + "  4. Load Goals\n"
                + "  5. Record Goals\n"
                + "  6. Undo Goal\n"
                + "  7. Quit\n"
                + "Select a choice from the menu: ");

            selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    SelectGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordGoals();
                    break;
                case "6":
                    CorrectGoals();
                    break;
                case "7":
                    Console.Clear();
                    return;
            }
        }
    }

    // Display a list of different types of goals
    private static void SelectGoal()
    {
        Console.Clear();
        Console.Write("The types of Goals are:\n"
            + "  1. Simple Goal\n"
            + "  2. Eternal Goal\n"
            + "  3. Checklist Goal\n"
            + "What type of goal would you like to create? ");

        string selectedOption = Console.ReadLine();
        switch (selectedOption)
        {
            case "1":
            SimpleGoal simpleGoal = new SimpleGoal(false, "", "", 0);
            simpleGoal.CreateGoal();
            _goals.Add(simpleGoal);
                break;
            case "2":
            EternalGoal eternalGoal = new EternalGoal("", "", 0);
            eternalGoal.CreateGoal();
            _goals.Add(eternalGoal);
                break;
            case "3":
            ChecklistGoal checklistGoal = new ChecklistGoal(0,0,0, "", "", 0);
            checklistGoal.CreateGoal();
            _goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    
    // Lists all loaded goals
    private static void ListGoals()
    {
        Console.Clear();
        if (_goals.Count == 0) {
            Console.WriteLine("No goals to display.");
        } else {
            Console.WriteLine("Your goals are:");
            int goalNumber = 0;
            foreach (Goal goal in _goals){
                goalNumber++;
                Console.WriteLine($"{goalNumber}. [{goal.CompletedText()}] {goal.GetName()} ({goal.GetDescription()}) {goal.GetTimesCompleted()}");
            }
        }
        Console.Write("\nPress enter to continue ");
        Console.ReadLine();
    }

    // Save list of goals
    private static void SaveGoals() 
    {
        Console.Clear();
        // Ask for the file name
        Console.Write("\nWhat is the file name for the goal file? ");
        string _fileName = Console.ReadLine();

        // Make the file
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            outputFile.WriteLine(_points);
            // Add each entry to the file
            foreach (Goal goal in _goals) 
            {
                if (goal is SimpleGoal simpleGoal) {
                    outputFile.WriteLine($"SimpleGoal:{simpleGoal.GetName()}|{simpleGoal.GetDescription()}|{simpleGoal.GetPointsPerCompletion()}|{simpleGoal.CheckIfCompleted()}");
                } else if (goal is EternalGoal eternalGoal) {
                    outputFile.WriteLine($"EternalGoal:{eternalGoal.GetName()}|{eternalGoal.GetDescription()}|{eternalGoal.GetPointsPerCompletion()}");
                } else if (goal is ChecklistGoal checklistGoal) {
                    outputFile.WriteLine($"ChecklistGoal:{checklistGoal.GetName()}|{checklistGoal.GetDescription()}|{checklistGoal.GetPointsPerCompletion()}|{checklistGoal.GetExtraPoints() - checklistGoal.GetPointsPerCompletion()}|{checklistGoal.GetTimesToComplete()}|{checklistGoal.GetTimesCompletedText()}");
                }
            }
        }

        Console.Write($"\nGoals saved successfully to {_fileName}.\nPress enter to continue.");
        Console.ReadLine();
    }
 
    // Loads goals from a txt file
    private static void LoadGoals()
    {
        Console.Clear();
        _goals.Clear();
        Console.Write("What is the name for the goal file? ");
        string _fileName = Console.ReadLine();

        try
        {
            string[] _lines = File.ReadAllLines(_fileName);
            if (_lines.Length > 0)
            {
                _points = int.Parse(_lines[0]);
                for (int i = 1; i < _lines.Length; i++)
                {
                    string line = _lines[i];

                    if (line.StartsWith("SimpleGoal:"))
                    {
                        string[] parts = line.Substring("SimpleGoal:".Length).Split('|');
                        string name = parts[0];
                        string description = parts[1];
                        int pointsPerCompletion = int.Parse(parts[2]);
                        bool isCompleted = bool.Parse(parts[3]);

                        SimpleGoal simpleGoal = new SimpleGoal(isCompleted, name, description, pointsPerCompletion);
                        _goals.Add(simpleGoal);
                    }
                    else if (line.StartsWith("EternalGoal:"))
                    {
                        string[] parts = line.Substring("EternalGoal:".Length).Split('|');
                        string name = parts[0];
                        string description = parts[1];
                        int pointsPerCompletion = int.Parse(parts[2]);

                        EternalGoal eternalGoal = new EternalGoal(name, description, pointsPerCompletion);
                        _goals.Add(eternalGoal);
                    }
                    else if (line.StartsWith("ChecklistGoal:"))
                    {
                        string[] parts = line.Substring("ChecklistGoal:".Length).Split('|');
                        string name = parts[0];
                        string description = parts[1];
                        int pointsPerCompletion = int.Parse(parts[2]);
                        int extraPoints = int.Parse(parts[3]) + pointsPerCompletion;
                        int timesToComplete = int.Parse(parts[4]);
                        int timesCompleted = int.Parse(parts[5]);

                        ChecklistGoal checklistGoal = new ChecklistGoal(extraPoints, timesToComplete, timesCompleted, name, description, pointsPerCompletion);
                        _goals.Add(checklistGoal);
                    }
                }
            }

            Console.Write($"\nFile named {_fileName} was loaded successfully!\nPress enter to continue.");
        }
        catch (FileNotFoundException)
        {
            Console.Write($"\nFile named {_fileName} was not found.\nPress enter to continue.");
        }
        Console.ReadLine();
    }

    // Complete a goal
    private static void RecordGoals()
    {
        // Displays the current goals
        Console.Clear();
        ListGoals();

        // if there are goals
        if (_goals.Count != 0) {

            // Asks user for which goal they want to choose
            Console.Write("\nWhich goal did you accomplish?: ");
            int selectedGoal = int.Parse(Console.ReadLine()) - 1;
            Goal goal = _goals[selectedGoal];

            // If it is a simple goal check it once and ignore all future requests
            if (goal is SimpleGoal simpleGoal)
            {
                if (simpleGoal.CheckIfCompleted()) {
                } else {
                    simpleGoal.MarkAsCompleted();
                    simpleGoal.DisplayCongratulations();
                    _points += simpleGoal.GetPointsPerCompletion();
                }
            }

            // If it is an eternal reward user for completion
            else if (goal is EternalGoal eternalGoal)
            {
                eternalGoal.DisplayCongratulations();
                _points += eternalGoal.GetPointsPerCompletion();
            }

            // If it is a checklist goal check to see if it is already completed, if so ignore request.
            else if (goal is ChecklistGoal checklistGoal)
            {

                // If not already completed add completion and reward points. 
                if (checklistGoal.CompletedText() == "X") {
                } else {
                    checklistGoal.CompleteChecklistGoal();

                    // If checklist completion hits threshold reward extra points.
                    if (!checklistGoal.CheckIfCompleted()) {
                        checklistGoal.CompletedText();
                        checklistGoal.DisplayCongratulations();
                        _points += checklistGoal.GetPointsPerCompletion();
                    } else {
                        checklistGoal.DisplayExtraPointsCongratulations();
                        _points += checklistGoal.GetExtraPoints();
                    }
                }

        } else return;
    
        }

    }

    private static void CorrectGoals() {
        // Displays the current goals
        Console.Clear();
        ListGoals();

        if (_points != 0) {
            // Asks user for which goal they want to choose
            Console.Write("\nWhich goal do you want to correct?: ");
            int selectedGoal = int.Parse(Console.ReadLine()) - 1;
            Goal goal = _goals[selectedGoal];

            if (goal is SimpleGoal simpleGoal) {
                if (simpleGoal.CheckIfCompleted()){
                    _points -= simpleGoal.GetPointsPerCompletion();
                    simpleGoal.UndoCompletion();
                } else {
                    Console.Write("You cannot correct this goal.");
                    Console.ReadLine();
                }
            } else if (goal is ChecklistGoal checklistGoal) {
                if ((!checklistGoal.CheckIfCompleted()) & (checklistGoal.GetTimesCompletedText() != 0)) {
                    _points -= checklistGoal.GetPointsPerCompletion();
                    checklistGoal.UndoChecklistGoal();
                } else {
                    Console.Write("You cannot correct this goal.");
                    Console.ReadLine();
                }
            } else if (goal is EternalGoal eternalGoal) {
                _points -= eternalGoal.GetPointsPerCompletion();
            }
        } else {
            return;
        }

    }
}
