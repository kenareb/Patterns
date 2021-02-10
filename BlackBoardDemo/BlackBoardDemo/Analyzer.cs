using System;

namespace BlackBoardDemo
{
    /// <summary>
    /// The analyzer is capable of analyzing a specific aspect of a problem and determine, if the problem
    /// is solved regarding the alayzed aspect.
    /// </summary>
    public class Analyzer
    {
        /// <summary>
        /// Analyzes the specified problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <returns>A <see cref="ProblemState"/> of the analyzed aspect.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual ProblemState Analyze(Problem problem)
        { throw new NotImplementedException(); }
    }
}