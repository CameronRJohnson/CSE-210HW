using System;
using System.IO;

class JournalActions {
    
    // List of current journal entrys
    List<String> journalEntrys = new List<String>();

    // A function to add a new jounral entry
    public void Write() {
        // Get the random question
        List<String> randomQuestions = new List<String>();
        randomQuestions.Add("Who was the most interesting person I interacted with today?");
        randomQuestions.Add("What was the best part of my day?");
        randomQuestions.Add("How did I see the hand of the Lord in my life today?");
        randomQuestions.Add("What was the strongest emotion I felt today?");
        randomQuestions.Add("If I had one thing I could do over today, what would it be?");

        // Loads the random questions
        Random r = new Random();
        int index = r.Next(randomQuestions.Count);
        String randomQuestion = randomQuestions[index];

        // Get the current time
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        // Ask the question
        Console.WriteLine($"{randomQuestion}");

        // Add the question to the file
        String entry = Console.ReadLine();
        String entryWithDateAndQuestion = $"\nDate: {dateText}\nQuestion: {randomQuestion}\nEntry: {entry}\n";
        journalEntrys.Add(entryWithDateAndQuestion);
        
        Console.WriteLine("\nEntry Added!\n");
    }

    // A function that displays the current loaded entrys
    public void Display() {
        foreach (String journalEntry in journalEntrys) {
            Console.WriteLine(journalEntry);
        }
    }

    // A function to save a the list of entrys to the folder
    public void Save() {
        // Ask for the file name
        Console.Write("\nWhat would you like to name the file? ");
        String fileName = Console.ReadLine();

        // Make the file
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // Add each entry to the file
            foreach (String journalEntry in journalEntrys) {
                outputFile.WriteLine(journalEntry);
            }
        }

        // Display saved text
        Console.WriteLine($"Saved as {fileName}\n");
    }
 
    // A function that loads a new list of entries
    public void Load() {
        // Ask for what they want to load
        Console.Write("What file do you want to load? ");
        String fileName = Console.ReadLine();

        // Clear the entries before adding new ones
        journalEntrys.Clear();

        try
        {
            // Load the file
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                // Add each line (entry) to the journal entries list
                journalEntrys.Add(line);
            }

            // Display loaded text
            Console.WriteLine($"File named {fileName} was loaded!\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File named {fileName} was not found.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}\n");
        }
    }
}