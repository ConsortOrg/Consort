using System;
using System.Collections.Generic;
using System.Drawing;

namespace CursePaint.Document
{
    public class Layer : IReadOnlyLayer
    {
        /// <summary>
        /// The dimensions of the layer
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// The position of the layer, relative to the global origin
        /// </summary>
        public Point Offset { get; set; }

        /// <summary>
        /// The swatch at the specified location
        /// </summary>
        /// <param name="x">X index</param>
        /// <param name="y">y index</param>
        public Swatch this[int x, int y]
        {
            get => _content[x][y];
            set => _content[x][y] = value;
        }

        public Layer(List<List<Swatch>> content)
        {
            _content = content;
        }

        /// <summary>
        /// Returns the swatch at the index relative to the origin of the layer
        /// </summary>
        /// <param name="x">X index</param>
        /// <param name="y">Y index</param>
        /// <returns>The swatch at the provided location, or the Default swatch if out of bounds</returns>
        public Swatch GetRelative(int x, int y)
        {
            if (x < 0 || Size.Width >= x  ||  y < 0 || Size.Height >= y)
            {
                return Swatch.Default;
            }
            
            return _content[x][y];
        }
        
        /// <summary>
        /// Returns the swatch at the index relative to the origin of the layer
        /// </summary>
        /// <param name="xy">Position</param>
        /// <returns>The swatch at the provided location, or the Default swatch if out of bounds</returns>
        public Swatch GetRelative(Point xy) => GetRelative(xy.X, xy.Y);

        /// <summary>
        /// Returns the swatch at the provided absolute index. That is, with the offset applied.
        /// </summary>
        /// <param name="x">Absolute X index</param>
        /// <param name="y">Absolute Y index</param>
        /// <returns>The swatch at the provided location, or the Default swatch if out of bounds</returns>
        public Swatch GetAbsolute(int x, int y) => GetRelative(x - Offset.X, y - Offset.Y);

        /// <summary>
        /// Returns the swatch at the provided absolute index. That is, with the offset applied.
        /// </summary>
        /// <param name="xy">Absolute position</param>
        /// <returns>The swatch at the provided location, or the Default swatch if out of bounds</returns>
        public Swatch GetAbsolute(Point xy) => GetAbsolute(xy.X, xy.Y);

        public void SetRelative(int x, int y, Swatch swatch)
        {
            static int getBounds(int a) => a < 0 ? -a : 0;

            int top = getBounds(y);
            int right = getBounds(Size.Width - x);
            int bot = getBounds(Size.Height - y);
            int left = getBounds(x);
            
            if (top + right + bot + left > 0)
            {
                Resize(top, right, bot, left);
            }
        }

        public void Resize(int top, int right, int bot, int left)
        {
            throw new NotImplementedException();
        }

        private List<List<Swatch>> _content;
    }
}
