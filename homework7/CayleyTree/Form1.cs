using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private double th1 = 30 * Math.PI / 180;
        private double th2 = 20 * Math.PI / 180;
        private double per1 = 0.6;
        private double per2 = 0.7;
        private double k = 0.8;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.CreateGraphics();
            }
            graphics.Clear(this.BackColor);
            drawCayleeTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private void drawCayleeTree(int n, double x0, double y0, double length, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);
            double x2 = x0 + k * (x1 - x0);
            double y2 = y0 + k * (y1 - y0);
            drawLine(x0, y0, x1, y1);
            drawCayleeTree(n - 1, x1, y1, per1 * length, th + th1);
            drawCayleeTree(n - 1, x2, y2, per2 * length, th - th2);
        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Blue, (int) x0, (int) y0, (int) x1, (int) y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                th1 = double.Parse(textBox1.Text) * Math.PI / 180;
            } catch (Exception exc)
            {
                textBox1.Text = (th1 * 180 / Math.PI).ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                th2 = double.Parse(textBox2.Text) * Math.PI / 180;
            }
            catch (Exception exc)
            {
                textBox2.Text = (th2 * 180 / Math.PI).ToString();
            }
        }
    }
}
