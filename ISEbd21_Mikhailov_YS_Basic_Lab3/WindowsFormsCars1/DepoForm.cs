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
    public partial class DepoForm : Form
    {
        public DepoForm()
        {
            InitializeComponent();
            parking = new Parking<Lokomotiv>(pictureBoxParking.Width, pictureBoxParking.Height);
            Draw();
        }

        private readonly Parking<Lokomotiv> parking;

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }
        
        private void btnTake_Click(object sender, EventArgs e)
        {
            if (mTBLot.Text != "")
            {
                var teplo = parking - Convert.ToInt32(mTBLot.Text);
                if (teplo != null)
                {
                    FormTeplovoz form = new FormTeplovoz();
                    form.setLokomotiv(teplo);
                    form.ShowDialog();
                }
                mTBLot.Text = "";
                Draw();
            }
        }

        private void btnParkTeplovoz_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var teplo = new Teplovoz(100, 1000, dialog.Color, dialogDop.Color, true, true);
                    if ((parking + teplo) > -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Депо переполнен");
                    }
                }
            }
        }

        private void btnParkLokomotiv_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var loko = new Lokomotiv(100, 1000, dialog.Color);
                if ((parking + loko) > -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Депо переполнен");
                }
            }
        }
    }
}
