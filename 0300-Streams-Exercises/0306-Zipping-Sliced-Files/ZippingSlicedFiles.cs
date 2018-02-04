using System;
using System.IO;
using System.IO.Compression;

class ZippingSlicedFiles
{
    private const int bufferSize = 4096;

    static void Main()
    {
        string sourceFile = "sliceMe.mp4";
        string destination = "";
        int parts = 5;

        Zip(sourceFile, destination, parts);
    }

    static void Zip(string sourceFile, string destinationDirectiory, int parts)
    {
        using (var reader = new FileStream(sourceFile, FileMode.Open))
        {
            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

            for (int i = 0; i < parts; i++)
            {
                if (destinationDirectiory == string.Empty)
                {
                    destinationDirectiory = "./";
                }

                long curentPieceSize = 0;

                string currentPart = destinationDirectiory + $"Part-{i}.{extension}.gz";

                using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
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
}
