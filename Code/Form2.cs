using System;
using System.Drawing;
using System.Windows.Forms;

namespace nethost
{
    public partial class Form2 : Form
    {
        int i = 0;
        Random rm=new Random();
        public Form2(int x,int y)
        {
            Left = x;
            Top = y;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            i = rm.Next(0, 20);
            timer1.Interval = rm.Next(1, 500);
            switch (i)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources._0;
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources._0;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._6;
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources._7;
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources._8;
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources._9;
                    break;
                case 10:
                    pictureBox1.Image = Properties.Resources._0;
                    break;
                case 11:
                    pictureBox1.Image = Properties.Resources._11;
                    break;
                case 12:
                    pictureBox1.Image = Properties.Resources._12;
                    break;
                case 13:
                    pictureBox1.Image = Properties.Resources._13;
                    break;
                case 14:
                    pictureBox1.Image = Properties.Resources._14;
                    break;
                case 15:
                    pictureBox1.Image = Properties.Resources._15;
                    break;
                case 16:
                    pictureBox1.Image = Properties.Resources._16;
                    break;
                case 17:
                    pictureBox1.Image = Properties.Resources._17;
                    break;
                case 18:
                    pictureBox1.Image = Properties.Resources._18;
                    break;
                case 19:
                    pictureBox1.Image = Properties.Resources._19;
                    break;
            }
        }
    }
}
