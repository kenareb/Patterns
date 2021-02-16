using System;
using System.Collections.Generic;
using System.Text;

namespace BlackBoardDemo.Analyzers
{
    public class AsIsAnalyzer : Analyzer
    {
        public override ProblemState Analyze(Problem problem)
        {
            // Nothing to change here...
            return problem.State;
        }
    }
}