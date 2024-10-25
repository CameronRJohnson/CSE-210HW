using System;

public class Reference
{
    private Scripture scripture;

    public Reference(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public void AddScripture(string reference, string scriptureText)
    {
        scripture.AddScripture(reference, scriptureText);
    }

    public string LookupScripture(string reference)
    {
        return scripture.GetScripture(reference);
    }
}
