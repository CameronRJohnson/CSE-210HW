using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Reference reference = new Reference(scripture);

        // Adds scriptures to the dictionary and splits words
        reference.AddScripture("Genesis 1:1", "In the beginning God created the heavens and the earth.");
        reference.AddScripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        reference.AddScripture("Psalm 23:1", "The Lord is my shepherd; I shall not want.");

        // List of references
        List<string> scriptureList = new List<string>
        {
            "Genesis 1:1",
            "John 3:16",
            "Psalm 23:1"
        };

        // Ask the user for what scripture they want
        Console.WriteLine("Choose a scripture to look up by entering its number:");
        for (int i = 0; i < scriptureList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptureList[i]}");
        }

        int choice = GetValidUserInput(scriptureList.Count);

        string chosenScripture = scriptureList[choice - 1];
        string scriptureText = reference.LookupScripture(chosenScripture);
        Console.WriteLine($"\n{chosenScripture}: {scriptureText}\n");


        Console.WriteLine("\nPress Enter to hide 3 words, or any other key to exit.");

        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            Console.Clear();
            scripture.HideThreeWords(chosenScripture);
            scripture.WriteScripture(chosenScripture);
            Console.WriteLine("Press Enter to hide more words, or any other key to exit.");
        }
    }


    static int GetValidUserInput(int max)
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= max)
            {
                return input;
            }
            Console.WriteLine("Invalid choice. Please enter a valid number.");
        }
    }
}