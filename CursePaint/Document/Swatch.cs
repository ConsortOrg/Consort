namespace CursePaint.Document
{
    public record Swatch
    {
        /// <summary>
        /// Returns the Default swatch, this is a swatch set to the null character and with background and foreground set to 0.<br/>
        /// This swatch should be rendered as transparent.
        /// </summary>
        public static Swatch Default => new(0, 0, 0);
        
        public Swatch(byte Character, byte Foreground, byte Background)
        {
            this.Character = Character;
            this.Foreground = Foreground;
            this.Background = Background;
        }
        public byte Character { get; init; }
        public byte Foreground { get; init; }
        public byte Background { get; init; }

        public void Deconstruct(out byte Character, out byte Foreground, out byte Background)
        {
            Character = this.Character;
            Foreground = this.Foreground;
            Background = this.Background;
        }
    }
}
