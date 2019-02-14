using System;
using System.Collections.Generic;
using System.Text;

namespace Resolver.Contracts
{
    public static class Rules
    {
        public static int[][] MovesMap = new int[][] {
            new [] { 1,2 },
            new [] { 0,4 },
            new [] { 0,3,5 },
            new [] { 2,4 },
            new [] { 1,3,6},
            new [] { 2,7 },
            new [] { 4,8 },
            new [] { 5,8,9 },
            new [] { 6,7,9 },
            new [] { 7,8 }};

        public static int[] FinalState = new[] { 1, 2, 3, 0, 4, 5, 6, 7, 8, 9 };
    }
}
