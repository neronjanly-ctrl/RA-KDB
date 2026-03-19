using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CommonTools;

public static class ExternalCommand
{
    public static bool RunAndWaitNoInput(string program, string argument, out string stdout, out string stderr, int maxRunTime = Timeout.Infinite)
    {
        try
        {
            //* Create your Process
            using (Process process = new())
            {
                process.StartInfo.FileName = program;
                process.StartInfo.Arguments = argument;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                StringBuilder sberr = new();

                //* Set ONLY ONE handler here.
                process.ErrorDataReceived += (sender, e) =>
                {
                    sberr.AppendLine(e.Data);
                };

                //* Start process
                process.Start();

                //* Read one element asynchronously
                process.BeginErrorReadLine();

                //* Read the other one synchronously
                stdout = process.StandardOutput.ReadToEnd();

                if (maxRunTime == Timeout.Infinite)
                {
                    process.WaitForExit();
                    stderr = sberr.ToString();
                    return true;
                }
                else if (process.WaitForExit(maxRunTime))
                {
                    stderr = sberr.ToString();
                    return true;
                }
                else
                {
                    process.Kill();
                    stderr = null;
                    return false;
                }
            }
        }
        catch (Exception)
        {
            stdout = null;
            stderr = null;
            return false;
        }
    }

    private static bool RunInternal(
        string program, string argument, string workdir,
        string stdin, StringBuilder stdout, StringBuilder stderr,
        bool waitForExit, int maxRunTime)
    {
        bool withStdin = !string.IsNullOrEmpty(stdin);
        bool withStdout = stdout != null;
        bool withStderr = stderr != null;

        using (Process proc = new()
        {
            EnableRaisingEvents = true,
            StartInfo = new ProcessStartInfo
            {
                WorkingDirectory = workdir,
                FileName = program,
                Arguments = argument,
                CreateNoWindow = true,
                ErrorDialog = false,
                UseShellExecute = false,
                RedirectStandardInput = withStdin,
                RedirectStandardOutput = withStdout,
                RedirectStandardError = withStderr,
            }
        })
        {
            try
            {
                using (AutoResetEvent stdoutWaitHandle = withStdout ? new AutoResetEvent(false) : null, stderrWaitHandle = withStderr ? new AutoResetEvent(false) : null)
                {
                    if (withStdout)
                        proc.OutputDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                                stdoutWaitHandle.Set();
                            else
                                stdout.AppendLine(e.Data);
                        };

                    if (withStderr)
                        proc.ErrorDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                                stderrWaitHandle.Set();
                            else
                                stderr.AppendLine(e.Data);
                        };

                    // Must start before writing to intput and reading from output/error
                    proc.Start();

                    if (withStdin)
                    {
                        proc.StandardInput.WriteLine(stdin);
                        proc.StandardInput.Close();
                    }

                    // asynchronized reading from output/error to avoid deadlocks
                    if (withStdout)
                        proc.BeginOutputReadLine();

                    if (withStderr)
                        proc.BeginErrorReadLine();

                    if (waitForExit)
                    {
                        if (proc.WaitForExit(maxRunTime))
                        {
                            if (withStdout)
                                stdoutWaitHandle.WaitOne(maxRunTime);
                            if (withStderr)
                                stderrWaitHandle.WaitOne(maxRunTime);
                            return true;
                        }
                        else
                        {
                            if (withStdout)
                                proc.CancelOutputRead();
                            if (withStderr)
                                proc.CancelErrorRead();
                            proc.Kill();
                            throw new Exception($"Process '{program} {argument} {stdin}' terminated");
                        }
                    }

                    // Dispose() calls Close() when the end of the using block is reached

                    return true;
                }
            }
            catch (Exception)
            {
                if (withStdout)
                    stdout.Clear();

                if (withStderr)
                    stderr.Clear();

                return false;
            }
        }
    }

    #region RunNoWait with optional parameters
    public static bool RunNoWait(string program, string argument = null, string workdir = null, string stdin = null)
    {
        return RunInternal(program, argument, workdir, stdin, null, null, false, 0);
    }
    #endregion

    #region 7 RunAndWait overloads: one without argument and workdir and 6 others with (), (out stdout), (out stdout, out stderr), (stdin), (stdin, out stdout), (stdin, out stdout, out stderr)
    public static bool RunAndWait(string program, int maxRunTime = Timeout.Infinite)
    {
        return RunInternal(program, null, null, null, null, null, true, maxRunTime);
    }

    public static bool RunAndWait(string program, string argument, string workdir, int maxRunTime = Timeout.Infinite)
    {
        return RunInternal(program, argument, workdir, null, null, null, true, maxRunTime);
    }

    public static bool RunAndWait(string program, string argument, string workdir, out string stdout, int maxRunTime = Timeout.Infinite)
    {
        return RunAndWait(program, argument, workdir, null, out stdout, maxRunTime);
    }

    public static bool RunAndWait(string program, string argument, string workdir, out string stdout, out string stderr, int maxRunTime = Timeout.Infinite)
    {
        return RunAndWait(program, argument, workdir, null, out stdout, out stderr, maxRunTime);
    }

    public static bool RunAndWait(string program, string argument, string workdir, string stdin, int maxRunTime = Timeout.Infinite)
    {
        return RunInternal(program, argument, workdir, stdin, null, null, true, maxRunTime);
    }

    public static bool RunAndWait(string program, string argument, string workdir, string stdin, out string stdout, int maxRunTime = Timeout.Infinite)
    {
        StringBuilder sbout = new();

        if (RunInternal(program, argument, workdir, stdin, sbout, null, true, maxRunTime))
        {
            stdout = sbout.ToString();
            return true;
        }
        else
        {
            stdout = null;
            return false;
        }
    }

    public static bool RunAndWait(string program, string argument, string workdir, string stdin, out string stdout, out string stderr, int maxRunTime = Timeout.Infinite)
    {
        StringBuilder sbout = new();
        StringBuilder sberr = new();

        if (RunInternal(program, argument, workdir, stdin, sbout, sberr, true, maxRunTime))
        {
            stdout = sbout.ToString();
            stderr = sberr.ToString();
            return true;
        }
        else
        {
            stdout = null;
            stderr = null;
            return false;
        }
    }
    #endregion
}
