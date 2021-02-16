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
            // At start, we don't have any sub problems. So we'll push our input problem to the
            // list of the sub problems.
            if (!_blackBoard.SubProblems.Any())
            {
                _blackBoard.SubProblems.Insert(0, _blackBoard.InputProblem);
            }

            // As long as we have unsolved sub problems, we'll try to use the knowledgebase to
            // solve the sub problems.
            while (_blackBoard.SubProblems.Any(p => p.State != ProblemState.Solved))
            {
                // Get the first unsolved problem:
                var p = _blackBoard.SubProblems.First(p => p.State != ProblemState.Solved);
                _blackBoard.SubProblems.Remove(p);

                // Find a solver:
                var solver = _knowlegdeBase.FindSolverFor(p);

                // Solve the problem or transform it into another problem:
                var solutionParts = solver.Solve(p);

                // Store the transformed problem/solution on the blackboard:
                _blackBoard.SubProblems.InsertRange(0, solutionParts);

                // Let the blackboard decide, if the sub problem is solved:
                _blackBoard.Analyze();
            }

            // At this point all sub problems are solved (partial solutions). Now we need to combine
            // all parts to form the final solution for the input problem. So we're starting with an
            // initial, empty problem and combine the other parts with it.
            Problem result;
            if (_blackBoard.SubProblems.Count > 1)
            {
                result = new Problem() { Data = null, State = ProblemState.Solved };
                foreach (var part in _blackBoard.SubProblems)
                {
                    // Create a new problem containing the two partial solutions and let the
                    // knowledgebase decide, how to combine both to a single solution.
                    var problem = new Problem()
                    {
                        Data = new Tuple<Problem, Problem>(result, part),
                        State = ProblemState.NeedsIntegration
                    };

                    // Get a solver from knowledgebase:
                    var solver = _knowlegdeBase.FindSolverFor(problem);
                    result = solver.Solve(problem).Single();
                }
            }
            else
            {
                result = _blackBoard.SubProblems.FirstOrDefault();
            }

            // When reaching this point, all solved sub problems have been combined into a single,
            // solved solution. So we're putting this solution onto the blackboard and let the
            // blackboard decide, whether or not our problem is solved:
            _blackBoard.SolvedProblem = result;
            _blackBoard.Analyze();
        }
    }
}