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
        /// Gets or sets the current solution.
        /// </summary>
        /// <value>
        /// The current solution.
        /// </value>
        public Problem CurrentSolution { get; set; }

        /// <summary>
        /// Gets or sets the partial solutions.
        /// </summary>
        /// <value>
        /// The partial solutions.
        /// </value>
        public List<Problem> PartialSolutions { get; set; } = new List<Problem>();

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
            if (CurrentSolution != null)
            {
                CurrentSolution.State = ProblemAnalyzer.Analyze(CurrentSolution);
            }

            foreach (var solutionPart in PartialSolutions)
            {
                if (solutionPart.State == ProblemState.Solved)
                {
                    solutionPart.State = ProblemAnalyzer.Analyze(solutionPart);
                }
            }
        }
    }
}