using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "";
        int favNum = 0;
        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        void GetName() {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
        }

        void GetFavNum() {
            Console.WriteLine("Please enter your favorite number: ");
            string favNumString = Console.ReadLine();
            favNum = int.Parse(favNumString);
        }


        static void DisplayPersonalMessage(string userName, int favNum)
        {
            Console.WriteLine($"{userName}, the square of your number is {favNum * favNum}");
        }

        DisplayMessage();
        GetName();
        GetFavNum();
        DisplayPersonalMessage(name, favNum);
    }
}