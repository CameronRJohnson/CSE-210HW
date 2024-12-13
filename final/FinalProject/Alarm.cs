using System;
using System.Diagnostics;

public abstract class Alarm
{
    // Varible to keep track of when it was set
    protected TimeSpan _time;

    public Alarm(TimeSpan time)
    {
        _time = time;  
    }

    protected ProcessStartInfo GetPSI(string fileName)
    {

        ProcessStartInfo _psi = new ProcessStartInfo
        {
            FileName = "cvlc",
            Arguments = fileName,
            RedirectStandardOutput = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        return _psi;
    }


    public TimeSpan GetTime()
    {
        return _time;
    }

    // This will return the alarm data for when the user wants to list all the alarms
    public string GetAlarmData()
    {
        DateTime displayTime = DateTime.Today.Add(_time);
        return $"Timed Alarm is set for {displayTime:hh\\:mm tt}.";
    }

    // Lets the user create a new alarm
    public void SetNewAlarm()
    {
        while (true)
        {
            Console.Write("Enter the time for the alarm (HH:mm or HHMM): ");
            string input = Console.ReadLine();

            if (input.Length == 4 && int.TryParse(input, out int _))
            {
                input = input.Insert(2, ":");
            }

            if (DateTime.TryParseExact(input, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
            {
                if (parsedTime.Hour < 24 && parsedTime.Minute < 60)
                {
                    _time = parsedTime.TimeOfDay;

                    DateTime displayTime = DateTime.Today.Add(_time);
                    Console.WriteLine($"\nAlarm successfully set for {displayTime:hh\\:mm tt}.");
                    Console.Read();
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid time. Please enter a time between 00:00 and 23:59.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid time format. Please use HH:mm or HHMM (e.g., 08:30 or 0830).");
            }
        }
    }

    abstract public void PlayAlarm();
}
