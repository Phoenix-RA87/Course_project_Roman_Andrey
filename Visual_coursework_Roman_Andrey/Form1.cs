using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Визуальный_курсовой
{
    public partial class Form1 : Form
    {
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


        public static double Rectangle(double n)
        {
            double h = 1 / n;
            double summ = 0, y = 0, S = 0;
            for (double i = h / 2; i < 1; i += h)
            {
                y = Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2));
                //  Console.WriteLine("y({0}) = {1}", i, y);
                summ += y;
            }
            S = h * summ;
         //   Console.WriteLine("Значение определённого интеграла," +
         //      "\nвычисленное с помощью метода прямоугольников = {0}", S);
            return S;
        }
        public static double Trapezoid(double n)
        {
            double h = 1 / n;
            double summ1 = 0, y = 0, S = 0, summ2;
            for (double i = h; i < 1; i += h)
            {
                y = Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2));
                // Console.WriteLine("y({0}) = {1}", i, y);
                summ1 += y;
            }
            summ2 = (Math.Cos(0) + (Math.Cos(2) / 2)) / 2;
            S = h * (summ1 + summ2);
         //   Console.WriteLine("Значение определённого интеграла," +
         //      "\nвычисленное с помощью метода прямоугольников = {0}", S);
            return S;
        }
        public static double Sympson(double n)
        {
            n *= 2;
            int q = 1;
            double h = 1 / n;
            double summ1 = 0, y = 0, S = 0, summ2 = 0, summ3;
            for (double i = h; i < 1; i += h)
            {
                y = Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2));
                // Console.WriteLine("y({0}) = {1}", i, y);
                if (q % 2 == 0) summ1 += y;
                else summ2 += y;
                q++;
            }
            summ3 = (Math.Cos(0) + (Math.Cos(2) / 2));
            S = h / 3 * (2 * summ1 + 4 * summ2 + summ3);
           // Console.WriteLine("Значение определённого интеграла," +
           //    "\nвычисленное с помощью метода прямоугольников = {0}", S);
            return S;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frmAbout = new Form3();
            frmAbout.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            chart1.Series[0].Points.Clear();
            Rectangle(n);
            for (double i = 0; i < 1; i+=0.1)
            {
                chart1.Series[0].Points.AddXY(i, Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2)));
            }
            double t = Rectangle (Convert.ToDouble(textBox1.Text));
            label3.Text=Convert.ToString(t);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            chart1.Series[0].Points.Clear();
            Sympson(n);
            for (double i = 0; i < 1; i += 0.1)
            {
                chart1.Series[0].Points.AddXY(i, Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2)));
            }
            double t = Sympson(Convert.ToDouble(textBox1.Text));
            label3.Text = Convert.ToString(t);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            chart1.Series[0].Points.Clear();
            Trapezoid(n);
            for (double i = 0; i < 1; i += 0.1)
            {
                chart1.Series[0].Points.AddXY(i, Math.Cos(i + Math.Pow(i, 3)) / (1 + Math.Pow(i, 2)));
            }
            double t = Trapezoid(Convert.ToDouble(textBox1.Text));
            label3.Text = Convert.ToString(t);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
