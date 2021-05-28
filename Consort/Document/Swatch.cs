namespace Consort.Document {

    public record Swatch {

        public Swatch(byte character, byte foreground, byte background) {
            Character = character;
            Foreground = foreground;
            Background = background;
        }

        /// <summary>
        ///     Returns the Default swatch, this is a swatch set to the null character and with background and foreground set to 0.
        ///     <br />
        ///     This swatch should be rendered as transparent.
        /// </summary>
        public static Swatch Empty => new(0, 0, 0);

        public byte Character { get; init; }
        public byte Foreground { get; init; }
        public byte Background { get; init; }

        public void Deconstruct(out byte character, out byte foreground, out byte background) {
            character = Character;
            foreground = Foreground;
            background = Background;
        }

        public static Swatch operator +(Swatch a, Swatch b) =>
            new(
                (byte) ((a.Character + b.Character) % 0x100),
                (byte) ((a.Foreground + b.Foreground) % 0x100),
                (byte) ((a.Background + b.Background) % 0x100)
            );

        public static Swatch operator -(Swatch a, Swatch b) =>
            new(
                (byte) ((0x100 + a.Character - b.Character) % 0x100),
                (byte) ((0x100 + a.Foreground - b.Foreground) % 0x100),
                (byte) ((0x100 + a.Background - b.Background) % 0x100)
            );

    }

}
