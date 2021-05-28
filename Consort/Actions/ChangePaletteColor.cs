using System.Drawing;
using Consort.Document;

namespace Consort.Actions {

    /// <summary>
    ///     An action that changes one of the colors of a given palette
    /// </summary>
    class ChangePaletteColor : AbstractAction {

        /// <summary>
        ///     Create a new Change Palette Color Action
        /// </summary>
        /// <param name="affectedPalette">The palette that will be affected</param>
        /// <param name="index">The index of the color being changed</param>
        /// <param name="newColor">The new value for the color</param>
        public ChangePaletteColor(Palette affectedPalette, int index, Color newColor) {
            AffectedPalette = affectedPalette;
            Index = index;
            NewColor = newColor;
            OldColor = affectedPalette.Colors[Index];
        }
        
        public override string Name => "Change palette color";
        
        /// <summary>
        ///     The palette that will be affected
        /// </summary>
        private Palette AffectedPalette { get; }
        
        /// <summary>
        ///     The index of the color that will be changed
        /// </summary>
        private int Index { get; }
        
        /// <summary>
        ///     The new value for the color
        /// </summary>
        private Color NewColor { get; }
        
        /// <summary>
        ///     The old value for the color
        /// </summary>
        private Color OldColor { get; }
        
        /// <summary>
        ///     Executes the action, changing the color to the specified value
        /// </summary>
        protected override void InnerDo() => AffectedPalette.Colors[Index] = NewColor;
        
        /// <summary>
        ///     Undoes the action, restoring the color to its old value
        /// </summary>
        protected override void InnerUndo() => AffectedPalette.Colors[Index] = OldColor;

    }

}
