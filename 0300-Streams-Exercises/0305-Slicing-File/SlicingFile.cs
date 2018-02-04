using System;
using System.Collections.Generic;
using System.IO;

class SlicingFile
{
    private const int bufferSize = 4096;

    static void Main()
    {
        string sourceFile = "sliceMe.mp4";
        string destination = "";
        int parts = 5;

        Slice(sourceFile, destination, parts);

        var files = new List<string>
        {
            "Part-0.mp4",
            "Part-1.mp4",
            "Part-2.mp4",
            "Part-3.mp4",
            "Part-4.mp4",
        };

        Assemble(files, destination);
    }

    static void Slice(string sourceFile, string destinationDirectiory, int parts)
    {
        using (var reader = new FileStream(sourceFile, FileMode.Open))
        {
            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            long pieceSize = (long) Math.Ceiling((double) reader.Length / parts);

            for (int i = 0; i < parts; i++)
            {
                if (destinationDirectiory == string.Empty)
                {
                    destinationDirectiory = "./";
                }

                long curentPieceSize = 0;

                string currentPart = destinationDirectiory + $"Part-{i}.{extension}";

                using (var writer = new FileStream(currentPart, FileMode.Create))
                {
                    byte[] buffer = new byte[bufferSize];
                    while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                        curentPieceSize += bufferSize;
                        if (curentPieceSize >= pieceSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

        if (destinationDirectory == string.Empty)
        {
            destinationDirectory = "./";
        }

        string assembledFile = $"{destinationDirectory}Assembled.{extension}";

        using (var writer = new FileStream(assembledFile, FileMode.Create))
        {
            byte[] buffer = new byte[bufferSize];

            foreach (var file in files)
            {
                using (var reader = new FileStream(file, FileMode.Open))
                {
                    while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                    }
                }
            }
        }
    }
}
