using CursePaint.Document;

namespace CursePaint.Actions {

    /// <summary>
    /// An action that removes all swatches from a given canvas, leaving it empty
    /// </summary>
    public class ClearLayerAction : AbstractAction {

        /// <summary>
        ///     Create a new Clear Layer Action
        /// </summary>
        /// <param name="layer">Layer that will be affected</param>
        public ClearLayerAction(Layer layer) {
            AffectedLayer = layer;
            ClearedCanvas = Canvas.EmptyWithBox(layer.Contents.BoundingBox);
            SavedCanvas = layer.Contents;
        }

        public override string Name => "Clear layer";

        /// <summary>
        ///     The cleared canvas
        /// </summary>
        private Canvas ClearedCanvas { get; }

        /// <summary>
        ///     The canvas that the layer originally held
        /// </summary>
        private Canvas SavedCanvas { get; }

        /// <summary>
        ///     The Layer upon which the action operates
        /// </summary>
        private Layer AffectedLayer { get; }

        /// <summary>
        ///     Executes the Clear Layer action, replacing the Canvas of the layer with an empty one
        /// </summary>
        protected override void InnerDo() => AffectedLayer.Contents = ClearedCanvas;

        /// <summary>
        ///     Undoes the Clear Layer action, restoring the canvas of the layer to its original state
        /// </summary>
        protected override void InnerUndo() => AffectedLayer.Contents = SavedCanvas;

    }

}
