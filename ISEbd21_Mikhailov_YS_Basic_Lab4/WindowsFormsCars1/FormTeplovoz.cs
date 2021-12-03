﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTeplovoz
{
    public partial class FormTeplovoz : Form
    {
        private ITransport teplovoz;

        public FormTeplovoz()
        {
            InitializeComponent();
        }

        public void setLokomotiv(ITransport teplovoz)
        {
            this.teplovoz = teplovoz;
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            teplovoz?.DrawTransport(gr);
            pictureBox1.Image = bmp;
        }

        private void btnСreateLokomotiv_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            teplovoz = new Lokomotiv(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black);            
            teplovoz.SetPosition(rnd.Next(20, 100), rnd.Next(50, 200), pictureBox1.Width, pictureBox1.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp1":
                    teplovoz?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown1":
                    teplovoz?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft1":
                    teplovoz?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight1":
                    teplovoz?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        private void btnCreateTeplovoz_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            teplovoz = new Teplovoz(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black, Color.Red, true, true);
            teplovoz.SetPosition(rnd.Next(20, 100), rnd.Next(50, 200), pictureBox1.Width, pictureBox1.Height);
            Draw();
        }
    }
} 
