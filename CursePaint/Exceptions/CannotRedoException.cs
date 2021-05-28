using System;

namespace CursePaint.Exceptions {

    public class CannotRedoException : Exception {

        public CannotRedoException() { }
        public CannotRedoException(string? message) : base(message) { }
        public CannotRedoException(string? message, Exception? innerException) : base(message, innerException) { }

    }

}
