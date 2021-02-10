using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardDemo.Solvers
{
    public class Merger : ProblemSolver
    {
        public override bool CanSolve(Problem input)
        {
            if (input.State == ProblemState.NeedsIntegration && input.Data is Tuple<Problem, Problem>)
            { return true; }

            return false;
        }

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
