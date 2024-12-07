using System;
using NAudio.Wave;

public abstract class Alarm
{
    protected TimeSpan _time; // Change to TimeSpan for better time handling.

    public Alarm(TimeSpan time)
    {
        _time = time;  
    }

    public TimeSpan GetTime()
    {
        return _time;
    }

    abstract public string GetAlarmData();

    public void SetNewAlarm()
    {
        Console.Write("Enter the time for the alarm (HH:mm): ");
        string input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
        {
            _time = parsedTime.TimeOfDay;

            DateTime displayTime = DateTime.Today.Add(_time);
            Console.WriteLine($"Alarm successfully set for {displayTime:hh\\:mm tt}.");
        }
        else
        {
            Console.WriteLine("Invalid time format. Please use HH:mm (e.g., 08:30).");
        }
    }

    abstract public void PlayAlarm();



    // For testing purposes 
    
    // public void PlayAlarmSound()
    // {
    //     try
    //     {
    //         using (var audioFile = new AudioFileReader("australia-eas-alarm-267664.mp3"))
    //         using (var outputDevice = new WaveOutEvent())
    //         {
    //             outputDevice.Init(audioFile);
    //             outputDevice.Play();

    //             // Wait for the sound to finish playing without blocking the thread completely.
    //             while (outputDevice.PlaybackState == PlaybackState.Playing)
    //             {
    //                 System.Threading.Thread.Sleep(100);
    //             }
    //         }
    //         Console.WriteLine("Alarm sound has played.");
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"An error occurred while playing the alarm sound: {ex.Message}");
    //     }
    // }






    public void AskUserForSetTime()
    {
        // Placeholder for any functionality you want to implement.
    }

    public void DisplayEndMessage()
    {
        // Placeholder for end message logic.
    }

    public void SelfActive()
    {
        // Placeholder for self-activation logic.
    }
}
