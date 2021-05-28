using CursePaint.Exceptions;

namespace CursePaint.Actions {

    /// <summary>
    ///     Provides a basic implementation of undo/do invariants
    /// </summary>
    public abstract class AbstractAction : IAction {

        public abstract string Name { get; }

        public bool CanDo { get; private set; }

        public bool CanUndo => !CanDo;

        /// <summary>
        ///     Performs the action.
        /// </summary>
        /// <exception cref="CannotUndoException">
        ///     If the action has already been performed.
        /// </exception>
        public void Do() {
            if (!CanDo) throw new CannotDoException("This action has already been performed.");
            CanDo = false;
            InnerDo();
        }

        /// <summary>
        ///     Undoes the action.
        /// </summary>
        /// <exception cref="CannotUndoException">
        ///     If the action has already been undone or it hasn't been done at all.
        /// </exception>
        public void Undo() {
            if (!CanUndo) throw new CannotUndoException("This action has already been undone.");
            CanDo = true;
            InnerUndo();
        }

        /// <summary>
        ///     Method that will be called on Action.Do()
        ///     This method should implement the logic to apply changes to the program state
        /// </summary>
        protected abstract void InnerDo();

        /// <summary>
        ///     Method that will be called on Action.Undo()
        ///     This method should implement the logic to undo the changes caused by the action
        /// </summary>
        protected abstract void InnerUndo();

    }

}
