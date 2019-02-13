using System;

namespace Resolver.Contracts
{
    public class SolutionNotFoundException : Exception
    {
        public string Input {get;}
        public SolutionNotFoundException(int[] initialState)
        {   
            Input = $"[{string.Join(",", initialState)}]";
        }
    }
}
