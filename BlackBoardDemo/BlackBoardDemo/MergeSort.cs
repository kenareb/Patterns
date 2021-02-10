namespace BlackBoardDemo
{
    using Analyzers;
    using System;

    public class MergeSort
    {
        public int[] Sort(int[] input)
        {
            var problem = new Problem();
            problem.State = ProblemState.NeedsSorting;
            problem.Data = input;

            // Push problem to a blackboard:
            var blackBoard = new BlackBoard();
            blackBoard.InputProblem = problem;
            blackBoard.ProblemAnalyzer = new SortAnalyser();

            // Set up a knoledgebase of all things, that we can do:
            var kb = new KnowledgeBase();
            kb.ProblemSolvers.Add(new Solvers.Splitter());
            kb.ProblemSolvers.Add(new Solvers.Merger());
            kb.ProblemSolvers.Add(new Solvers.Sorter());

            // Add a controller to find a solution:
            var controller = new Controller(blackBoard, kb);
            controller.Run();

            return blackBoard.CurrentSolution.Data as int[];
        }
    }
}

