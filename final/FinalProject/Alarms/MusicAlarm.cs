using System.Diagnostics;

public class MusicAlarm : Alarm
{
    public MusicAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }



   public override void PlayAlarm()
    {   
        Process.Start(GetPSI("calm"));
    }
}
