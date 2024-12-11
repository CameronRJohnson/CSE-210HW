using System;
using System.Diagnostics;
using NAudio.Wave;

public abstract class Alarm
{
    protected TimeSpan _time;
    private ProcessStartInfo _psi = new ProcessStartInfo
    {
        FileName = "afplay",
        Arguments =  "/Users/cameronjohnson/Documents/CSE-210HW/final/FinalProject/loud.mp3",
        RedirectStandardOutput = false,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    public Alarm(TimeSpan time)
    {
        _time = time;  
    }

    protected ProcessStartInfo GetPSI() {
        return _psi;
    }

    public TimeSpan GetTime()
    {
        return _time;
    }

    public string GetAlarmData()
    {
        DateTime displayTime = DateTime.Today.Add(_time);
        return $"Timed Alarm is set for {displayTime:hh\\:mm tt}.";
    }

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
