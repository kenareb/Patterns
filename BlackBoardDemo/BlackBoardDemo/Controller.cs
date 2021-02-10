namespace BlackBoardDemo
{
    using System;
    using System.Linq;

    public class Controller
    {
        private BlackBoard _blackBoard;
        private KnowledgeBase _knowlegdeBase;

        /// <summary>
        /// The Controller knows the blackboard and the knowlwdgebase. The Controller gets problems
        /// from the blackboard and tries to solve them with the knowledgebase.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="kb"></param>
        public Controller(BlackBoard board, KnowledgeBase kb)
        {
            _blackBoard = board;
            _knowlegdeBase = kb;
        }

        public void Run()
        {
            // At start, we don't have any partial solutions. So we'll push our input problem to the
            // partial solutions.
            if (!_blackBoard.PartialSolutions.Any())
            {
                _blackBoard.PartialSolutions.Insert(0, _blackBoard.InputProblem);
            }

            // As long as we have unsolved partial solution, we'll try to use the knowledgebase to
            // solve the partial solutions.
            while (_blackBoard.PartialSolutions.Any(p => p.State != ProblemState.Solved))
            {
                // Get the first unsolved part:
                var p = _blackBoard.PartialSolutions.First(p => p.State != ProblemState.Solved);
                _blackBoard.PartialSolutions.Remove(p);

                // Find a solver:
                var solver = _knowlegdeBase.FindSolverFor(p);

                // Solve the problem or transform it into another problem:
                var solutionParts = solver.Solve(p);

                // Store the transformed problem/solution on the blackboard:
                _blackBoard.PartialSolutions.InsertRange(0, solutionParts);

                // Let the blackboard decide, if the partial solution is solved:
                _blackBoard.Analyze();
            }

            // At this point all partial problems/solutionss are solved. Now we need to combine all
            // parts to form the solution for the input problem. So we're starting with an initial,
            // empty problem and combine the other parts with it.
            var result = new Problem() { Data = new int[0], State = ProblemState.Solved };
            foreach (var part in _blackBoard.PartialSolutions)
            {
                // Create a new problem containing the two partial problems and let the
                // knowledgebase decide, how to combine both to a single problem/solution
                var problem = new Problem()
                {
                    Data = new Tuple<Problem, Problem>(result, part),
                    State = ProblemState.NeedsIntegration
                };

                // Get a solver from knowledgebase:
                var solver = _knowlegdeBase.FindSolverFor(problem);
                result = solver.Solve(problem).Single();
            }

            // When reaching this point, all solved sub-problems have been combined into a single,
            // solved solution. So we're putting this solution onto the blackboard and let the
            // blackboard decide, whether or not our problem is solved:
            _blackBoard.CurrentSolution = result;
            _blackBoard.Analyze();
        }
    }
}