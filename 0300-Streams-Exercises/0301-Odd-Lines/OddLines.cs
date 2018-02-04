using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        var reader = new StreamReader("someFile.txt");
        int lineCounter = 0;
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {

                if (lineCounter % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
                lineCounter++;
            }
        }
    }
}
