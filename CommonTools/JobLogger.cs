using System;
using System.Diagnostics;
using System.Text;

namespace CommonTools;

public class JobLogger
{
    private readonly bool[] _showFlags = { true, true, true };
    public void ShowInfo(bool show) => _showFlags[0] = show;
    public void ShowWarn(bool show) => _showFlags[1] = show;
    public void ShowError(bool show) => _showFlags[2] = show;

    private readonly Stopwatch _globalStopwatch = new();
    public void BeginLog(Type program, string workdir)
    {
        Log($"************* {program.Assembly.GetName().Name} v{program.Assembly.GetName().Version} *************");
        Log();
        Log($"Machine Name: {Environment.MachineName}");
        Log($"Work directory: {workdir}");
        Log($"Started at {DateTimeOffset.Now:s}");
        _globalStopwatch.Restart();
    }

    public void EndLog()
    {
        Log();
        Log($"Ended at {DateTimeOffset.Now:s}, Time elapsed: {_globalStopwatch.Elapsed:g}");
        _globalStopwatch.Stop();
    }

    [ThreadStatic]
    private static string _proteinName = null;
    [ThreadStatic]
    private static Stopwatch _proteinStopwatch = null;
    [ThreadStatic]
    private static StringBuilder _stringBuilder = null;

    public void PushProtein(string proteinName)
    {
        _stringBuilder = new StringBuilder();
        _proteinName = proteinName;
        _proteinStopwatch = Stopwatch.StartNew();
        Log();
        Log($"BEGIN {_proteinName}, Current time: {DateTimeOffset.Now:s}");
    }

    public void PopProtein()
    {
        Log($"END {_proteinName}, Time elapsed: {_proteinStopwatch.Elapsed:g}");
        _proteinName = null;
        _proteinStopwatch.Stop();
        _proteinStopwatch = null;
        Console.Write(_stringBuilder.ToString());
        _stringBuilder = null;
    }

    private string _jobName;
    public void PushJob(string jobName) => _jobName = jobName;
    public void PopJob() => _jobName = null;

    public void Log() => Log(string.Empty);
    public void Log(string message)
    {
        if (_stringBuilder == null)
        {
            Console.WriteLine(message);
        }
        else
        {
            _stringBuilder.AppendLine(message);
        }
    }

    public void Log(string level, string message) => Log($"{(_proteinName != null || _jobName != null ? "    " : "")}[{level}][{DateTimeOffset.Now:s}]{(_proteinName == null ? "" : $"[{_proteinName}]")}{(_jobName == null ? "" : $"[{_jobName}]")} {message}");

    private void ConditionalLog(bool show, string level, string message)
    {
        if (show)
            Log(level, message);
    }

    public void Info(string message) => ConditionalLog(_showFlags[0], "INFO", message);
    public void Warn(string message) => ConditionalLog(_showFlags[1], "WARN", message);
    public void Error(string message) => ConditionalLog(_showFlags[2], "ERROR", message);
    public void Error(Exception exception) => ConditionalLog(_showFlags[2], "ERROR", exception.Message);
    public void Error(string message, Exception exception) => ConditionalLog(_showFlags[2], "ERROR", $"{message}, message: {exception.Message}");
}
