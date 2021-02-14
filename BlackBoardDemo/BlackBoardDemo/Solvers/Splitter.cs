namespace BlackBoardDemo.Solvers
{
    using System.Collections.Generic;

    /// <summary>
    /// The <c>Splitter</c> is capable of splitting the input problem with an input array into two
    /// problems with smaller arrays.
    /// </summary>
    /// <seealso cref="BlackBoardDemo.ProblemSolver"/>
    public class Splitter : ProblemSolver
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
            if (input.State == ProblemState.TooBig && input.Data is int[])
            { return true; }

            return false;
        }

        /// <summary>
        /// Solves the specified input by splitting the array from <c>Probelm.Data</c> into two smaller arrays.
        /// </summary>
        /// <param name="input">The input problem, which must hold an int array in the <c>Data</c> property.</param>
        /// <returns>A problem enumeration with two 'smaller' problems.</returns>
        public override IEnumerable<Problem> Solve(Problem input)
        {
            var arr = input.Data as int[];

            int l1 = arr.Length / 2;
            var l2 = arr.Length - l1;

            var arr1 = new int[l1];
            var arr2 = new int[l2];

            for (int i = 0; i < l1; i++)
            {
                arr1[i] = arr[i];
            }

            for (int i = 0; i < l2; i++)
            {
                arr2[i] = arr[i + l1];
            }

            var p1 = new Problem();
            p1.Data = arr1;
            p1.State = ProblemState.Solved;

            var p2 = new Problem();
            p2.Data = arr2;
            p2.State = ProblemState.Solved;

            return new[] { p1, p2 };
        }
    }
}