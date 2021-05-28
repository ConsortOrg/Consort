using System;
using System.Drawing;

namespace CursePaint.Document {

    public partial class Layer {

        public class Builder {

            public Builder Empty() {
                IsEmpty = true;
                return this;
            }

            public Builder WithName(string name) {
                Name = name;
                return this;
            }

            public Builder WithSize(Size size) {
                Size = size;
                return this;
            }

            private string Name { get; set; } = "New Layer";

            private Size Size { get; set; } = new Size(1, 1);

            public bool IsEmpty { get; set; }

            public Layer Build() {
                Rectangle boundingBox = new(0, 0, Size.Width, Size.Height);

                if (IsEmpty) {
                    return new Layer(Name, Canvas.EmptyWithBox(boundingBox));
                }

                throw new NotImplementedException();
            }

        }

    }

}
