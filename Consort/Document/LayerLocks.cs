using System;

namespace Consort.Document {

    [Flags]
    public enum LayerLocks {

        None = 0b0000,
        Transparency = 0b0001,
        Foreground = 0b0010,
        Background = 0b0100,
        Character = 0b1001,

    }

}
