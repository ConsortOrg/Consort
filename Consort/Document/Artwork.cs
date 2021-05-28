using System;
using System.Collections.Generic;
using System.Drawing;

namespace Consort.Document {

    public class Artwork {
        
        /// <summary>
        ///     The index of the currently selected layer
        /// </summary>
        public int ActiveLayerIndex { get; set; }
        
        /// <summary>
        ///     Number of new layers that have been created
        /// </summary>
        public int NewLayerCount { get; set; }
        
        /// <summary>
        ///     Dimensions of the artwork, in characters
        /// </summary>
        public Size Dimensions {
            get => _dimensions;
            set {
                if (value.Height < 1 || value.Width < 1)
                    throw new ArgumentOutOfRangeException(
                        nameof(value), 
                        "An artwork cannot have a size smaller than 1x1");
                
                _dimensions = value;
            }
        }

        /// <summary>
        ///     Backing field for <see cref="Dimensions"/>
        /// </summary>
        private Size _dimensions;

        public IList<Layer> Layers { get; set; }
        public Palette Palette { get; set; }
        public FontFamily FontFamily { get; set; }

    }

}
