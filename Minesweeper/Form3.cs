using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            p1.BackColor = Color.FromArgb(90, p1.BackColor);
            st1.Text = get1();
            st2.Text = get2();
            st3.Text = get3();




        }
        public string get1()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st1.txt");
            int o = 0;
            int m = 0;
            foreach (string line in lines)
            {

                if (o == 0)
                {
                    m = Convert.ToInt32(line);
                }
                o++;
            }

            int mints = m / 60;
            int secconds = m % 60;
            string str = mints + ":" + secconds;

            return str;
        }
        public string get2()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st2.txt");
            int o = 0;
            int m = 0;
            foreach (string line in lines)
            {

                if (o == 0)
                {
                    m = Convert.ToInt32(line);
                }
                o++;
            }

            int mints = m / 60;
            int secconds = m % 60;
            string str = mints + ":" + secconds;

            return str;
        }
        public string get3()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st3.txt");
            int o = 0;
            int m = 0;
            foreach (string line in lines)
            {

                if (o == 0)
                {
                    m = Convert.ToInt32(line);
                }
                o++;
            }

            int mints = m / 60;
            int secconds = m % 60;
            string str = mints + ":" + secconds;

            return str;
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        public void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
