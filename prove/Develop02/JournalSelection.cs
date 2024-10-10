using System;

class JournalSelection {
    public void Run() {
        // Declare varibles
        String _selectedOption = "";
        JournalActions _journalActions= new JournalActions();

        while (_selectedOption != "5") {        
            // Write options
            Console.Write("Welcome to the Journal Program!\n"
            + "Please select one of the following choices\n"
            + "1. Write\n"
            + "2. Display\n"
            + "3. Load\n"
            + "4. Save\n"
            + "5. Quit\n"
            + "What would you like to do? "
            );

            // Recieve input
            _selectedOption = Console.ReadLine();
            Console.WriteLine("\n");

            // Determine action
            switch (_selectedOption)
            {
                case "1":
                    _journalActions.Write();
                    break;
                case "2":
                    _journalActions.Display();
                    break;
                case "3":
                    _journalActions.Load();
                    break;
                case "4":
                    _journalActions.Save();
                    break;
                case "5":
                    Quit();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                break;
            }

        }
    }
    private void Quit() {
        Console.WriteLine("Thank you!");
    }
}