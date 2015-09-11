using System;
using System.Diagnostics;
using System.Threading;

namespace bavc.ru.Helpers
{
    public static class ShellHelper
    {
        public static string RunShell()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "/home/Publish/bavc.ru/Deploy",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            Process process = Process.Start(processStartInfo);
            if (process != null)
            {
                string outputString = process.StandardOutput.ReadToEnd();
                //Thread.Sleep(TimeSpan.FromSeconds(120));
                process.WaitForExit();
                return outputString;
            }
            else return "Error";
        }
    }
}