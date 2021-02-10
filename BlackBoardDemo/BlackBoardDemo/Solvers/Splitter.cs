using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardDemo.Solvers
{
    public class Splitter : ProblemSolver
    {
        public override bool CanSolve(Problem input)
        {
            if (input.State == ProblemState.TooBig && input.Data is int[])
            { return true; }

            return false;
        }

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

