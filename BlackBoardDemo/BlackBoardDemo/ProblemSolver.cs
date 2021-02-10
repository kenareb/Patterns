using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackBoardDemo
{
    public class ProblemSolver
    {
        public static ProblemSolver Empty = new EmptyProblemSolver();
        public virtual bool CanSolve(Problem input)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Problem> Solve(Problem input)
        {
            throw new NotImplementedException();
        }
    }
}
