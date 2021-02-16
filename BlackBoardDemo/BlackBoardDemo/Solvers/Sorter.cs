namespace BlackBoardDemo.Solvers
{
    using System.Collections.Generic;

    /// <summary>
    /// The <c>TupleSorter</c> is capable of putting two integers into the correct sorting order.
    /// </summary>
    /// <seealso cref="BlackBoardDemo.ProblemSolver" />
    public class Sorter : ProblemSolver
    {
        /// <summary>
        /// Determines whether this instance can solve the specified input problem.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns>
        ///   <c>true</c> if this instance can solve the specified input problem; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanSolve(Problem input)
        {
            if (input.State == ProblemState.NeedsSorting && input.Data is int[])
            { return true; }

            return false;
        }

        /// <summary>
        /// Solves the specified input problem. The input must contain an array with two integers.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns>A problem enumeration containing a single problem. The problem data will be a sorted array.</returns>
        public override IEnumerable<Problem> Solve(Problem input)
        {
            var data = input.Data as int[];

            if (data != null)
            {
                switch (data.Length)
                {
                    case 1:
                        input.State = ProblemState.Solved;
                        break;

                    case 2:
                        if (data[0] > data[1])
                        {
                            var tmp = data[0];
                            data[0] = data[1];
                            data[1] = tmp;
                        }
                        input.State = ProblemState.Solved;
                        break;

                    default:
                        input.State = ProblemState.TooBig;
                        break;
                }
            }

            return new[] { input };
        }
    }
}