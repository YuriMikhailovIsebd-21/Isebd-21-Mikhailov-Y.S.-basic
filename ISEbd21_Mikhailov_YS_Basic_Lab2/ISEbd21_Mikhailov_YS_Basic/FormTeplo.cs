using System;
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
    public partial class FormTeplo : Form
    {
        private ITransport Teplo;
        public FormTeplo()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTeplo.Width, pictureBoxTeplo.Height);
            Graphics gr = Graphics.FromImage(bmp);
            Teplo.DrawTransport(gr);
            pictureBoxTeplo.Image = bmp;
        }

        /// <summary>
 /// Обработка нажатия кнопки "Create"
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Teplo = new Lokomotiv(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            Teplo.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTeplo.Width,
           pictureBoxTeplo.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Createn"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreaten_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Teplo = new Teplovoz(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Brown, true, true);
            Teplo.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTeplo.Width,
           pictureBoxTeplo.Height);
            Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click (object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "ButtonUp":
                    Teplo.MoveTransport(Direction.Up);
                    break;
                case "ButtonDown":
                    Teplo.MoveTransport(Direction.Down);
                    break;
                case "ButtonLeft":
                    Teplo.MoveTransport(Direction.Left);
                    break;
                case "ButtonRight": 
                    Teplo.MoveTransport(Direction.Right);
                    break;
            }
            Draw(); 
        }
    }
}
