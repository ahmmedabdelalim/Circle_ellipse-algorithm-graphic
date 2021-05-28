using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circle
{
    public partial class Form1 : Form
    {

         
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Xc_Click(object sender, EventArgs e)
        {

        }



        //////// Draw circle  
        void circlepoints(int xcenter, int ycenter, int i, int k)
        {
             
            var brush = Brushes.Red;
            var g = panel1.CreateGraphics();
            g.FillRectangle(brush, xcenter + i, ycenter + k, 1, 1);
            g.FillRectangle(brush, xcenter - i, ycenter + k, 1, 1);
            g.FillRectangle(brush, xcenter + i, ycenter - k, 1, 1);
            g.FillRectangle(brush, xcenter - i, ycenter - k, 1, 1);
            g.FillRectangle(brush, xcenter + k, ycenter + i, 1, 1);
            g.FillRectangle(brush, xcenter - k, ycenter + i, 1, 1);
            g.FillRectangle(brush, xcenter + k, ycenter - i, 1, 1);
            g.FillRectangle(brush, xcenter - k, ycenter - i, 1, 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Xc = Convert.ToInt32(textBox1.Text);
            int Yc = Convert.ToInt32(textBox2.Text);

            int r = Convert.ToInt32(textBox3.Text);

            int x = 0;
            int y = r;
            int p = (3 - 2 * r);

            circlepoints(Xc, Yc, x, y);
            while (x <= y)
            {
                x++;
                if (p > 0)
                {
                    y--;
                    p = p + 4 * (x - y) + 10;
                }
                else
                {
                    p = p + 4 * x + 6;
                }
                circlepoints(Xc, Yc, x, y);
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


         
        // // /// Draw Ellipse
        private void button2_Click(object sender, EventArgs e)
        {
            int X = Convert.ToInt32(textBox1.Text);
            int Y = Convert.ToInt32(textBox2.Text);
            int Rx = Convert.ToInt32(textBox4.Text);
            int Ry = Convert.ToInt32(textBox5.Text);

            Point p1 = new Point(X, Y);
            Bitmap Bit = new Bitmap(this.Width, this.Height);

            ellipseMidpoint(p1, Rx, Ry, Bit);

        }

        void ellipseMidpoint(Point p1, int Rx, int Ry, Bitmap Bit)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            double p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;

            p = Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            ellipsePlotPoints(p1.X, p1.Y, x, y, Bit);

            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }

                ellipsePlotPoints(p1.X, p1.Y, x, y, Bit);
            }

            /* Region 2 */
            p = Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }

                ellipsePlotPoints(p1.X, p1.Y, x, y, Bit);
            }
        }
        private void ellipsePlotPoints(int xCenter, int yCenter, int x, int y, Bitmap Bit)
        {

            Bit.SetPixel(xCenter + x, yCenter + y, Color.Red);
            Bit.SetPixel(xCenter - x, yCenter + y, Color.Red);
            Bit.SetPixel(xCenter + x, yCenter - y, Color.Red);
            Bit.SetPixel(xCenter - x, yCenter - y, Color.Red);
            pictureBox1.Image = Bit;
        }
    }
}
