public class Scripture
{
    private Dictionary<string, List<Word>> scriptures = new Dictionary<string, List<Word>>();
    private Random random = new Random();

    public void AddScripture(string reference, string scriptureText)
    {
        List<Word> words = new List<Word>();
        string[] wordArray = scriptureText.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }

        scriptures[reference] = words;
    }

    public string GetScripture(string reference)
    {
        if (scriptures.ContainsKey(reference))
        {
            List<Word> words = scriptures[reference];
            return string.Join(" ", words.ConvertAll(word => word.isShown ? word.word : "_"));
        }

        return "Scripture not found.";
    }

    public void WriteScripture(string reference)
    {
        if (scriptures.ContainsKey(reference))
        {
            Console.WriteLine($"{reference}: {string.Join(" ", scriptures[reference].ConvertAll(word => word.isShown ? word.word : "_"))}");
        }
        else
        {
            Console.WriteLine("Scripture not found.");
        }
    }

    public void HideThreeWords(string reference)
    {
        if (scriptures.ContainsKey(reference))
        {
            List<Word> words = scriptures[reference];

            List<Word> visibleWords = words.FindAll(word => word.isShown);

            int hideCount = Math.Min(3, visibleWords.Count);
            for (int i = 0; i < hideCount; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].isShown = false;
                visibleWords.RemoveAt(index);
            }
        }
    }
}
