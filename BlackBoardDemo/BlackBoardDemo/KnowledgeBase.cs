namespace BlackBoardDemo
{
    using System.Collections.Generic;

    /// <summary>
    /// A knowledgebase contains a set of solvers for specific problems. Depending on the type of
    /// problem, a solver can be chosen to solve a problem.
    /// </summary>
    public class KnowledgeBase
    {
        /// <summary>
        /// Gets or sets the problem solvers.
        /// </summary>
        /// <value>
        /// The problem solvers.
        /// </value>
        public List<ProblemSolver> ProblemSolvers { get; set; } = new List<ProblemSolver>();

        /// <summary>
        /// Finds the solver for the input problem.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns></returns>
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