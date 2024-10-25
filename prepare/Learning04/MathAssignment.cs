using System;

class MathAssignment : Assignment
{

    private string _textbookSection;
    private string _problem;

    // Notice the syntax here that the MathAssignment constructor has 4 parameters and then
    // it passes 2 of them directly to the "base" constructor, which is the "Assignment" class constructor.
    public MathAssignment(string studentName, string topic, string textbookSection, string problem)
        : base(studentName, topic)
    {
        // Here we set the MathAssignment specific variables
        _textbookSection = textbookSection;
        _problem = problem;
    }

    public string GetHomeworkList() {
        return $"Textbook section: {_textbookSection} - Promblem: {_problem}";
    }
}