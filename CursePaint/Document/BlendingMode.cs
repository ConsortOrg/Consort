using System;

namespace CursePaint.Document
{
    [Flags]
    public enum BlendingMode
    {
        None =       0b0000,
        Character =  0b0001,
        Foreground = 0b0010,
        Background = 0b0100,
    }
}