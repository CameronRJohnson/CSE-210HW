using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        String firstName = Console.ReadLine();

        Console.WriteLine("\nWhat is your last name? ");
        String lastName = Console.ReadLine();

        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}