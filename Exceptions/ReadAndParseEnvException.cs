using System;

public class ReadAndParseEnvException : Exception
{
    public ReadAndParseEnvException() { }

    public ReadAndParseEnvException(string message) : base(message) { }

    public ReadAndParseEnvException(string message, Exception innerException) 
        : base(message, innerException) { }
}
