using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        using (var reader = new StreamReader("text.txt"))
        {
            using (var writer = new StreamWriter("output.txt"))
            {
                string line = reader.ReadLine();
                int lineCounter = 1;
                while (line != null)
                {
                    writer.WriteLine($"Line {lineCounter}: {line}");

                    line = reader.ReadLine();
                    lineCounter++;
                }
            }
        }
    }
}
