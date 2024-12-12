using System;
using System.Diagnostics;

public class MathAlarm : Alarm
{
    public MathAlarm(TimeSpan time) : base(time)
    {
        _time = time;
    }


    public override void PlayAlarm()
    {
        Console.Clear();

        // Grab the random numbers
        Random random = new Random();
        int num1 = random.Next(1, 4);
        int num2 = random.Next(1, 5);
        int correctAnswer = num1 + num2;

        // Print the question
        Console.WriteLine($"Solve this math problem to deactivate the alarm: {num1} + {num2} = ?");

        Process audioProcess = null;
        bool isCorrect = false;

        // While the answer is not correct it will loop the audio
        while (!isCorrect)
        {
            if (audioProcess == null || audioProcess.HasExited)
            {
                audioProcess = Process.Start(GetPSI("loud"));
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (char.IsDigit(keyInfo.KeyChar))
                {
                    int userAnswer = int.Parse(keyInfo.KeyChar.ToString());

                    if (userAnswer == correctAnswer)
                    {
                        Console.WriteLine("\nCorrect! Alarm deactivated.");

                        if (audioProcess != null && !audioProcess.HasExited)
                        {
                            audioProcess.Kill();
                        }
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please press a number.");
                }
            }
        }
    }
}
