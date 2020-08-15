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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            p1.BackColor = Color.FromArgb(90, p1.BackColor);
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (r1.Checked)
            {

            
               /* Form1.xnum = 9;
                Form1.ynum = 9;
                Form1.minesnum = 10;*/


                var lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
                lines[0] = "9";
                lines[1] = "9";
                lines[2] = "10";
                System.IO.File.WriteAllLines(@"..\..\Resources\values\xym.txt", lines);
                Application.Restart();



                this.Close();

            }
            else if (r2.Checked)
            {
               

                var lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
                lines[0] = "16";
                lines[1] = "16";
                lines[2] = "40";
                System.IO.File.WriteAllLines(@"..\..\Resources\values\xym.txt", lines);
                Application.Restart();

                this.Close();
            }
            else if (r3.Checked)
            {
                


                var lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
                lines[0] = "23";
                lines[1] = "23";
                lines[2] = "99";
                System.IO.File.WriteAllLines(@"..\..\Resources\values\xym.txt", lines);

                this.Close();
            }
            else if (cs.Checked)
            {
                if (t1.Value < 23 && t1.Value > 9 && t2.Value > 9 && t2.Value < 23 && t3.Value > 10 && t3.Value < 668)
                {


                    Application.Restart();
                    Form1.xnum =(int) t1.Value;
                    Form1.ynum = (int)t2.Value;
                    Form1.minesnum = (int)t3.Value;



                    var lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
                    lines[0] = (int)t1.Value+"";
                    lines[1] = (int)t2.Value + "";
                    lines[2] = (int)t3.Value + "";
                    System.IO.File.WriteAllLines(@"..\..\Resources\values\xym.txt", lines);
                    this.Close();

                }
                else {

                    MessageBox.Show("Out of Range!");
                }

            }


           

        }
    }
}
