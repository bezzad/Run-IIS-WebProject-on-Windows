using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WinServer
{
    public static class IISExpress
    {
        private static readonly List<string> sites = new List<string>();
        private static readonly List<string> paths = new List<string>();

        public static void StartIISExpress(string site, int port = 7329)
        {
            if (!sites.Contains(site.ToLower()))
                sites.Add(site.ToLower());
            else return;

            var index = Environment.CurrentDirectory.LastIndexOf("\\bin\\");
            var projectDir = Environment.CurrentDirectory.Remove(index);
            var solutionDir = System.IO.Directory.GetParent(projectDir);
            var path = solutionDir + "\\" + site;

            var arguments = new StringBuilder();
            arguments.Append(@"/path:");
            arguments.Append(path);
            arguments.Append(@" /Port:" + port);
            // arguments.Append(@"/site:" + site);
            var process = Process.Start(new ProcessStartInfo()
            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }


        public static void StartIISExpressFromPath(string path, int port = 7329)
        {
            if (!paths.Contains(path.ToLower()))
                paths.Add(path.ToLower());
            else return;

            var arguments = new StringBuilder();
            arguments.Append(@"/path:" + path);
            arguments.Append(@" /Port:" + port);
            var process = Process.Start(new ProcessStartInfo()
            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }
    }
}
