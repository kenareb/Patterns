namespace BlackBoardDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A problem solver is capable of applying operations to the data of a problem in a way that
    /// the state of the problem gets solved.
    /// </summary>
    public class ProblemSolver
    {
        /// <summary>
        /// Determines whether this instance can solve the specified input problem.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns>
        ///   <c>true</c> if this instance can solve the specified input problem; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool CanSolve(Problem input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Solves the specified input problem.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual IEnumerable<Problem> Solve(Problem input)
        {
            throw new NotImplementedException();
        }
    }
}