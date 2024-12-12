using System;
using System.Diagnostics;
using System.Threading;

public class TimedAlarm : Alarm
{
    public TimedAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }


    public override void PlayAlarm()
    {
        Console.Clear();

        Console.WriteLine("Press any key to deactivate the alarm.");

        while (true)
        {
            Process audioProcess = Process.Start(GetPSI("loud"));

            while (!Console.KeyAvailable)
            {
                if (audioProcess.HasExited)
                {
                    Thread.Sleep(60000);
                    audioProcess = Process.Start(GetPSI("loud"));
                }
                Thread.Sleep(100);
            }

            Console.ReadKey(true);
            if (!audioProcess.HasExited)
            {
                audioProcess.Kill();
            }

            Console.WriteLine("\nAlarm deactivated.");
            break;
        }
    }
}
