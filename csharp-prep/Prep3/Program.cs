using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int random = rnd.Next(1,100);

        Console.Write("Guess a number: ");
        int response = int.Parse(Console.ReadLine());

        while (response != random)
        {
            if (response >= random) {
                Console.Write("The random number is less.");
                Console.Write("\nPlease try again: ");
                response = int.Parse(Console.ReadLine());
            } else {
                Console.Write("The random number is greater.");
                Console.Write("\nPlease try again: ");
                response = int.Parse(Console.ReadLine());
            }
        }
        Console.Write("You guessed it!!!");
    }
}