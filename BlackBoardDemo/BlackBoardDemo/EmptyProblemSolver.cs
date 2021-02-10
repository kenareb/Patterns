using System.Collections.Generic;

namespace BlackBoardDemo
{
    public class EmptyProblemSolver : ProblemSolver
    {
        public EmptyProblemSolver()
        {

        }

        public override bool CanSolve(Problem problem)
        {
            return false;
        }

        public override IEnumerable<Problem> Solve(Problem input)
        {
            return new[] { input };
        }
    }
}
