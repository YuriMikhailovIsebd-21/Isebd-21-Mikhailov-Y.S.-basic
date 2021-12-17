using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTeplo
{
    public partial class FormLokoConfig : Form
    {
        public FormLokoConfig()
        {
            InitializeComponent();
            btnCancel.Click += (object sender, EventArgs e) => { Close(); };
            pRed.MouseDown += panelColor_MouseDown;
            pYellow.MouseDown += panelColor_MouseDown;
            pBlack.MouseDown += panelColor_MouseDown;
            pWhite.MouseDown += panelColor_MouseDown;
            pGray.MouseDown += panelColor_MouseDown;
            pOrange.MouseDown += panelColor_MouseDown;
            pGreen.MouseDown += panelColor_MouseDown;
            pBlue.MouseDown += panelColor_MouseDown;
        }

        Lokomotiv loko = null;
        private event Action<Lokomotiv> eventAddLoko;

        public void AddEvent(Action<Lokomotiv> ev)
        {
            eventAddLoko += ev;
        }

        private void DrawTransport()
        {
            if (loko != null)
            {
                Bitmap bmp = new Bitmap(pBpreview.Width, pBpreview.Height);
                Graphics gr = Graphics.FromImage(bmp);
                loko.SetPosition(15, 10, pBpreview.Width, pBpreview.Height);
                loko.DrawTransport(gr);
                pBpreview.Image = bmp;
            }
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void lBase_MouseDown(object sender, MouseEventArgs e)
        {
            lBase.DoDragDrop(lBase.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void lAdditional_MouseDown(object sender, MouseEventArgs e)
        {
            lAdditional.DoDragDrop(lAdditional.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pPicBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pPicBox_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Локомотив":
                    loko = new Lokomotiv((int)nUDMaxSpeed.Value, (int)nUDWeight.Value, Color.White);
                    break;
                case "Тепловоз":
                    loko = new Teplovoz((int)nUDMaxSpeed.Value, (int)nUDWeight.Value, Color.White, Color.Black, cBtube.Checked, cBwheels.Checked);
                    break;
            }
            DrawTransport();
        }

        private void lMainCol_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lMainCol_DragDrop(object sender, DragEventArgs e)
        {
            if (loko != null)
            {
                loko.setMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawTransport();
            }
        }

        private void lDopCol_DragDrop(object sender, DragEventArgs e)
        {
            if (loko != null)
            {
                if (loko is Teplovoz)
                {
                    (loko as Teplovoz).setDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawTransport();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            eventAddLoko?.Invoke(loko);
            Close();
        }
    }
}
