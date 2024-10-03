using System;

public class Job {
    public string _jobTitle = "Microsoft";
    public string _jobDescription = "";

    public void DisplayJobDetails() {
        Console.WriteLine($"Title: {_jobTitle}, Description: {_jobDescription}");
    }
}