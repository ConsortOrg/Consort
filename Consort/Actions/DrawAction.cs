using Consort.Document;

namespace Consort.Actions {

    /// <summary>
    ///     An action that applies a change to the swatches of a given layer
    /// </summary>
    public abstract class DrawAction : AbstractAction {

        /// <summary>
        ///     Create a new Draw Action
        /// </summary>
        /// <param name="layer">The layer that will be affected</param>
        /// <param name="delta">The change in swatches</param>
        public DrawAction(Layer layer, Canvas delta) {
            Delta = delta;
            AffectedLayer = layer;
        }

        /// <summary>
        ///     Name of the Draw Action
        /// </summary>
        public abstract override string Name { get; }

        /// <summary>
        ///     A canvas holding the difference between the old and new states
        /// </summary>
        private Canvas Delta { get; set; }

        /// <summary>
        ///     The layer upon which the action operates
        /// </summary>
        private Layer AffectedLayer { get; }

        /// <summary>
        ///     Executes the Draw Action, making changes to the contents of the layer
        /// </summary>
        protected override void InnerDo() => AffectedLayer.Contents.Add(Delta);

        /// <summary>
        ///     Undoes the Draw Action, restoring the layer to its previous state
        /// </summary>
        protected override void InnerUndo() => AffectedLayer.Contents.Subtract(Delta);

    }

}
