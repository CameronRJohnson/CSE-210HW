using System;
using System.Diagnostics;

public class RepeatingAlarm : Alarm
{
    public RepeatingAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }

    public override void PlayAlarm()
    {
        Console.Clear();

        Process audioProcess = null;
        Console.WriteLine("Press any key to deactivate the alarm.");

        while (true)
        {
            if (audioProcess == null || audioProcess.HasExited)
            {
                audioProcess = Process.Start(GetPSI("loud"));
            }


            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (audioProcess != null && !audioProcess.HasExited)
                {
                    audioProcess.Kill();
                }
                Console.WriteLine("\nAlarm deactivated.");
                break;
            }
        }
    }
}
