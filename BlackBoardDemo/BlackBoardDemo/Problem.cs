namespace BlackBoardDemo
{
    /// <summary>
    /// A problem is a set of data, which is in a specific state. When the problem is solved, the
    /// data is in the state "solved". When the problem is unsolved, the state describes, what is
    /// needed to solve the problem, for example "needs sorting".
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public ProblemState State { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The problem data.
        /// </value>
        public object Data { get; set; }
    }
}