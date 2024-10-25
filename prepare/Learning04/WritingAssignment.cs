using System;

class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInfo() {
        string studentName = GetStudentName();
        return $"Student Name: {studentName} - Book Title: {_title}";
    }
}