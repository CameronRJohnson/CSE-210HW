using System;

public class BasicAlarm : Alarm
{
    public BasicAlarm(TimeSpan time) : base(time)
    {
        _time = time; // Correctly assign the constructor argument to the instance field.
    }

    public override string GetAlarmData()
    {
        // Convert _time to a DateTime for formatting purposes.
        DateTime displayTime = DateTime.Today.Add(_time);
        return $"Basic Alarm is set for {displayTime:hh\\:mm tt}.";
    }


    public override void PlayAlarm()
    {
        PlayAlarmSound();
    }

    public void TestAlarm()
    {
        PlayAlarmSound();
    }
}
