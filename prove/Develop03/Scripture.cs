public class Scripture
{
    private Dictionary<string, List<Word>> _scriptures = new Dictionary<string, List<Word>>();
    private Random _random = new Random();

    // Adds scriptures to the dictionary and split words
    public void AddScripture(string reference, string scriptureText)
    {
        List<Word> _words = new List<Word>();
        string[] wordArray = scriptureText.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

        _scriptures[reference] = _words;
    }

    // Looks for and stores the correct scripture
    public string GetScripture(string reference)
    {
        List<Word> _words = _scriptures[reference];
        return string.Join(" ", _words.ConvertAll(word => word._isShown ? word._word : "_"));
    }

    // Writes the list of words
    public void WriteScripture(string reference)
    {
        Console.WriteLine($"{reference}: {string.Join(" ", _scriptures[reference].ConvertAll(word => word._isShown ? word._word : new string('_', word._word.Length)))}");
    }

    // Randomly selects three words and hides them
    public void HideWords(string reference)
    {
        if (_scriptures.ContainsKey(reference))
        {
            List<Word> _words = _scriptures[reference];

            List<Word> visibleWords = _words.FindAll(word => word._isShown);

            int _hideCount = Math.Min(3, visibleWords.Count);
            for (int i = 0; i < _hideCount; i++)
            {
                int _index = _random.Next(visibleWords.Count);
                visibleWords[_index]._isShown = false;
                visibleWords.RemoveAt(_index);
            }
        }
    }

    // Checks to see if all the words in the list are hidden
    public bool AllWordsHidden(string reference)
    {
        if (_scriptures.ContainsKey(reference))
        {
            return _scriptures[reference].TrueForAll(word => !word._isShown);
        }

        return false;
    }
}