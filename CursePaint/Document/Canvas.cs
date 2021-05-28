using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CursePaint.Document {

    public class Canvas {

        private Canvas(List<List<Swatch>> innerData, Rectangle boundingBox) {
            InnerData = innerData;
            BoundingBox = boundingBox;
        }

        /// <summary>
        ///     Defines the bounding box of the canvas
        /// </summary>
        public Rectangle BoundingBox { get; }

        /// <summary>
        ///     Indexes the canvas at a given location relative to the canvas origin
        /// </summary>
        /// <param name="x">The position along the x-axis</param>
        /// <param name="y">The position along the y-axis</param>
        private Swatch this[int x, int y] {
            get => InnerData[x][y];
            set => InnerData[x][y] = value;
        }

        /// <summary>
        ///     Contains the data that makes up the canvas.
        /// </summary>
        private List<List<Swatch>> InnerData { get; }

        /// <summary>
        ///     Creates a new canvas of <see cref="Swatch.Empty" /> of the provided dimensions and location
        /// </summary>
        /// <param name="boundingBox">The rectangle that defines the bounding box of the new canvas</param>
        /// <returns>The new Canvas</returns>
        public static Canvas EmptyWithBox(Rectangle boundingBox) {
            var innerData = new List<List<Swatch>>();

            for (int i = 0; i < boundingBox.Width; i++) {
                innerData.Add(new List<Swatch>());
                for (int j = 0; j < boundingBox.Height; j++) {
                    innerData[i].Add(Swatch.Empty);
                }
            }

            return new Canvas(innerData, boundingBox);
        }

        /// <summary>
        ///     Creates a new Canvas from a given 2-dimensional list of swatches
        /// </summary>
        /// <param name="data">The swatch data</param>
        /// <param name="offset">The offset of the canvas with respect to the global origin</param>
        /// <returns>The new Canvas</returns>
        public static Canvas FromData(List<List<Swatch>> data, Point offset) => FromData(data, offset.X, offset.Y);

        /// <summary>
        ///     Creates a new Canvas from a given 2-dimensional list of swatches
        /// </summary>
        /// <param name="data">The swatch data</param>
        /// <param name="x">The x offset of the canvas with respect to the global origin</param>
        /// <param name="y">The y offset of the canvas with respect to the global origin</param>
        /// <returns>The new Canvas</returns>
        public static Canvas FromData(List<List<Swatch>> data, int x, int y) {
            int width = data.Count;
            int height = data.Aggregate(0, (acc, row) => Math.Max(acc, row.Count));
            var boundingBox = new Rectangle(x, y, width, height);

            return new Canvas(data, boundingBox);
        }

        /// <summary>
        ///     Subtracts another canvas from this one. If the two canvas do not overlap, no changes are made
        /// </summary>
        /// <param name="other">The other canvas</param>
        public void Add(Canvas other) => Apply(other, (swatch1, swatch2) => swatch1 + swatch2);

        /// <summary>
        ///     Subtracts another canvas from this one. If the two canvas do not overlap, no changes are made
        /// </summary>
        /// <param name="other">The other canvas</param>
        public void Subtract(Canvas other) => Apply(other, (swatch1, swatch2) => swatch1 - swatch2);

        /// <summary>
        ///     Sets the entire canvas to <see cref="Swatch.Empty" />
        /// </summary>
        public void Clear() {
            for (int i = 0; i < BoundingBox.Width; i++)
            for (int j = 0; j < BoundingBox.Height; j++) {
                InnerData[i][j] = Swatch.Empty;
            }
        }

        /// <summary>
        ///     Applies the data of another canvas into this one, using some provided function
        ///     If the canvas do not overlap, no changes are applied
        /// </summary>
        /// <param name="other">The other canvas containing the data that will be applied</param>
        /// <param name="operation">Function with which to make the change</param>
        private void Apply(Canvas other, Func<Swatch, Swatch, Swatch> operation) {
            Rectangle intersection = Rectangle.Intersect(BoundingBox, other.BoundingBox);

            if (intersection == Rectangle.Empty) return;

            for (int i = intersection.X; i < intersection.Right; i++)
            for (int j = intersection.Y; j < intersection.Bottom; j++) {
                int thisX = i - BoundingBox.X;
                int thisY = j - BoundingBox.Y;
                int otherX = i - other.BoundingBox.X;
                int otherY = j - other.BoundingBox.Y;
                this[thisX, thisY] = operation(this[thisX, thisY], other[otherX, otherY]);
            }
        }

    }

}
