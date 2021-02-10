using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackBoardDemo
{
    public class KnowledgeBase
    {
        public List<ProblemSolver> ProblemSolvers { get; set; } = new List<ProblemSolver>();

        public ProblemSolver FindSolverFor(Problem input)
        {
            ProblemSolver foundSolver = null;
            foreach (var solver in ProblemSolvers)
            {
                if (solver.CanSolve(input))
                {
                    foundSolver = solver;
                }
            }

            return foundSolver;
        }
    }
}
