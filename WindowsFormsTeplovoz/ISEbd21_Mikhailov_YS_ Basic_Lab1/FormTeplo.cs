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
        private Teplovoz Teplo;
        public FormTeplo()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTeplo.Width, pictureBoxTeplo.Height);
            Graphics gr = Graphics.FromImage(bmp);
            Teplo.DrawTeplo(gr);
            pictureBoxTeplo.Image = bmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Teplo = new Teplovoz();
            Teplo.Init( Color.Black, Color.Blue,true, true, true , true);
            Teplo.SetPosition(rnd.Next(420, 600), rnd.Next(100, 381), pictureBoxTeplo.Width, pictureBoxTeplo.Height);
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
                    Teplo.MoveTeplo(Direction.Up);
                    break;
                case "ButtonDown":
                    Teplo.MoveTeplo(Direction.Down);
                    break;
                case "ButtonLeft":
                    Teplo.MoveTeplo(Direction.Left);
                    break;
                case "ButtonRight": 
                    Teplo.MoveTeplo(Direction.Right);
                    break;
                case "buttonMove_Click":
                    break;
            }
            Draw(); 
        }

        
    }
}
