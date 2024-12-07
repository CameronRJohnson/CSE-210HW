using System;

public class VideoAlarm : Alarm
{
    public VideoAlarm(TimeSpan time) : base(time)
    {
        _time = time; // Correctly assign the constructor argument to the instance field.
    }

    public override string GetAlarmData()
    {
        // Convert _time to a DateTime for formatting purposes.
        DateTime displayTime = DateTime.Today.Add(_time);
        return $"Video Alarm is set for {displayTime:hh\\:mm tt}.";
    }


    public override void PlayAlarm()
    {

    }

    public void TestAlarm()
    {
        PlayAlarm();
    }
}
