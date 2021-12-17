namespace WindowsFormsTeplovoz
{
    partial class DepoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.btnParkLokomotiv = new System.Windows.Forms.Button();
            this.btnParkTeplovoz = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTake = new System.Windows.Forms.Button();
            this.mTBLot = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(904, 590);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // btnParkLokomotiv
            // 
            this.btnParkLokomotiv.Location = new System.Drawing.Point(911, 12);
            this.btnParkLokomotiv.Name = "btnParkLokomotiv";
            this.btnParkLokomotiv.Size = new System.Drawing.Size(134, 48);
            this.btnParkLokomotiv.TabIndex = 1;
            this.btnParkLokomotiv.Text = "Поставить локомотив\r\n";
            this.btnParkLokomotiv.UseVisualStyleBackColor = true;
            this.btnParkLokomotiv.Click += new System.EventHandler(this.btnParkLokomotiv_Click);
            // 
            // btnParkTeplovoz
            // 
            this.btnParkTeplovoz.Location = new System.Drawing.Point(911, 67);
            this.btnParkTeplovoz.Name = "btnParkTeplovoz";
            this.btnParkTeplovoz.Size = new System.Drawing.Size(134, 48);
            this.btnParkTeplovoz.TabIndex = 2;
            this.btnParkTeplovoz.Text = "Поставить тепловоз\r\n";
            this.btnParkTeplovoz.UseVisualStyleBackColor = true;
            this.btnParkTeplovoz.Click += new System.EventHandler(this.btnParkTeplovoz_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTake);
            this.groupBox1.Controls.Add(this.mTBLot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(911, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать транспорт";
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(29, 71);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(75, 23);
            this.btnTake.TabIndex = 3;
            this.btnTake.Text = "Забрать";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // mTBLot
            // 
            this.mTBLot.Location = new System.Drawing.Point(52, 45);
            this.mTBLot.Mask = "09";
            this.mTBLot.Name = "mTBLot";
            this.mTBLot.Size = new System.Drawing.Size(52, 20);
            this.mTBLot.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место";
            // 
            // DepoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnParkTeplovoz);
            this.Controls.Add(this.btnParkLokomotiv);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "DepoForm";
            this.Text = "Depo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button btnParkLokomotiv;
        private System.Windows.Forms.Button btnParkTeplovoz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.MaskedTextBox mTBLot;
        private System.Windows.Forms.Label label1;
    }
}