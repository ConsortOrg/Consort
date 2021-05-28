using System;

namespace Consort.Shared.Exceptions {

    public class CannotUndoException : Exception {

        public CannotUndoException() { }
        public CannotUndoException(string? message) : base(message) { }
        public CannotUndoException(string? message, Exception? innerException) : base(message, innerException) { }

    }

}
