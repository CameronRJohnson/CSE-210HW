using System;

class Program
{
    static void Main(string[] args)
    {
        Run();
    }

    public static void Run() {
        // Declare varibles
        string _selectedOption = "";

        // Write options
        Console.Clear();
        Console.Write("Menu Options:\n"
        + "  1. Start breathing activity\n"
        + "  2. Start reflection activity\n"
        + "  3. Start listing activity\n"
        + "  4. Start visual activity\n"
        + "  5. Quit\n"
        + "Select a choice from the menu: "
        );

        // Recieve input
        _selectedOption = Console.ReadLine();


        // Determine action
        switch (_selectedOption)
        {
            case "1":
            BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity",0,"This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            breathingActivity.Run();
                break;
            case "2":
            ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity",0,"This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            reflectionActivity.Run();
                break;
            case "3":
            ListingActivity listingActivity  = new ListingActivity("Listing Activity",0,"This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            listingActivity.Run();
                break;
            case "4":
            VisualActivity visualActivity = new VisualActivity("Visual Activity",0,"This activity will help you visually calm down. Please focus on the image displayed below.");
            visualActivity.Run();
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Invalid option.");
            break;
        }
    }
}