namespace BlackBoardDemo.Solvers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <c>Merger</c> knows how to merge two instances of a sorting problem into a single <see cref="Problem"/>.
    /// The merger expects the data to be sorted.
    /// </summary>
    /// <seealso cref="BlackBoardDemo.ProblemSolver" />
    public class Merger : ProblemSolver
    {
        /// <summary>
        /// Determines whether this instance can solve the specified input problem.
        /// </summary>
        /// <param name="input">The input problem.</param>
        /// <returns>
        /// <c>true</c> if this instance can solve the specified input problem; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanSolve(Problem input)
        {
            if (input.State == ProblemState.NeedsIntegration && input.Data is Tuple<Problem, Problem>)
            { return true; }

            return false;
        }

        /// <summary>
        /// Solves the specified input problem.
        /// </summary>
        /// <param name="input">
        /// The input problem. Must be a problem containing a tuple of problem in the <c>Data</c> property.
        /// </param>
        /// <returns>
        /// A <see cref="Problem"/> enumeration containing a single item with the merged data of the
        /// input problem.
        /// </returns>
        public override IEnumerable<Problem> Solve(Problem input)
        {
            var t = input.Data as Tuple<Problem, Problem>;
            var result = new Problem();
            result.State = ProblemState.Solved;

            if (t != null)
            {
                var prob1 = t.Item1;
                var prob2 = t.Item2;

                var arr1 = prob1.Data as int[];
                var arr2 = prob2.Data as int[];

                if (arr1 == null || arr1.Length == 0)
                {
                    result.Data = arr2;
                }
                else if (arr2 == null || arr2.Length == 0)
                {
                    result.Data = arr1;
                }
                else if (arr1 != null && arr2 != null)
                {
                    var length = arr1.Length + arr2.Length;
                    var target = new int[length];

                    int i = 0, j = 0, k = 0;

                    while (k < target.Length)
                    {
                        if (i < arr1.Length && j < arr2.Length && arr1[i] < arr2[j])
                        {
                            target[k] = arr1[i];
                            i++;
                            k++;
                        }
                        else if (i >= arr1.Length && j < arr2.Length)
                        {
                            target[k] = arr2[j];
                            j++;
                            k++;
                        }
                        else if (i < arr1.Length && j >= arr2.Length)
                        {
                            target[k] = arr1[i];
                            i++;
                            k++;
                        }
                        else
                        {
                            target[k] = arr2[j];
                            j++;
                            k++;
                        }
                    }

                    result.Data = target;
                    result.State = ProblemState.Solved;
                }
            }

            return new[] { result };
        }
    }
}