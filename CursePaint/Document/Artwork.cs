using System.Collections.Generic;
using System.Drawing;

namespace CursePaint.Document
{
    public class Artwork
    {
        public int ActiveLayer { get; set; }
        public Size Size { get; set; }
        public IList<Layer> Layers { get; set; }
        public Palette Palette { get; set; }
        public FontFamily FontFamily { get; set; }
    }
}
