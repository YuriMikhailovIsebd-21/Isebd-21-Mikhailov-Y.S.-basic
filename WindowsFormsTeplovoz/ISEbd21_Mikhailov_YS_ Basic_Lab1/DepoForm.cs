﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISEbd_21_Mikhailov_YS_lab5
{
    public partial class DepoForm : Form
    {
        public DepoForm()
        {
            InitializeComponent();
            parkingColl = new ParkingCollection(pictureBoxParking.Width, pictureBoxParking.Height);
        }

        private readonly ParkingCollection parkingColl;

        private void ReloadLevels()
        {
            int index = lBParking.SelectedIndex;
            lBParking.Items.Clear();
            for (int i = 0; i < parkingColl.Keys.Count; i++)
            {
                lBParking.Items.Add(parkingColl.Keys[i]);
            }
            if (lBParking.Items.Count > 0 && (index == -1 || index >= lBParking.Items.Count))
            {
                lBParking.SelectedIndex = 0;
            }
            else if (lBParking.Items.Count > 0 && index > -1 && index < lBParking.Items.Count)
            {
                lBParking.SelectedIndex = index;
            }
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parkingColl[lBParking.SelectedItem.ToString()].Draw(gr);
            pictureBoxParking.Image = bmp;
        }

        private void btnParkAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBParkName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parkingColl.AddParking(tBParkName.Text);
            ReloadLevels();
        }

        private void btnRemovePark_Click(object sender, EventArgs e)
        {
            if (lBParking.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку { lBParking.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    parkingColl.DelParking(lBParking.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            if (mTBLot.Text != "")
            {
                var car = parkingColl[lBParking.SelectedItem.ToString()] - Convert.ToInt32(mTBLot.Text);
                if (car != null)
                {
                    FormLoko form = new FormLoko();
                    form.setLokomotiv(car);
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
                    var car = new Teplovoz(100, 1000, dialog.Color, dialogDop.Color, true, true);
                    if (parkingColl[lBParking.SelectedItem.ToString()] + car)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Депо переполнено");
                    }
                }
            }
        }

        private void btnParkLokomotiv_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var car = new Lokomotiv(100, 1000, dialog.Color);
                if (parkingColl[lBParking.SelectedItem.ToString()] + car)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Депо переполнено");
                }
            }
        }

        private void lBParking_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void AddLoko(Vehicle car)
        {
            if (car != null && lBParking.SelectedIndex > -1)
            {
                if ((parkingColl[lBParking.SelectedItem.ToString()]) + car)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Машину не удалось поставить");
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            var formLokoConfig = new FormLokoConfig();
            formLokoConfig.AddEvent(AddLoko);
            formLokoConfig.Show();
        }
    }
}
