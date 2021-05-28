using System;

namespace CursePaint.Exceptions {

    public class CannotDoException : Exception {

        public CannotDoException() { }
        public CannotDoException(string? message) : base(message) { }
        public CannotDoException(string? message, Exception? innerException) : base(message, innerException) { }

    }

}
