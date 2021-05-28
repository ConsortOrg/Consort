using System;
using System.Collections.Generic;
using CursePaint.Actions;
using CursePaint.Exceptions;

namespace CursePaint {

    /// <summary>
    ///     A class that manages a history of actions that can be undone and redone
    /// </summary>
    public class ActionHistory {

        /// <summary>
        ///     Initializes a new action history with the provided max size
        /// </summary>
        /// <param name="maxSize"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ActionHistory(int maxSize) {
            if (maxSize < 1) {
                throw new ArgumentOutOfRangeException(
                    nameof(maxSize),
                    maxSize,
                    "Max size must be 1 or larger");
            }

            InnerHistory = new LinkedList<IAction>();
            InnerHistory.AddFirst(new NullAction());
            PreviousNode = InnerHistory.First!;
            FinalNode = PreviousNode;

            MaxSize = maxSize;
        }

        /// <summary>
        ///     If the redo action can be safely performed
        /// </summary>
        public bool CanRedo => NextAction is { CanDo: true } && PreviousNode != FinalNode;

        /// <summary>
        ///     If the undo action can be safely performed
        /// </summary>
        public bool CanUndo => PreviousAction is { CanUndo: true };

        /// <summary>
        ///     Maximum number of actions that can be held by the history
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        ///     Full history list
        /// </summary>
        private LinkedList<IAction> InnerHistory { get; }

        /// <summary>
        ///     Max size including the sentinel null action
        /// </summary>
        private int InnerMaxSize => MaxSize + 1;

        /// <summary>
        ///     Node of the last done action
        /// </summary>
        private LinkedListNode<IAction> PreviousNode { get; set; }

        /// <summary>
        ///     Node of the last valid action
        /// </summary>
        private LinkedListNode<IAction> FinalNode { get; set; }

        /// <summary>
        ///     Last action that has been done
        /// </summary>
        private IAction PreviousAction {
            get => PreviousNode.Value;
            set => PreviousNode.Value = value;
        }

        /// <summary>
        ///     Next action to do
        ///     Should not be set to null, should not be set on a null next node.
        /// </summary>
        private IAction? NextAction {
            get => PreviousNode.Next?.Value;
            set {
                if (PreviousNode.Next == null) throw new NullReferenceException("Next node is null");
                PreviousNode.Next.Value = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        ///     Invalidates all future states, adds the provided action, and executes it
        /// </summary>
        /// <param name="action">The action to be added</param>
        public void Do(IAction action) {
            if (NextAction != null) {
                NextAction = action;
            }
            else {
                InnerHistory.AddAfter(PreviousNode, action);
                if (InnerHistory.Count > InnerMaxSize) {
                    InnerHistory.Remove(InnerHistory.First!.Next!);
                }
            }

            FinalNode = PreviousNode.Next!;
            Redo();
        }

        /// <summary>
        ///     Redoes the next action in the history
        /// </summary>
        /// <exception cref="CannotRedoException">
        ///     If this is the last action, or if the next action cannot be executed
        /// </exception>
        public void Redo() {
            if (!CanRedo) throw new CannotRedoException("Cannot redo. There's no valid action that can be redone");

            NextAction!.Do();
            PreviousNode = PreviousNode.Next!;
        }

        /// <summary>
        ///     Undoes the last performed action
        /// </summary>
        /// <exception cref="CannotUndoException">
        ///     If this is the first action or if the previous action cannot be undone
        /// </exception>
        public void Undo() {
            if (!CanUndo) throw new CannotUndoException("Cannot undo. There's no valid action that can be redone");

            PreviousAction!.Undo();
            PreviousNode = PreviousNode.Previous!;
        }

    }

}
