using Microsoft.Extensions.Logging;

namespace NETCore.Keycloak.Client.Utils;

/// <summary>
/// Defines structured logging messages for various log levels used throughout the application.
/// </summary>
public static class KcLoggerMessages
{
    /// <summary>
    /// Defines a debug-level log message.
    /// </summary>
    public static readonly Action<ILogger, string, Exception> Debug = (logger, message, exception) =>
    {
        if ( logger != null )
        {
            LoggerMessage.Define<string>(LogLevel.Debug, new EventId(1000, "Debug"), "{Message}")(logger, message,
                exception);
        }
    };

    /// <summary>
    /// Defines an error-level log message.
    /// </summary>
    public static readonly Action<ILogger, string, Exception> Error = (logger, message, exception) =>
    {
        if ( logger != null )
        {
            LoggerMessage.Define<string>(LogLevel.Error, new EventId(1000, "Error"), "{Message}")(logger, message,
                exception);
        }
    };

    /// <summary>
    /// Defines a critical-level log message, indicating a severe failure in the application.
    /// </summary>
    public static readonly Action<ILogger, string, Exception> Critical = (logger, message, exception) =>
    {
        if ( logger != null )
        {
            LoggerMessage.Define<string>(LogLevel.Critical, new EventId(1000, "Critical"), "{Message}")(logger, message,
                exception);
        }
    };

    /// <summary>
    /// Defines an informational log message.
    /// </summary>
    public static readonly Action<ILogger, string, Exception> Information = (logger, message, exception) =>
    {
        if ( logger != null )
        {
            LoggerMessage.Define<string>(LogLevel.Information, new EventId(1000, "Information"), "{Message}")(logger,
                message, exception);
        }
    };
}
