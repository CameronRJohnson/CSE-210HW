using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Writer";
        job1._jobDescription = "Write stuff.";

        Job job2 = new Job();
        job2._jobTitle = "Coder";
        job2._jobDescription = "Write code.";

        Resume resume = new Resume();
        resume._name = "Jack Stallion";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}