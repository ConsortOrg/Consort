using System.Drawing;

namespace Consort.Document {

    public interface IReadOnlyLayer {

        public Size Size { get; }
        public Point Offset { get; }
        public Swatch this[int x, int y] { get; }

    }

}
