using Dalamud.Plugin.Services;
using Serilog.Events;
using XpahtaLib.DalamudUtilities.Interfaces;

namespace XpahtaLib.DalamudUtilities;

public class XLog : IPluginLogger
{
    private IPluginLog PluginLog { get; }

    public LogEventLevel MinimumLogLevel  { get; set; }
    public bool          LogSensitiveData { get; set; }

    public XLog(IPluginLog pluginLog)
    {
        MinimumLogLevel  = pluginLog.MinimumLogLevel;
        LogSensitiveData = false;
        PluginLog        = pluginLog;
    }

    public void Fatal(string messageTemplate, params object[] values) => PluginLog.Fatal(messageTemplate, values);
    public void FatalSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            Fatal(messageTemplate, values);
        }
    }

    public void Fatal(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Fatal(exception, messageTemplate, values);
    public void FatalSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            Fatal(exception, messageTemplate, values);
        }
    }

    public void Error(string messageTemplate, params object[] values) => PluginLog.Error(messageTemplate, values);
    public void ErrorSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            Error(messageTemplate, values);
        }
    }

    public void Error(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Error(exception, messageTemplate, values);
    public void ErrorSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            Error(exception, messageTemplate, values);
        }
    }

    public void Warning(string messageTemplate, params object[] values) => PluginLog.Warning(messageTemplate, values);
    public void WarningSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Warning(messageTemplate, values);
        }
    }

    public void Warning(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Warning(exception, messageTemplate, values);
    public void WarningSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Warning(exception, messageTemplate, values);
        }
    }

    public void Info(string messageTemplate, params object[] values) => PluginLog.Info(messageTemplate, values);
    public void InfoSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Info(messageTemplate, values);
        }
    }

    public void Info(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Info(exception, messageTemplate, values);
    public void InfoSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Info(exception, messageTemplate, values);
        }
    }

    public void Debug(string messageTemplate, params object[] values) => PluginLog.Debug(messageTemplate, values);
    public void DebugSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Debug(messageTemplate, values);
        }
    }

    public void Debug(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Debug(exception, messageTemplate, values);
    public void DebugSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Debug(exception, messageTemplate, values);
        }
    }

    public void Verbose(string messageTemplate, params object[] values) => PluginLog.Verbose(messageTemplate, values);
    public void VerboseSensitive(string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Verbose(messageTemplate, values);
        }
    }

    public void Verbose(Exception? exception, string messageTemplate, params object[] values) => PluginLog.Verbose(exception, messageTemplate, values);
    public void VerboseSensitive(Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Verbose(exception, messageTemplate, values);
        }
    }

    public void Write(LogEventLevel level, Exception? exception, string messageTemplate, params object[] values) => PluginLog.Write(level, exception, messageTemplate, values);
    public void WriteSensitive(LogEventLevel level, Exception? exception, string messageTemplate, params object[] values)
    {
        if (LogSensitiveData) {
            PluginLog.Write(level, exception, messageTemplate, values);
        }
    }
}
