using System;

namespace BlackBoardDemo.Analyzers
{
    public class SortAnalyser : Analyzer
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
                return ProblemState.Solved;
            }
            else
            {
                for (var i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        return ProblemState.NeedsSorting;
                    }
                }

                return ProblemState.Solved;
            }
        }
    }
}
