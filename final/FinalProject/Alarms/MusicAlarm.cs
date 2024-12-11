using System.Diagnostics;

public class MusicAlarm : Alarm
{
    public MusicAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }



   public override void PlayAlarm()
    {   
        string soundFilePath = "/Users/cameronjohnson/Documents/CSE-210HW/final/FinalProject/calm.mp3";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "afplay",
                Arguments = soundFilePath,
                RedirectStandardOutput = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process.Start(psi);
    }
}
