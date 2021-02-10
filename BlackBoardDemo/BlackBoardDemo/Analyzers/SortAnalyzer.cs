using System;

namespace BlackBoardDemo.Analyzers
{
    public class SortAnalyzer : Analyzer
    {
        public override ProblemState Analyze(Problem problem)
        {
            var data = problem.Data as int[];

            if (data == null)
            {
                return ProblemState.UnSolvable;
            }
            else if (data.Length == 0 || data.Length == 1)
            {
                // The trivial case: an empty array or an array with one element is always sorted...
                return ProblemState.Solved;
            }
            else
            {
                // Check, if the i-th item is bigger than its follower: in this case, the array is
                // not sorted.
                for (var i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        return ProblemState.NeedsSorting;
                    }
                }

                // When reaching this point, the array is sorted, so our problem is solved.
                return ProblemState.Solved;
            }
        }
    }
}