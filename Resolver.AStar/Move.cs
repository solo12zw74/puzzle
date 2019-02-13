using Resolver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace astar
{
    public class Move
    {
        private readonly int _stepNumber;
        private readonly int[] _currentState;
        private readonly Move _previous;
        private readonly int _breadcrumb;
        private readonly int _emptyIndex;

        public Move(int step, int[] state, Move previous = null, int breadcrumb = -1)
        {
            _stepNumber = step;
            _currentState = state;
            _emptyIndex = Array.IndexOf(state, 0);
            _previous = previous;
            _breadcrumb = breadcrumb;
        }
        public int Heuristic() => Gx() + Hx();

        public IEnumerable<Move> Neigbors()
        {
            var moves = Rules.MovesMap[_emptyIndex];
            var nextStepNumber = _stepNumber + 1;
            foreach (var next in moves)
            {
                var (nextState, swappedDigit) = Swap(_currentState, _emptyIndex, next);
                yield return new Move(nextStepNumber, nextState, this, swappedDigit);
            }
        }

        public int[] GetBreadcrumbs()
        {
            var result = new List<int>();
            var p = this;
            var sb = new StringBuilder();

            while (p.Previous != null)
            {
                result.Insert(0, p.Breadcrumb);
                p = p.Previous;
            }

            return result.ToArray();
        }

        public int[] CurrentState => _currentState;

        public Move Previous => _previous;

        public int Breadcrumb => _breadcrumb;


        private (int[], int) Swap(int[] array, int from, int to)
        {
            var result = new int[array.Length];

            array.CopyTo(result, 0);
            int temp = result[from];
            result[from] = result[to];
            result[to] = temp;

            return (result, array[to]);
        }

        private int Gx() => _stepNumber;
        private int Hx() =>
            Rules
            .FinalState
            .Zip(_currentState, (f, c) => f != c)
            .Count(e => e == true);

        public override string ToString()
        {
            return $"{_stepNumber}: {string.Join(",", _currentState)} ({Heuristic()})";
        }
    }
}
