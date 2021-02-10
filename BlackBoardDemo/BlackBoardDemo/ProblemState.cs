namespace BlackBoardDemo
{
    /// <summary>
    /// A set of problem states.
    /// </summary>
    public enum ProblemState
    {
        /// <summary>
        /// Represents a solved problem.
        /// </summary>
        Solved,

        /// <summary>
        /// To solve this problem its data needs to be sorted.
        /// </summary>
        NeedsSorting,

        /// <summary>
        /// To solve this problem, it needs to be integrated with an already existing solution or
        /// with another problem.
        /// </summary>
        NeedsIntegration,

        /// <summary>
        /// To solve this problem it needs to be smaller.
        /// </summary>
        TooBig,

        /// <summary>
        /// Represents a state, which cannot be solved.
        /// </summary>
        UnSolvable
    }
}