using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class minesweeper
    {

        public int x { get; set; }
        public int y { get; set; }
        public int minesAmount { get; set; }
        public Form form { get; set; }
        bool[,] mines;
        int[,] grid;
        int[,] EAG;
        int prog;
        Panel p;
        Label pro;
        Label timel;
        bool recreate = false;
        int index;
        int timeSecondsCounter = 0;
        Timer timer;
        Stopwatch sw;
        int[,] tempGrid;
        public bool faild = false;
        public bool firstClick = true;
        int con = 0;
        ///preSet for recreate map
        public void clear()
        {

            recreate = true;

        }
        //creating the random arrays that holds the data of the specified X and Y
        public void createMinessAndGrid()
        {
            int counter = minesAmount;
            mines = new bool[x, y];
            grid = new int[x, y];
            EAG = new int[x, y];
            Random random = new Random();


            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    mines[i, j] = false;
                    grid[i, j] = 0;
                    EAG[i, j] = 0;

                }
            }
            while (counter != 0)
            {
                int randx = random.Next(x);
                int randy = random.Next(y);
                if (mines[randx, randy] == false)
                {
                    mines[randx, randy] = true;

                    counter--;
                    if ((randx > 0) && (randy > 0) && (randx + 1 <= x - 1) && (randy + 1 <= y - 1))
                    {
                        grid[randx - 1, randy - 1]++;
                        grid[randx - 1, randy]++;
                        grid[randx - 1, randy + 1]++;
                        grid[randx, randy - 1]++;
                        grid[randx, randy + 1]++;
                        grid[randx + 1, randy + 1]++;
                        grid[randx + 1, randy - 1]++;
                        grid[randx + 1, randy]++;

                    }
                    else if (randy == 0 && randx > 0 && randx < x - 1)
                    {

                        grid[randx + 1, 1]++;
                        grid[randx - 1, 1]++;
                        grid[randx, 1]++;
                        grid[randx + 1, 0]++;
                        grid[randx - 1, 0]++;
                        grid[randx, 0]++;



                    }

                    else if (randy == y - 1 && randx > 0 && randx < x - 1)
                    {

                        grid[randx + 1, y - 2]++;
                        grid[randx - 1, y - 2]++;
                        grid[randx, y - 2]++;
                        grid[randx + 1, y - 1]++;
                        grid[randx - 1, y - 1]++;
                        grid[randx, y - 1]++;



                    }
                    else if (randx == 0 && randy > 0 && randy < y - 1)
                    {
                        grid[1, randy + 1]++;
                        grid[1, randy - 1]++;
                        grid[1, randy]++;

                        grid[0, randy + 1]++;
                        grid[0, randy - 1]++;
                        grid[0, randy]++;



                    }

                    else if (randx == x - 1 && randy > 0 && randy < y - 1)
                    {

                        grid[x - 2, randy + 1]++;
                        grid[x - 2, randy - 1]++;
                        grid[x - 2, randy]++;

                        grid[x - 1, randy + 1]++;
                        grid[x - 1, randy - 1]++;
                        grid[x - 1, randy]++;
                    }

                }


            }

            if (mines[0, 0] == true)
            {
                grid[0, 1]++;
                grid[1, 0]++;
                grid[1, 1]++;

            }
            if (mines[x - 1, 0] == true)
            {
                grid[x - 2, 1]++;
                grid[x - 1, 1]++;
                grid[x - 2, 0]++;

            }


            if (mines[x - 1, y - 1] == true)
            {
                grid[x - 1, y - 2]++;
                grid[x - 2, y - 1]++;
                grid[x - 2, y - 2]++;

            }
            if (mines[0, y - 1] == true)
            {
                grid[1, y - 2]++;
                grid[0, y - 2]++;
                grid[1, y - 1]++;

            }






        }
        //Timer update handler
        private void timer_Tick(object sender, EventArgs e)
        {

            timel.Text = sw.Elapsed.Minutes + ":" + sw.Elapsed.Seconds;
            timeSecondsCounter++;
            Application.DoEvents();
        }



        //creting the buttons map using the arrays and adding it to the panel 
        public void createMap()

        {
            firstClick = true;

            faild = false;

            createMinessAndGrid();
            emptyAreasGrid();
            prog = x * y - minesAmount;

            timer = new Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
            sw = new Stopwatch();

            if (recreate == false)
            {

                p = new Panel() { Width = 500, Height = 500 };
                p.BackColor = Color.FromArgb(160, Color.Black);
                index = 0;
                pro = new Label() { Name = "testing", Text = "" + prog, Width = 60 };
                timel = new Label() { Name = "timel", Text = "0:0", Width = 60 };
                pro.Location = new Point(200, 75);
                timel.Location = new Point(270, 75);
                pro.TextAlign = ContentAlignment.MiddleCenter;
                timel.TextAlign = ContentAlignment.MiddleCenter;
                pro.ForeColor = Color.White;
                timel.ForeColor = Color.White;
                pro.Font = new System.Drawing.Font("GamePixies", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                timel.Font = new System.Drawing.Font("GamePixies", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                pro.BringToFront();
                timel.BringToFront();

                pro.BackColor = Color.Transparent;
                timel.BackColor = Color.Transparent;


                form.Controls.Add(pro);
                form.Controls.Add(timel);

                p.Location = new Point(15, 105);
                p.BorderStyle = BorderStyle.None;

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {


                        Button b = new Button() { Name = "0", Text = "A" + "", Width = 490 / x, Height = 490 / y, TabIndex = index };
                        Label l = new Label() { Name = i + "-" + j, Width = 490 / x, Height = 490 / y, TabIndex = index };
                        b.Click += new System.EventHandler(this.ClickedButton);
                        b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button6_MouseUp);

                        b.BackColor = Color.Black;
                        b.Visible = true;

                        b.BackColor = Color.Transparent;
                        b.BackgroundImage = global::Minesweeper.Properties.Resources.em;
                        b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        l.ForeColor = Color.White;

                        b.FlatAppearance.BorderColor = Color.LightGray;
                        b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        l.BackColor = Color.Transparent;

                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Font = new System.Drawing.Font("GamePixies", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        b.TextAlign = ContentAlignment.MiddleCenter;

                        if (mines[i, j] == true)
                        {
                            b.Name = "0";
                            b.Text = "B";

                            l.BackgroundImage = global::Minesweeper.Properties.Resources.mmmm;
                            l.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

                        }
                        else if (grid[i, j] != -1)
                        {
                            l.Text = grid[i, j] + "";
                            if (grid[i, j] == 1)
                            {
                                l.ForeColor = Color.LightBlue;

                            }
                            else if (grid[i, j] == 2)
                            {
                                l.ForeColor = Color.LightGreen;
                            }
                            else if (grid[i, j] == 3)
                            {
                                l.ForeColor = Color.LightPink;
                            }
                            else if (grid[i, j] == 4)
                            {
                                l.ForeColor = Color.LightCyan;
                            }
                            else if (grid[i, j] == 5)
                            {
                                l.ForeColor = Color.LightCoral;
                            }
                            else if (grid[i, j] == 6)
                            {
                                l.ForeColor = Color.Yellow;
                            }
                            else if (grid[i, j] == 7)
                            {
                                l.ForeColor = Color.Pink;
                            }
                            else if (grid[i, j] == 8)
                            {
                                l.ForeColor = Color.Red;
                            }

                            b.Text = "N";
                        }
                        if (EAG[i, j] != 0)
                        {
                            b.Text = "E";
                            b.Name = EAG[i, j] + "";
                        }




                        b.Location = new Point((i * 500 / x), (j * 500 / y));
                        l.Location = new Point((i * 500 / x), (j * 500 / y));
                        p.Controls.Add(b);
                        p.Controls.Add(l);

                        index++;

                    }
                }

                form.Controls.Add(p);


            }
            else
            {
                timel.Text = "0:0";
                timer.Stop();

                sw.Stop();

                pro.Text = prog + "";


                int iinndd = 0;
                int i = 0, j = 0;

                while (iinndd < index)
                {

                    foreach (var item in p.Controls)
                    {

                        if (item is Button)
                        {

                            int id = ((Button)item).TabIndex;
                            if (id == iinndd)
                            {
                                ((Button)item).Name = "0";
                                ((Button)item).Text = "A";
                                ((Button)item).Visible = true;
                                ((Button)item).Enabled = true;
                                ((Button)item).BackgroundImage = global::Minesweeper.Properties.Resources.em;
                                ((Button)item).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                                if (mines[i, j] == true)
                                {
                                    ((Button)item).Name = "0";
                                    ((Button)item).Text = "B";


                                }
                                else if (grid[i, j] != -1)
                                {

                                    ((Button)item).Text = "N";
                                }
                                if (EAG[i, j] != 0)
                                {
                                    ((Button)item).Text = "E";
                                    ((Button)item).Name = EAG[i, j] + "";
                                }







                            }

                        }

                        if (item is Label)
                        {

                            int id = ((Label)item).TabIndex;
                            if (id == iinndd)
                            {

                                ((Label)item).Text = "";
                                ((Label)item).ForeColor = Color.White;
                                ((Label)item).BackgroundImage = null;
                                if (mines[i, j] == true)
                                {



                                    ((Label)item).BackgroundImage = global::Minesweeper.Properties.Resources.mmmm;
                                    ((Label)item).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

                                }
                                else if (grid[i, j] != -1)
                                {
                                    if (grid[i, j] == 1)
                                    {
                                        ((Label)item).ForeColor = Color.LightBlue;

                                    }
                                    else if (grid[i, j] == 2)
                                    {
                                        ((Label)item).ForeColor = Color.LightGreen;
                                    }
                                    else if (grid[i, j] == 3)
                                    {
                                        ((Label)item).ForeColor = Color.LightPink;
                                    }
                                    else if (grid[i, j] == 4)
                                    {
                                        ((Label)item).ForeColor = Color.LightCyan;
                                    }
                                    else if (grid[i, j] == 5)
                                    {
                                        ((Label)item).ForeColor = Color.LightCoral;
                                    }
                                    else if (grid[i, j] == 6)
                                    {
                                        ((Label)item).ForeColor = Color.Yellow;
                                    }
                                    else if (grid[i, j] == 7)
                                    {
                                        ((Label)item).ForeColor = Color.Pink;
                                    }
                                    else if (grid[i, j] == 8)
                                    {
                                        ((Label)item).ForeColor = Color.Red;
                                    }
                                    ((Label)item).Text = grid[i, j] + "";
                                }

                            }

                        }

                    }



                    j++;
                    if (j == y)
                    {

                        j = 0;
                        i++;
                    }
                    if (i == x)
                    {
                        iinndd = index;

                    }
                    iinndd++;
                }


            }

        }

        //check if grid is empty for floodfill  
        public void emptyAreasGrid()
        {



            tempGrid = grid;
            var list = new List<Tuple<int, int>>();

            con = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (tempGrid[i, j] == 0)
                    {

                        Point Point1 = new Point(i, j);
                        FloodFill(x, y, Point1, 0, con);



                    }
                }
            }



        }

        //handling the empty spaces
        private void FloodFill(int xx, int yy, Point pt, int tv, int rev)
        {
            Stack<Point> pixels = new Stack<Point>();

            pixels.Push(pt);
            con++;
            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                int xxx = a.X;
                int yyy = a.Y;
                if (a.X < x - 1 && a.X > 0 && a.Y < y - 1 && a.Y > 0)
                {

                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;


                        EAG[a.X, a.Y] = con;

                        EAG[a.X - 1, a.Y - 1] = con;
                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X - 1, a.Y + 1] = con;
                        EAG[a.X, a.Y + 1] = con;
                        EAG[a.X, a.Y - 1] = con;
                        EAG[a.X + 1, a.Y + 1] = con;
                        EAG[a.X + 1, a.Y] = con;
                        EAG[a.X + 1, a.Y - 1] = con;


                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));


                    }
                }
                else if (a.Y == 0 && a.X > 0 && a.X < x - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X + 1, a.Y] = con;
                        EAG[a.X - 1, a.Y + 1] = con;
                        EAG[a.X + 1, a.Y + 1] = con;
                        EAG[a.X, a.Y + 1] = con;



                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
                else if (a.X == 0 && a.Y > 0 && a.Y < y - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X + 1, a.Y + 1] = con;
                        EAG[a.X + 1, a.Y - 1] = con;
                        EAG[a.X + 1, a.Y] = con;
                        EAG[a.X, a.Y + 1] = con;
                        EAG[a.X, a.Y - 1] = con;

                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                        pixels.Push(new Point(a.X + 1, a.Y));
                    }
                }
                else if (a.X == x - 1 && a.Y > 0 && a.Y < y - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X - 1, a.Y + 1] = con;
                        EAG[a.X - 1, a.Y - 1] = con;
                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X, a.Y + 1] = con;
                        EAG[a.X, a.Y - 1] = con;

                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                        pixels.Push(new Point(a.X - 1, a.Y));
                    }
                }
                else if (a.Y == y - 1 && a.X > 0 && a.X < x - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X - 1, a.Y - 1] = con;
                        EAG[a.X + 1, a.Y - 1] = con;
                        EAG[a.X, a.Y - 1] = con;
                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X + 1, a.Y] = con;

                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
                else if (a.X == 0 && a.Y == 0)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X + 1, a.Y] = con;
                        EAG[a.X, a.Y + 1] = con;
                        EAG[a.X + 1, a.Y + 1] = con;

                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y + 1));

                    }
                }
                else if (a.X == 0 && a.Y == y - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X + 1, a.Y] = con;
                        EAG[a.X, a.Y - 1] = con;
                        EAG[a.X + 1, a.Y - 1] = con;

                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));

                    }


                }
                else if (a.X == x - 1 && a.Y == y - 1)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X, a.Y - 1] = con;
                        EAG[a.X - 1, a.Y - 1] = con;

                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));

                    }


                }
                else if (a.X == x - 1 && a.Y == 0)
                {
                    if (tempGrid[a.X, a.Y] == tv && mines[a.X, a.Y] != true)
                    {
                        tempGrid[a.X, a.Y] = -1;
                        EAG[a.X, a.Y] = con;

                        EAG[a.X, a.Y + 1] = con;
                        EAG[a.X - 1, a.Y] = con;
                        EAG[a.X - 1, a.Y + 1] = con;

                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y + 1));

                    }


                }

            }


            return;
        }
        //handling each type of clicks

        public void click(int ind, bool dead = false)
        {

            foreach (Control item in p.Controls)
            {

                if (item is Button)
                {

                    string o = ((Button)item).Text;
                    string n = ((Button)item).Name;
                    if (o.Equals("E"))
                    {

                        int pp = Convert.ToInt32(n.ToString());
                        if (pp == ind)
                        {
                            ((Button)item).PerformClick();
                        }
                    }
                    if (o.Equals("B") && dead)
                    {

                        foreach (Control it in p.Controls)
                        {
                            if (it is Button)
                            {
                                ((Button)it).Visible = false;
                                ((Button)it).Enabled = false;
                            }
                        }
                    }


                }

            }
        }
        //handling the click for right click for flag event
        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (((Button)sender).Text.Last() != 'F')
                {

                    ((Button)sender).BackgroundImage = global::Minesweeper.Properties.Resources.flag;
                    ((Button)sender).Text += "F";
                }
                else
                {
                    ((Button)sender).BackgroundImage = global::Minesweeper.Properties.Resources.em;
                    ((Button)sender).Text = ((Button)sender).Text.ElementAt(0).ToString();

                }

            }
        }
        //timer checker for stats updating
        public void timerCheck()
        {
            if (x == 9)
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st1.txt");
                int o = 0;
                int m = 9999;
                foreach (string line in lines)
                {

                    if (o == 0)
                    {
                        m = Convert.ToInt32(line);
                    }
                    o++;
                }
                if (m > timeSecondsCounter)
                {



                    var li = System.IO.File.ReadAllLines(@"..\..\Resources\values\st1.txt");
                    li[0] = timeSecondsCounter + "";

                    System.IO.File.WriteAllLines(@"..\..\Resources\values\st1.txt", li);

                    MessageBox.Show("New Record!");
                }

            }
            else if (x == 16)
            {


                string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st2.txt");
                int o = 0;
                int m = 9999;
                foreach (string line in lines)
                {

                    if (o == 0)
                    {
                        m = Convert.ToInt32(line);
                    }
                    o++;
                }
                if (m > timeSecondsCounter)
                {



                    var li = System.IO.File.ReadAllLines(@"..\..\Resources\values\st2.txt");
                    li[0] = timeSecondsCounter + "";

                    System.IO.File.WriteAllLines(@"..\..\Resources\values\st2.txt", li);

                    MessageBox.Show("New Record!");
                }




            }
            else if (x == 23)
            {


                string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\values\st3.txt");
                int o = 0;
                int m = 9999;
                foreach (string line in lines)
                {

                    if (o == 0)
                    {
                        m = Convert.ToInt32(line);
                    }
                    o++;
                }
                if (m > timeSecondsCounter)
                {



                    var li = System.IO.File.ReadAllLines(@"..\..\Resources\values\st3.txt");
                    li[0] = timeSecondsCounter + "";

                    System.IO.File.WriteAllLines(@"..\..\Resources\values\st3.txt", li);

                    MessageBox.Show("New Record!");
                }




            }

        }

        //handling the click event

        private void ClickedButton(object sender, EventArgs e)
        {
            if (firstClick)
            {
                timeSecondsCounter = 0;
                timer.Start();
                sw.Start();
                firstClick = false;

            }

            Button s = (Button)sender;

            if (s.Text.Last() != 'F')
            {
                s.Visible = false;
                s.Enabled = false;
                if (s.Text.Equals("E")) { click(Convert.ToInt32(s.Name)); }

                else if (s.Text.Equals("B"))
                {
                    click(-1, true);
                    faild = true;

                }
                if (!faild)
                {
                    prog--;

                    if (prog > minesAmount)
                    {

                        pro.Text = "" + prog;
                    }
                    else if (prog == 0)
                    {
                        timer.Stop();
                        sw.Stop();
                        pro.Text = "Win!";
                        firstClick = true;

                        timerCheck();
                        MessageBox.Show("You Won!");

                    }
                }
                else
                {
                    timer.Stop();
                    sw.Stop();
                    pro.Text = "Faild!";
                    firstClick = true;

                }
            }
        }


    }
}
