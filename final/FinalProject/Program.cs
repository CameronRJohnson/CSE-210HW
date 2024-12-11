using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Run();
    }

    static private List<Alarm> _alarms= new List<Alarm>();
    
    static private void DisplayClock()
    {
        Console.Clear();
        Console.WriteLine("Press 'Q' to return to the menu.\n");

        while (true)
        {
            TimeSpan currentTimeSpan = DateTime.Now.TimeOfDay;
            string timeDisplay = DisplayASCIIClock(DateTime.Now.ToString("HH:mm:ss"));

            // Create a border and title for the clock
            string border = new string('═', 68);
            string title = " DIGITAL CLOCK ";

            Console.Clear();
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║{title.PadLeft((border.Length + title.Length) / 2).PadRight(border.Length)}║");
            Console.WriteLine($"╠{border}╣");
            Console.WriteLine(timeDisplay);
            Console.WriteLine($"╚{border}╝");
            Console.Write("Press 'Q' to return to the menu.");

            List<Alarm> alarmsToRemove = new List<Alarm>();

            foreach (Alarm alarm in _alarms.ToList())
            {
                if (currentTimeSpan.Minutes == alarm.GetTime().Minutes)
                {
                    alarm.PlayAlarm();
                    alarmsToRemove.Add(alarm);
                    break;
                }
            }

            foreach (Alarm alarm in alarmsToRemove)
            {
                _alarms.Remove(alarm);
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
            }

            Thread.Sleep(1000);
        }
    }

    static private string DisplayASCIIClock(string time)
    {
        var largeNumbers = new Dictionary<char, string[]>
        {
            ['0'] = new[] { " ███ ", "█   █", "█   █", "█   █", " ███ " },
            ['1'] = new[] { "  █  ", " ██  ", "  █  ", "  █  ", " ███ " },
            ['2'] = new[] { " ███ ", "█   █", "   █ ", "  █  ", "█████" },
            ['3'] = new[] { " ███ ", "█   █", "   █ ", "█   █", " ███ " },
            ['4'] = new[] { "   █ ", "  ██ ", " █ █ ", "█████", "   █ " },
            ['5'] = new[] { "█████", "█    ", "████ ", "    █", "████ " },
            ['6'] = new[] { " ███ ", "█    ", "████ ", "█   █", " ███ " },
            ['7'] = new[] { "█████", "    █", "   █ ", "  █  ", " █   " },
            ['8'] = new[] { " ███ ", "█   █", " ███ ", "█   █", " ███ " },
            ['9'] = new[] { " ███ ", "█   █", " ████", "    █", " ███ " },
            [':'] = new[] { "     ", "  █  ", "     ", "  █  ", "     " }
        };

        string[] output = new string[5];
        foreach (char c in time)
        {
            for (int i = 0; i < 5; i++)
            {
                output[i] += largeNumbers[c][i] + "   "; // Added extra space between characters
            }
        }

        // Add padding around the clock for a clean appearance
        string border = new string('═', output[0].Length + 4);
        string[] paddedOutput = new string[output.Length + 4];
        paddedOutput[0] = $"╔{border}╗";
        paddedOutput[1] = $"║{new string(' ', border.Length)}║";

        for (int i = 0; i < output.Length; i++)
        {
            paddedOutput[i + 2] = $"║  {output[i]}  ║";
        }

        paddedOutput[paddedOutput.Length - 2] = $"║{new string(' ', border.Length)}║";
        paddedOutput[paddedOutput.Length - 1] = $"╚{border}╝";

        return string.Join('\n', paddedOutput);
    }

    static private void Run() {
        string selectedOption;

        while (true)
        {
            Console.Clear();
            Console.Write("Menu Options:\n"
                + "\n  1. Display Clock\n"
                + "  2. Create New Alarm\n"
                + "  3. Test Alarms\n"
                + "  4. List Alarms\n"
                + "  5. Quit\n"
                + "\nSelect a choice from the menu: ");

            selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    DisplayClock();
                    break;
                case "2":
                    SelectAlarm();
                    break;
                case "3":
                    TestAlarms();
                    break;                    
                case "4":
                    ListAlarms();
                    break;
                case "5":
                    Console.Clear();
                    return;
            }
        }
    }

    private static void SelectAlarm()
    {
        Console.Clear();
        Console.Write("The types of alarms are:\n"
            + "\n  1. Basic Alarm\n"
            + "  2. Timed Alarm\n"
            + "  3. Math Alarm\n"
            + "  4. Repeating Alarm\n"
            + "  5. Music Alarm\n"
            + "  6. Video Alarm\n"
            + "\nWhat type of goal would you like to set? ");

        string selectedOption = Console.ReadLine();
        switch (selectedOption)
        {
            case "1":
            BasicAlarm basicAlarm = new BasicAlarm(TimeSpan.Zero);
            basicAlarm.SetNewAlarm();
            _alarms.Add(basicAlarm);
                break;
            case "2":
            TimedAlarm timedAlarm = new TimedAlarm(TimeSpan.Zero);
            timedAlarm.SetNewAlarm();
            _alarms.Add(timedAlarm);
                break;            
            case "3":
            MathAlarm mathAlarm = new MathAlarm(TimeSpan.Zero);
            mathAlarm.SetNewAlarm();
            _alarms.Add(mathAlarm);
                break;            
            case "4":
            RepeatingAlarm repeatingAlarm = new RepeatingAlarm(TimeSpan.Zero);
            repeatingAlarm.SetNewAlarm();
            _alarms.Add(repeatingAlarm);
                break;            
            case "5":
            MusicAlarm musicAlarm = new MusicAlarm(TimeSpan.Zero);
            musicAlarm.SetNewAlarm();
            _alarms.Add(musicAlarm);
                break;            
            case "6":
            VideoAlarm videoAlarm = new VideoAlarm(TimeSpan.Zero);
            videoAlarm.SetNewAlarm();
            _alarms.Add(videoAlarm);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static private void TestAlarms()
    {
        Console.Clear();
        Console.Write("The types of alarms to test are:\n"
            + "\n  1. Basic Alarm (Plays basic alarm sound)\n"
            + "  2. Timed Alarm (Repeats over 1 min. intervals)\n"
            + "  3. Math Alarm (Finish math equation to deactivate)\n"
            + "  4. Repeating Alarm (Repeats until deactivated)\n"
            + "  5. Music Alarm (Plays nice alarm sound)\n"
            + "  6. Video Alarm (Makes you watch a video)\n"
            + "\nWhat type of goal would you like to test? ");

        string selectedOption = Console.ReadLine();
        switch (selectedOption)
        {
            case "1":
            BasicAlarm basicAlarm = new BasicAlarm(TimeSpan.Zero);
            basicAlarm.PlayAlarm();
                break;
            case "2":
            TimedAlarm timedAlarm = new TimedAlarm(TimeSpan.Zero);
            timedAlarm.PlayAlarm();
                break;            
            case "3":
            MathAlarm mathAlarm = new MathAlarm(TimeSpan.Zero);
            mathAlarm.PlayAlarm();
                break;            
            case "4":
            RepeatingAlarm repeatingAlarm = new RepeatingAlarm(TimeSpan.Zero);
            repeatingAlarm.PlayAlarm();
                break;            
            case "5":
            MusicAlarm musicAlarm = new MusicAlarm(TimeSpan.Zero);
            musicAlarm.PlayAlarm();
                break;            
            case "6":
            VideoAlarm videoAlarm = new VideoAlarm(TimeSpan.Zero);
            videoAlarm.PlayAlarm();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    

    private static void ListAlarms()
    {
        Console.Clear();
        if (_alarms.Count == 0) {
            Console.WriteLine("No alarms to display.");
        } else {
            Console.WriteLine("Your alarms are:");
            int alarmNumber = 0;
            foreach (Alarm alarm in _alarms){
                alarmNumber++;
                Console.WriteLine($"{alarmNumber}. {alarm.GetAlarmData()}");
            }
        }
        Console.Write("\nPress enter to continue ");
        Console.ReadLine();
    }

}