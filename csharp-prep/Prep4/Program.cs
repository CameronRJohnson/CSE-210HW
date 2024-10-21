using System;

class Program
{
    static void Main(string[] args)
    {
        List<int>  listOfNumbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string numToAdd = Console.ReadLine();
        int number = int.Parse(numToAdd);
        
        while (number != 0) {
            listOfNumbers.Add(number);
            numToAdd = Console.ReadLine();
            number = int.Parse(numToAdd);
        }

        int sumOfList = listOfNumbers.Sum();
        int averageOfList = sumOfList / listOfNumbers.Count;
        int largestOfList = listOfNumbers.Max();

        Console.WriteLine($"\n The sum is {sumOfList}");
        Console.WriteLine($"The average is {averageOfList}");
        Console.WriteLine($"The greatest number is {largestOfList}");
    }
}