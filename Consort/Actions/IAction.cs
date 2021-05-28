namespace Consort.Actions {

    /// <summary>
    ///     Common interface for all Actions
    /// </summary>
    public interface IAction {

        /// <summary>
        ///     The name of the action, as it should be visible in the application
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Returns whether or not the action can be done. False if the action has already been performed.
        ///     By definition it is equal to !<see cref="CanUndo" />
        /// </summary>
        public bool CanDo { get; }

        /// <summary>
        ///     Returns whether or not the action can be undone. False if the action hasn't been done yet.
        ///     By definition it is equal to !<see cref="CanDo" />
        /// </summary>
        public bool CanUndo { get; }

        /// <summary>
        ///     Executes the action.
        /// </summary>
        public void Do();

        /// <summary>
        ///     Undoes the action.
        /// </summary>
        public void Undo();

    }

}
