using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.IO;

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
            File.WriteAllText("shell.log", outputString);
            process.WaitForExit();
            return outputString;
        }
    }
}