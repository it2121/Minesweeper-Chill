namespace Minesweeper
{
    partial class Form1
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b5 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("GamePixies", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(230, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b1
            // 
            this.b1.BackColor = System.Drawing.Color.Black;
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b1.Font = new System.Drawing.Font("GamePixies", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.ForeColor = System.Drawing.Color.Transparent;
            this.b1.Location = new System.Drawing.Point(339, 5);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(30, 24);
            this.b1.TabIndex = 2;
            this.b1.Text = "BG";
            this.b1.UseVisualStyleBackColor = false;
            this.b1.Click += new System.EventHandler(this.BgCh_Click);
            // 
            // b4
            // 
            this.b4.BackColor = System.Drawing.Color.Black;
            this.b4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b4.Font = new System.Drawing.Font("GamePixies", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4.ForeColor = System.Drawing.Color.White;
            this.b4.Location = new System.Drawing.Point(419, 4);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(75, 24);
            this.b4.TabIndex = 4;
            this.b4.Text = "Change Track";
            this.b4.UseVisualStyleBackColor = false;
            this.b4.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Minesweeper.Properties.Resources.giphy;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.b5);
            this.panel1.Controls.Add(this.b2);
            this.panel1.Controls.Add(this.b3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.b1);
            this.panel1.Controls.Add(this.b4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(15, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 70);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // b5
            // 
            this.b5.BackColor = System.Drawing.Color.Black;
            this.b5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b5.Font = new System.Drawing.Font("GamePixies", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b5.ForeColor = System.Drawing.Color.Transparent;
            this.b5.Location = new System.Drawing.Point(419, 31);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(75, 23);
            this.b5.TabIndex = 11;
            this.b5.Text = "Stop Music";
            this.b5.UseVisualStyleBackColor = false;
            this.b5.Click += new System.EventHandler(this.button5_Click);
            // 
            // b2
            // 
            this.b2.BackColor = System.Drawing.Color.Black;
            this.b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b2.Font = new System.Drawing.Font("GamePixies", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.ForeColor = System.Drawing.Color.Transparent;
            this.b2.Location = new System.Drawing.Point(374, 5);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(39, 23);
            this.b2.TabIndex = 10;
            this.b2.Text = "ST";
            this.b2.UseVisualStyleBackColor = false;
            this.b2.Click += new System.EventHandler(this.button4_Click);
            // 
            // b3
            // 
            this.b3.BackColor = System.Drawing.Color.Black;
            this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b3.Font = new System.Drawing.Font("GamePixies", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b3.ForeColor = System.Drawing.Color.Transparent;
            this.b3.Location = new System.Drawing.Point(374, 31);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(39, 23);
            this.b3.TabIndex = 8;
            this.b3.Text = "OP";
            this.b3.UseVisualStyleBackColor = false;
            this.b3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Minesweeper.Properties.Resources.source;
            this.pictureBox2.Location = new System.Drawing.Point(467, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Minesweeper.Properties.Resources._3068ca8fb9a1f14df94885251547d50f;
            this.pictureBox3.Location = new System.Drawing.Point(489, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.b1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 617);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

     
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

