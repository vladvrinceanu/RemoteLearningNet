using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int value = 1;
        object boxedValue = 0;

        // Performance of boxing
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 100000000; i++)
        {
            boxedValue = value;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken for boxing: {stopwatch.ElapsedMilliseconds} ms");

        // Performance of unboxing
        stopwatch.Restart();
        for (int i = 0; i < 100000000; i++)
        {
            int unboxedValue = (int)boxedValue;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken for unboxing: {stopwatch.ElapsedMilliseconds} ms");

        // Performance of direct access
        stopwatch.Restart();
        for (int i = 0; i < 100000000; i++)
        {
            int directValue = value;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken for direct access: {stopwatch.ElapsedMilliseconds} ms");
    }
}
