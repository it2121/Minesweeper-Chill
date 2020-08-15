using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{

    public partial class Form1 : Form
    {
        public static int xnum = 9;
        public static int ynum = 9;
        public static int minesnum = 10;
        minesweeper mine;
        System.Media.SoundPlayer sp;


        public Form1()
        {


            mine = new minesweeper();

            mine.x = getX();
            mine.y = getY();
            mine.form = this;
            mine.minesAmount = getM();
            mine.createMap();


            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.BackColor = Color.FromArgb(35, panel1.BackColor);
            b1.BackColor = Color.FromArgb(45, b1.BackColor);
            b2.BackColor = Color.FromArgb(45, b2.BackColor);
            b3.BackColor = Color.FromArgb(45, b3.BackColor);
            b4.BackColor = Color.FromArgb(45, b4.BackColor);
            b5.BackColor = Color.FromArgb(45, b5.BackColor);
            button1.BackColor = Color.FromArgb(165, button1.BackColor);



            panel1.SendToBack();
     
            sp = new System.Media.SoundPlayer(@"..\..\Resources\music\0.wav");
            musicisplaying = true;

           // sp.Play();
        }
        void create()
        {


        }
        public int getX()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
            int o = 0;
            int x = 9;
            foreach (string line in lines)
            {

                if (o == 0)
                {
                    x = Convert.ToInt32(line);
                }
                o++;
            }
            return x;
        }
        public int getY()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
            int o = 0;
            int y = 9;
            foreach (string line in lines)
            {

                if (o == 1)
                {
                    y = Convert.ToInt32(line);
                }
                o++;
            }
            return y;
        }
        public int getM()
        {

            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\xym.txt");
            int o = 0;
            int m = 10;
            foreach (string line in lines)
            {

                if (o == 2)
                {
                    m = Convert.ToInt32(line);
                }
                o++;
            }
            return m;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mine.clear();


            mine.createMap();


        }
        int changer = 1;
        int musictrack = 1;
        private void BgCh_Click(object sender, EventArgs e)
        {
            if (changer == 0)
            {



               // this.BackgroundImage = global::Minesweeper.Properties.Resources.b1;

                changer++;
            }
            else if (changer == 1)
            {




               // this.BackgroundImage = global::Minesweeper.Properties.Resources.b2;

                changer++;
            }
            else if (changer == 2)
            {




               // this.BackgroundImage = global::Minesweeper.Properties.Resources.b3;
                changer++;
            }
            else if (changer == 3)
            {




              //  this.BackgroundImage = global::Minesweeper.Properties.Resources.b4;

                changer++;
            }
            else if (changer == 4)
            {




              //  this.BackgroundImage = global::Minesweeper.Properties.Resources.b5;

                changer++;
            }
            else if (changer == 5)
            {



               // this.BackgroundImage = global::Minesweeper.Properties.Resources.b6;

                changer++;
            }
            else if (changer == 6)
            {




               // this.BackgroundImage = global::Minesweeper.Properties.Resources.b7;

                changer = 0;
            }



        }



        private void button2_Click(object sender, EventArgs e)
        {




            sp.Stop();
            sp = new System.Media.SoundPlayer(@"..\..\Resources\music\" + musictrack + ".wav");

            sp.Play();
            musictrack++;
            musicisplaying = true;
            if (musictrack == 7) { musictrack = 0; }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();


        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        public bool musicisplaying = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (musicisplaying)
            {
                sp.Stop();
                b5.Text = "Play Music";
                musicisplaying = false;
            }
            else
            {

                sp.Play();
                b5.Text = "Stop Music";
                musicisplaying = true;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
