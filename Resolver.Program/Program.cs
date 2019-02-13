using Resolver.AStar;
using System;
using System.Diagnostics;

namespace Resolver.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialState = new[] { 1, 2, 3, 4, 6, 0, 8, 5, 7, 9 };

            var solver = new AStarResolver();

            var timer = Stopwatch.StartNew();

            var solution = solver.Resolve(initialState);

            timer.Stop();

            Console.WriteLine($"The solution is: [{string.Join("", solution)}]");
            Console.WriteLine($"Time taken:      {timer.Elapsed.Milliseconds} ms");
            Console.WriteLine($"Memory usage:    {GC.GetTotalMemory(true)} bytes");

            Console.ReadKey();
        }
    }
}
