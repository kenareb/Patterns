namespace BlackBoardDemo
{
    using System.Collections.Generic;

    /// <summary>
    /// The blackboard summarizes the problem and the current state of the solution for this
    /// problem. It may hold a set of partial problems, which in total represent the input problem.
    /// The blackboard has also an alayzer, which determines, if the input problem is solved or not.
    /// </summary>
    public class BlackBoard
    {
        /// <summary>
        /// Gets or sets the input problem.
        /// </summary>
        /// <value>
        /// The input problem.
        /// </value>
        public Problem InputProblem { get; set; }

        /// <summary>
        /// Gets or sets the solved problem.
        /// </summary>
        /// <value>
        /// The solved problem, or finally the solution of the input problem.
        /// </value>
        public Problem SolvedProblem { get; set; }

        /// <summary>
        /// Gets or sets the sub problems. The total of all solved sub problems forms the solution
        /// of the input problem.
        /// </summary>
        /// <value>The list for the sub problems.</value>
        public List<Problem> SubProblems { get; set; } = new List<Problem>();

        /// <summary>
        /// Gets or sets the problem analyzer.
        /// </summary>
        /// <value>
        /// The problem analyzer.
        /// </value>
        public Analyzer ProblemAnalyzer { get; set; }

        /// <summary>
        /// Analyzes this instance. Includes analyzing the current solution and the proposed partial solutions.
        /// </summary>
        public void Analyze()
        {
            if (SolvedProblem != null)
            {
                SolvedProblem.State = ProblemAnalyzer.Analyze(SolvedProblem);
            }

            foreach (var solutionPart in SubProblems)
            {
                if (solutionPart.State == ProblemState.Solved)
                {
                    solutionPart.State = ProblemAnalyzer.Analyze(solutionPart);
                }
            }
        }
    }
}