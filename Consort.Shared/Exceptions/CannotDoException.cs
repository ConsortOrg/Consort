using System;

namespace Consort.Shared.Exceptions {

    public class CannotDoException : Exception {

        public CannotDoException() { }
        public CannotDoException(string? message) : base(message) { }
        public CannotDoException(string? message, Exception? innerException) : base(message, innerException) { }

    }

}
