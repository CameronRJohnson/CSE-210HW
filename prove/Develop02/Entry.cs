using System;

class Entry {
    // Assign varible of the entry class
    public string _date;
    public string _question;
    public string _text;
    public string _happinessLevel;


    // A function that reassigns the varibles
    public Entry(string date, string question, string text) {
        _date = date;
        _question = question;
        _text = text;
        _happinessLevel = string.Empty;
    }
}
