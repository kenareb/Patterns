using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardDemo
{
    public class BlackBoard
    {
        public Problem InputProblem { get; set; }

        public Problem CurrentSolution { get; set; }

        public List<Problem> PartialSolutions { get; set; } = new List<Problem>();
        public Analyzer ProblemAnalyzer { get; set; }

        public void Analyze() 
        {
            if(CurrentSolution != null)
            {
                CurrentSolution.State = ProblemAnalyzer.Analyze(CurrentSolution);
            }

            foreach (var solutionPart in PartialSolutions)
            {
                if(solutionPart.State == ProblemState.Solved)
                {
                    solutionPart.State = ProblemAnalyzer.Analyze(solutionPart);
                }
            }
        }
    }
}
