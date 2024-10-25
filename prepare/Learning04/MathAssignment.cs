using System;

class MathAssignment : Assignment
{

    private string _textbookSection;
    private string _problem;

    public MathAssignment(string studentName, string topic, string textbookSection, string problem)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problem = problem;
    }

    public string GetHomeworkList() {
        return $"Textbook section: {_textbookSection} - Promblem: {_problem}";
    }
}