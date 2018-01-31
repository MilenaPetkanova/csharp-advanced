using System;

class RecursiveFibonacci
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        long fibonnaciNum = CalculateFibonacci(num);
        Console.WriteLine(fibonnaciNum);
    }

    private static long CalculateFibonacci(int num)
    {
        if (num < 2)
        {
            return num;
        }

        long[] memo = new long[num + 1];
        memo[0] = 0;
        memo[1] = 1;

        for (int i = 2; i <= num; i++)
        {
            memo[i] = memo[i - 1] + memo[i - 2];
        }
        return memo[num];
    }
}

//Another solution:

//using System;

//class RecursiveFibonacci
//{
//    private static long[] memo;

//    static void Main()
//    {
//        long number = long.Parse(Console.ReadLine());
//        memo = new long[number + 1];

//        long fibb = CalcFibb(number);
//        Console.WriteLine(fibb);
//    }

//    private static long CalcFibb(long number)
//    {
//        if (number <= 2)
//        {
//            return memo[number] = 1;
//        }

//        if (memo[number] != 0)
//        {
//            return memo[number];
//        }

//        return memo[number] =
//            CalcFibb(number - 1) + CalcFibb(number - 2);
//    }
//}
