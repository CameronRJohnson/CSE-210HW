using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Declare varibles
        Scripture scripture = new Scripture();
        Reference reference = new Reference(scripture);

        // Adds scriptures
        reference.AddScripture("Genesis 1:1", "In the beginning God created the heavens and the earth.");
        reference.AddScripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        reference.AddScripture("Psalm 23:1", "The Lord is my shepherd; I shall not want.");

        // List of references
        List<string> _scriptureList = new List<string>
        {
            "Genesis 1:1",
            "John 3:16",
            "Psalm 23:1"
        };

        // Ask the user what scripture they want
        Console.WriteLine("Choose a scripture to look up by entering its number:");
        for (int i = 0; i < _scriptureList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptureList[i]}");
        }

        // Recieve the input
        int _choice = GetUserInput(_scriptureList.Count);
        Console.Clear();

        string _chosenScripture = _scriptureList[_choice - 1];
        string _scriptureText = reference.LookupScripture(_chosenScripture);
        Console.WriteLine($"{_chosenScripture}: {_scriptureText}\n");

        // Clears input
        string _userInput = string.Empty;

        Console.WriteLine("Press enter to continue, or type 'quit' to finish.");

        // Writes the updated scripture
        while (_userInput.ToLower() != "quit")
        {
            // Lets user press enter
            _userInput = Console.ReadLine();

            // Clears the console
            Console.Clear();

            // Hides the words
            scripture.HideWords(_chosenScripture);

            // Writes the new scripture
            scripture.WriteScripture(_chosenScripture);

            // Checks to make sure that there are still words
            if (scripture.AllWordsHidden(_chosenScripture))
            {
                Console.WriteLine("\nPress enter to continue, or type 'quit' to finish.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress enter to continue, or type 'quit' to finish.");
        }
    }

    // Makes sure that the users input is valid
    static int GetUserInput(int max)
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= max)
            {
                return input;
            }
            Console.WriteLine("Please enter a valid number.");
        }
    }
}