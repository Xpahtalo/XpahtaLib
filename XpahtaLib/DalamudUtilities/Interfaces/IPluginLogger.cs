using Serilog.Events;

namespace XpahtaLib.DalamudUtilities.Interfaces;

public interface IPluginLogger
{
    LogEventLevel MinimumLogLevel  { get; set; }
    bool          LogSensitiveData { get; set; }

    void Fatal(string              messageTemplate, params object[] values);
    void FatalSensitive(string     messageTemplate, params object[] values);
    void Fatal(Exception?          exception,       string          messageTemplate, params object[] values);
    void FatalSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Error(string              messageTemplate, params object[] values);
    void ErrorSensitive(string     messageTemplate, params object[] values);
    void Error(Exception?          exception,       string          messageTemplate, params object[] values);
    void ErrorSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Warning(string              messageTemplate, params object[] values);
    void WarningSensitive(string     messageTemplate, params object[] values);
    void Warning(Exception?          exception,       string          messageTemplate, params object[] values);
    void WarningSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Info(string              messageTemplate, params object[] values);
    void InfoSensitive(string     messageTemplate, params object[] values);
    void Info(Exception?          exception,       string          messageTemplate, params object[] values);
    void InfoSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Debug(string              messageTemplate, params object[] values);
    void DebugSensitive(string     messageTemplate, params object[] values);
    void Debug(Exception?          exception,       string          messageTemplate, params object[] values);
    void DebugSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Verbose(string              messageTemplate, params object[] values);
    void VerboseSensitive(string     messageTemplate, params object[] values);
    void Verbose(Exception?          exception,       string          messageTemplate, params object[] values);
    void VerboseSensitive(Exception? exception,       string          messageTemplate, params object[] values);

    void Write(LogEventLevel          level, Exception? exception, string messageTemplate, params object[] values);
    void WriteSensitive(LogEventLevel level, Exception? exception, string messageTemplate, params object[] values);
}
