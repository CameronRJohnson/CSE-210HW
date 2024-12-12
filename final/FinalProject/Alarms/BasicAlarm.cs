using System.Diagnostics;

public class BasicAlarm : Alarm
{
    public BasicAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }


   public override void PlayAlarm()
    {   
        Process.Start(GetPSI("loud"));
    }
}
