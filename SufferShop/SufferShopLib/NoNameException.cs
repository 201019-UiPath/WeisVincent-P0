using System;

public class NoNameException : Exception {

    public override string Message {
        get {
            return "The name cannot be blank.";
        }
    }

    public NoNameException() {
        
    }

    public NoNameException(string message) : base(message) {

    }
    public NoNameException(string message, Exception inner) : base(message, inner) {

    }
}