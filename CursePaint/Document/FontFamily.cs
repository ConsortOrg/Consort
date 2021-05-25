using System.Collections.Generic;
using System.Drawing;

namespace CursePaint.Document
{
    public class FontFamily
    {
        public string Name { get; }
        public double AspectRatio { get; }
        public List<Size> Sizes;
        public List<Font> Fonts;
    }
}