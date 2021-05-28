using System;
using System.Drawing;

namespace CursePaint.Document {

    public partial class Layer {

        private Layer(string name, Canvas contents) {
            Name = name;
            Contents = contents;
        }

        public string Name { get; set; }
        public Canvas Contents { get; set; }

    }

}
