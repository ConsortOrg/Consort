using Consort.Document;

namespace Consort.Actions {

    /// <summary>
    ///     An action that creates a new empty layer in a given <see cref="Artwork"/>
    /// </summary>
    class NewLayerAction : AbstractAction {

        /// <summary>
        ///     Create a new New Layer Action
        /// </summary>
        /// <param name="affectedArtwork">Artwork where the new layer is being created</param>
        /// <param name="index">Index of the new layer</param>
        public NewLayerAction(Artwork affectedArtwork, int index) {
            AffectedArtwork = affectedArtwork;
            Index = index;
            NewLayer = new Layer.Builder()
                .Empty()
                .WithName($"New Layer {affectedArtwork.NewLayerCount}")
                .WithSize(affectedArtwork.Dimensions)
                .Build();
        }

        public override string Name => "New layer";

        /// <summary>
        ///     Artwork where the new layer is being created
        /// </summary>
        private Artwork AffectedArtwork { get; }

        /// <summary>
        ///     Index of the new layer
        /// </summary>
        private int Index { get; }
        
        /// <summary>
        ///     New layer instance
        /// </summary>
        private Layer NewLayer { get; }
        
        /// <summary>
        ///     Executes the action, adding the new empty layer to the artwork
        /// </summary>
        protected override void InnerDo() => AffectedArtwork.Layers.Insert(Index, NewLayer);

        /// <summary>
        ///     Undoes the action, removing the new empty layer from the artwork
        /// </summary>
        protected override void InnerUndo() => AffectedArtwork.Layers.RemoveAt(Index);

    }

}
