using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace bavc.ru.Helpers
{
    public static class ShellHelper
    {
        public static string RunShell()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "/home/Publish/bavc.ru/Deploy";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            Process process = Process.Start(processStartInfo);
            string outputString = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return outputString;
        }
    }
}