using System.Diagnostics;
using System.IO;
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
            File.WriteAllText("shell.log", outputString);
            outputString = outputString.Replace("\n", "<br>");
            File.WriteAllText("shell.web", outputString);
            return outputString;
        }
    }
}