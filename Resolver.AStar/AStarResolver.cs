using Priority_Queue;
using Resolver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace astar
{
    public class AStarResolver : IResolver
    {
        private readonly Move _initialMove;
        private readonly HashSet<Move> _passedPositions;
        private readonly SimplePriorityQueue<Move> _queue;

        public AStarResolver(Move initialMove)
        {
            _initialMove = initialMove;
            _queue = new SimplePriorityQueue<Move>();
            _passedPositions = new HashSet<Move>();
        }

        public int[] Resolve(int[] input)
        {
            _queue.Clear();
            _passedPositions.Clear();

            _queue.Enqueue(_initialMove, _initialMove.Heuristic());
            
            while (_queue.Count > 0)
            {
                var move = _queue.Dequeue();

                _passedPositions.Add(move);

                if (move.CurrentState.SequenceEqual(Rules.FinalState))
                {

                    return move.GetBreadcrumbs();
                }

                var neigbours = move.Neigbors();

                foreach (var neighbor in neigbours)
                {
                    if (!_passedPositions.Contains(neighbor))
                    {
                        _queue.Enqueue(neighbor, neighbor.Heuristic());
                    }
                }
            }

            throw new SolutionNotFoundException(_initialMove.CurrentState);
        }
    }
}
