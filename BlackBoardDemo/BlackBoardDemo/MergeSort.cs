namespace BlackBoardDemo
{
    using Analyzers;

    /// <summary>
    /// This mergesort implementation uses a blackboard and a knowledgebase. The knowledgebase has
    /// solvers for splitting, merging and sorting.
    /// </summary>
    public class MergeSort
    {
        public int[] Sort(int[] input)
        {
            // Set up a knowledgebase of all things, that we can do:
            var kb = new KnowledgeBase();
            kb.ProblemSolvers.Add(new Solvers.Splitter());
            kb.ProblemSolvers.Add(new Solvers.Merger());
            kb.ProblemSolvers.Add(new Solvers.TupleSorter());

            // Set up our problem: an unsorted array of integers...
            var problem = new Problem();
            problem.State = ProblemState.NeedsSorting;
            problem.Data = input;

            // Set up a blackboard with an analyzer:
            var blackBoard = new BlackBoard();
            blackBoard.ProblemAnalyzer = new SortAnalyzer();

            // Push problem to a blackboard:
            blackBoard.InputProblem = problem;

            // Set up a controller for the blackboard problems to find a solution:
            var controller = new Controller(blackBoard, kb);

            // Start solving problems:
            controller.Run();

            return blackBoard.SolvedProblem.Data as int[];
        }
    }
}