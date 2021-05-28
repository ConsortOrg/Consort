using CursePaint.Document;

namespace CursePaint.Actions {

    /// <summary>
    ///     An action that deletes a layer in a given <see cref="Artwork"/>.
    /// </summary>
    class DeleteLayerAction : AbstractAction {

        /// <summary>
        ///     Create a new Delete Layer Action
        /// </summary>
        /// <param name="affectedArtwork">The artwork that will be affected by the layer</param>
        /// <param name="index">The index at which the layer is located</param>
        public DeleteLayerAction(Artwork affectedArtwork, int index) {
            AffectedArtwork = affectedArtwork;
            Index = index;
            RemovedLayer = affectedArtwork.Layers[index];
        }

        public override string Name => "Delete layer";

        /// <summary>
        ///     Artwork from which the layer is being deleted.
        /// </summary>
        private Artwork AffectedArtwork { get; }
        
        /// <summary>
        ///     Index at which the deleted layer was located.
        /// </summary>
        private int Index { get; }
        
        /// <summary>
        ///     A reference to the deleted layer object.
        /// </summary>
        private Layer RemovedLayer { get; }
        
        /// <summary>
        ///     Performs the Delete Layer Action.
        /// </summary>
        protected override void InnerDo() => AffectedArtwork.Layers.RemoveAt(Index);
        
        /// <summary>
        ///     Undoes the Delete Layer Action, restoring the layer to the artwork.
        /// </summary>
        protected override void InnerUndo() => AffectedArtwork.Layers.Insert(Index, RemovedLayer);

    }

}
