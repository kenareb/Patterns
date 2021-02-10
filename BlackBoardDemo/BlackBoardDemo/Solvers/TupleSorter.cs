namespace BlackBoardDemo.Solvers
{
    using System.Collections.Generic;

    public class TupleSorter : ProblemSolver
    {
        public override bool CanSolve(Problem input)
        {
            if (input.State == ProblemState.NeedsSorting && input.Data is int[])
            { return true; }

            return false;
        }

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