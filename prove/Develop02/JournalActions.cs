using System;
using System.IO;

class JournalActions {
    
    // List of current journal entrys
    List<String> _journalEntrys = new List<String>();

    // A function to add a new jounral entry
    public void Write() {
        // Get the random question
        List<String> _randomQuestions = new List<String>();
        _randomQuestions.Add("Who was the most interesting person I interacted with today?");
        _randomQuestions.Add("What was the best part of my day?");
        _randomQuestions.Add("How did I see the hand of the Lord in my life today?");
        _randomQuestions.Add("What was the strongest emotion I felt today?");
        _randomQuestions.Add("If I had one thing I could do over today, what would it be?");

        // Loads the random questions
        Random _r = new Random();
        int index = _r.Next(_randomQuestions.Count);
        String _randomQuestion = _randomQuestions[index];

        // Get the current time
        DateTime _theCurrentTime = DateTime.Now;
        string _dateText = _theCurrentTime.ToShortDateString();

        // Ask the question
        Console.WriteLine($"{_randomQuestion}");

        // Add the question to the file
        String _entry = Console.ReadLine();
        String _entryWithDateAndQuestion = $"\nDate: {_dateText}\nQuestion: {_randomQuestion}\nEntry: {_entry}\n";
        _journalEntrys.Add(_entryWithDateAndQuestion);
        
        Console.WriteLine("\nEntry Added!\n");
    }

    // A function that displays the current loaded entrys
    public void Display() {
        foreach (String journalEntry in _journalEntrys) {
            Console.WriteLine(journalEntry);
        }
    }

    // A function to save a the list of entrys to the folder
    public void Save() {
        // Ask for the file name
        Console.Write("\nWhat would you like to name the file? ");
        String _fileName = Console.ReadLine();

        // Ask for the users overall happiness level
        Console.Write("What is your overall happiness level from 1-10 today? ");
        String _happinessLevel = Console.ReadLine();

        // Make the file
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            // Add each entry to the file
            foreach (String journalEntry in _journalEntrys) {
                outputFile.WriteLine(journalEntry);
            }
            outputFile.WriteLine($"Your happiness level on this day was: {_happinessLevel}");
        }

        // Display saved text
        Console.WriteLine($"Saved as {_fileName}\n");
    }
 
    // A function that loads a new list of entries
    public void Load() {
        // Ask for what they want to load
        Console.Write("What file do you want to load? ");
        String _fileName = Console.ReadLine();

        // Clear the entries before adding new ones
        _journalEntrys.Clear();

        try
        {
            // Load the file
            string[] _lines = File.ReadAllLines(_fileName);
            foreach (string line in _lines)
            {
                // Add each line (entry) to the journal entries list
                _journalEntrys.Add(line);
            }

            // Display loaded text
            Console.WriteLine($"File named {_fileName} was loaded!\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File named {_fileName} was not found.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}\n");
        }
    }
}