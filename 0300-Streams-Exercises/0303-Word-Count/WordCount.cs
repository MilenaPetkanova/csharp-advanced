using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        var words = new Dictionary<string, int>();

        using (var wordsReader = new StreamReader("words.txt"))
        {
            string line = wordsReader.ReadLine();
            while (line != null)
            {
                if (!words.ContainsKey(line))
                {
                    words.Add(line, 0);
                }
                else
                {
                    words[line]++;
                }
                line = wordsReader.ReadLine();
            }
        } 

        using (var textReader = new StreamReader("text.txt"))
        {
            string line = textReader.ReadLine();
            while (line != null)
            {
                var wordsInLine = Regex.Split(line, @"\W+");
                for (int i = 0; i < wordsInLine.Length; i++)
                {
                    wordsInLine[i] = wordsInLine[i].ToLower();
                }
                foreach (var word in wordsInLine)
                {

                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
                line = textReader.ReadLine();
            }
        }

        using (var textWriter = new StreamWriter("result.txt"))
        {
            var sortedWords = words.OrderByDescending(x => x.Value);
            foreach (var word in sortedWords)
            {
                textWriter.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
