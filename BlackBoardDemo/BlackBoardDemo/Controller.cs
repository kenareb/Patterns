using System;
using System.Linq;

namespace BlackBoardDemo
{
    public class Controller
    {
        private BlackBoard _blackBoard;
        private KnowledgeBase _knowlegdeBase;
        public Controller(BlackBoard board, KnowledgeBase kb)
        {
            _blackBoard = board;
            _knowlegdeBase = kb;
        }

        public void Run()
        {
            if(!_blackBoard.PartialSolutions.Any())
            {
                _blackBoard.PartialSolutions.Insert(0,_blackBoard.InputProblem);
            }

            while(_blackBoard.PartialSolutions.Any( p => p.State != ProblemState.Solved))
            {
                var p = _blackBoard.PartialSolutions.First(p => p.State != ProblemState.Solved);
                _blackBoard.PartialSolutions.Remove(p);

                var solver = _knowlegdeBase.FindSolverFor(p);
                var solutionParts = solver.Solve(p);
                
                _blackBoard.PartialSolutions.InsertRange(0,solutionParts);

                _blackBoard.Analyze();
            }

            var result = new Problem() { Data = new int[0], State = ProblemState.Solved};
            foreach(var part in _blackBoard.PartialSolutions)
            {
                var problem = new Problem()
                {
                    Data = new Tuple<Problem, Problem>(result, part),
                    State = ProblemState.NeedsIntegration
                };

                var merger = _knowlegdeBase.FindSolverFor(problem);
                result = merger.Solve(problem).Single();
            }

            _blackBoard.CurrentSolution = result;
            _blackBoard.Analyze();
        }
    }
}
