using Resolver.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Resolver.Program
{
    class UserInterface
    {
        private readonly IEnumerable<IResolver> _resolvers;

        private const char inputSeparator = ',';
        private const int inputLength = 10;
        private const string InvalidInputMessage = "Invalid input";

        public UserInterface(IEnumerable<IResolver> resolvers)
        {
            _resolvers = resolvers;
        }

        public bool RequestUserAction()
        {
            Console.Write($"Please enter input array separated by ({inputSeparator}): ");

            var input = Console.ReadLine();
            var stringifiedInput = input.Split(inputSeparator);

            if (stringifiedInput.Length != inputLength)
            {
                Console.WriteLine(InvalidInputMessage);
                return false;
            }

            int[] digitizedInput;
            try
            {
                digitizedInput = stringifiedInput.Select(d => int.Parse(d.Trim())).ToArray();
            }
            catch (Exception)
            {
                Console.WriteLine(InvalidInputMessage);
                return false;
            }

            var timer = new Stopwatch();

            foreach (var resolver in _resolvers)
            {
                GC.Collect();
                timer.Restart();
                var result = resolver.Resolve(digitizedInput);
                timer.Stop();
                PrintResult(resolver, result, timer);                
            }

            Console.Write("Press enter to continue or 'q' to quit");
            return Console.ReadKey().KeyChar != 'q';
        }

        private void PrintResult(IResolver resolver, int[] result, Stopwatch timer)
        {
            Console.WriteLine($"{resolver.Name}");
            Console.WriteLine($"The solution is: [{string.Join("", result)}]");
            Console.WriteLine($"Time taken:      {timer.ElapsedTicks} ticks");
            Console.WriteLine($"Memory usage:    {GC.GetTotalMemory(true)} bytes");
            Console.WriteLine();
            Console.WriteLine("========================");
        }
    }
}
