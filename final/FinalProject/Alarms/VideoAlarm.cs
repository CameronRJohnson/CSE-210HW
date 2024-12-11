using System;
using System.Diagnostics;

public class VideoAlarm : Alarm
{
    public VideoAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }

    public override void PlayAlarm()
    {
        Console.Clear();

        string youtubeUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

        Console.WriteLine("Playing YouTube video alarm...");
        Console.WriteLine($"Opening: {youtubeUrl}");

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = youtubeUrl,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to open YouTube video: {ex.Message}");
        }
    }
}
