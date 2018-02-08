using System;
using System.Linq;

class CryptoMaster
{
    static void Main()
    {
        var sequence = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int stepSize = 1;
        int maxSequence = 0;

        while (stepSize <= sequence.Length)  // try with all step lenghts
        {
            for (int i = 0; i < sequence.Length; i++) // try with all starting indexes
            {
                int currentPosition = i;
                int nextPosition = (currentPosition + stepSize) % sequence.Length;
                int moveCounter = 1;

                while (sequence[nextPosition] > sequence[currentPosition])
                {
                    nextPosition = (currentPosition + stepSize) % sequence.Length;
                    currentPosition = nextPosition;
                    nextPosition = (currentPosition + stepSize) % sequence.Length;
                    moveCounter++;
                }

                if (moveCounter > maxSequence)
                {
                    maxSequence = moveCounter;
                }
            }

            stepSize++;
        }

        Console.WriteLine(maxSequence);
    }
}
