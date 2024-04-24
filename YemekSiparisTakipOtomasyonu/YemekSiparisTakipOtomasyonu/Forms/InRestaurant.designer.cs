namespace YemekSiparisTakipOtomasyonu
{
    partial class InRestaurant
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
            this.panelRestoran = new System.Windows.Forms.Panel();
            this.labelAdres = new System.Windows.Forms.Label();
            this.labelKategori = new System.Windows.Forms.Label();
            this.labelRestoran = new System.Windows.Forms.Label();
            this.panelYemek = new System.Windows.Forms.Panel();
            this.sepeteEkleButton = new Krypton.Toolkit.KryptonButton();
            this.labelFiyat = new System.Windows.Forms.Label();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.labelYemekAd = new System.Windows.Forms.Label();
            this.sepetButton = new Krypton.Toolkit.KryptonButton();
            this.panelRestoran.SuspendLayout();
            this.panelYemek.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRestoran
            // 
            this.panelRestoran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRestoran.Controls.Add(this.labelAdres);
            this.panelRestoran.Controls.Add(this.labelKategori);
            this.panelRestoran.Controls.Add(this.labelRestoran);
            this.panelRestoran.Location = new System.Drawing.Point(1, 1);
            this.panelRestoran.Name = "panelRestoran";
            this.panelRestoran.Size = new System.Drawing.Size(773, 149);
            this.panelRestoran.TabIndex = 0;
            // 
            // labelAdres
            // 
            this.labelAdres.AutoSize = true;
            this.labelAdres.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdres.Location = new System.Drawing.Point(24, 89);
            this.labelAdres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdres.Name = "labelAdres";
            this.labelAdres.Size = new System.Drawing.Size(63, 25);
            this.labelAdres.TabIndex = 25;
            this.labelAdres.Text = "Adres";
            // 
            // labelKategori
            // 
            this.labelKategori.AutoSize = true;
            this.labelKategori.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKategori.Location = new System.Drawing.Point(24, 64);
            this.labelKategori.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKategori.Name = "labelKategori";
            this.labelKategori.Size = new System.Drawing.Size(88, 25);
            this.labelKategori.TabIndex = 24;
            this.labelKategori.Text = "Kategori";
            // 
            // labelRestoran
            // 
            this.labelRestoran.AutoSize = true;
            this.labelRestoran.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestoran.Location = new System.Drawing.Point(21, 18);
            this.labelRestoran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRestoran.Name = "labelRestoran";
            this.labelRestoran.Size = new System.Drawing.Size(158, 45);
            this.labelRestoran.TabIndex = 23;
            this.labelRestoran.Text = "Restoran";
            // 
            // panelYemek
            // 
            this.panelYemek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelYemek.Controls.Add(this.sepeteEkleButton);
            this.panelYemek.Controls.Add(this.labelFiyat);
            this.panelYemek.Controls.Add(this.labelAciklama);
            this.panelYemek.Controls.Add(this.labelYemekAd);
            this.panelYemek.Location = new System.Drawing.Point(31, 181);
            this.panelYemek.Name = "panelYemek";
            this.panelYemek.Size = new System.Drawing.Size(512, 108);
            this.panelYemek.TabIndex = 1;
            this.panelYemek.Visible = false;
            // 
            // sepeteEkleButton
            // 
            this.sepeteEkleButton.Location = new System.Drawing.Point(365, 39);
            this.sepeteEkleButton.Name = "sepeteEkleButton";
            this.sepeteEkleButton.Size = new System.Drawing.Size(111, 25);
            this.sepeteEkleButton.StateCommon.Back.ColorAngle = 45F;
            this.sepeteEkleButton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.sepeteEkleButton.StateCommon.Border.Rounding = 10F;
            this.sepeteEkleButton.TabIndex = 33;
            this.sepeteEkleButton.Values.Text = "Sepete Ekle";
            this.sepeteEkleButton.Click += new System.EventHandler(this.sepeteEkleButton_Click_1);
            // 
            // labelFiyat
            // 
            this.labelFiyat.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiyat.Location = new System.Drawing.Point(12, 64);
            this.labelFiyat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFiyat.Name = "labelFiyat";
            this.labelFiyat.Size = new System.Drawing.Size(123, 25);
            this.labelFiyat.TabIndex = 30;
            this.labelFiyat.Text = "Fiyat";
            // 
            // labelAciklama
            // 
            this.labelAciklama.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAciklama.Location = new System.Drawing.Point(12, 39);
            this.labelAciklama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAciklama.Name = "labelAciklama";
            this.labelAciklama.Size = new System.Drawing.Size(368, 25);
            this.labelAciklama.TabIndex = 28;
            this.labelAciklama.Text = "AÇIKLAMAA";
            // 
            // labelYemekAd
            // 
            this.labelYemekAd.AutoSize = true;
            this.labelYemekAd.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYemekAd.Location = new System.Drawing.Point(12, 12);
            this.labelYemekAd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYemekAd.Name = "labelYemekAd";
            this.labelYemekAd.Size = new System.Drawing.Size(110, 25);
            this.labelYemekAd.TabIndex = 27;
            this.labelYemekAd.Text = "Yemek İsmi";
            // 
            // sepetButton
            // 
            this.sepetButton.Location = new System.Drawing.Point(842, 12);
            this.sepetButton.Name = "sepetButton";
            this.sepetButton.Size = new System.Drawing.Size(111, 25);
            this.sepetButton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.sepetButton.StateCommon.Border.Rounding = 10F;
            this.sepetButton.TabIndex = 31;
            this.sepetButton.Values.Text = "Sepet";
            this.sepetButton.Click += new System.EventHandler(this.sepetButton_Click);
            // 
            // InRestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 827);
            this.Controls.Add(this.sepetButton);
            this.Controls.Add(this.panelYemek);
            this.Controls.Add(this.panelRestoran);
            this.Name = "InRestaurant";
            this.Text = "Form1";
            this.panelRestoran.ResumeLayout(false);
            this.panelRestoran.PerformLayout();
            this.panelYemek.ResumeLayout(false);
            this.panelYemek.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRestoran;
        private System.Windows.Forms.Label labelAdres;
        private System.Windows.Forms.Label labelKategori;
        private System.Windows.Forms.Label labelRestoran;
        private System.Windows.Forms.Panel panelYemek;
        private System.Windows.Forms.Label labelAciklama;
        private System.Windows.Forms.Label labelYemekAd;
        private System.Windows.Forms.Label labelFiyat;
        private Krypton.Toolkit.KryptonButton sepetButton;
        private Krypton.Toolkit.KryptonButton sepeteEkleButton;
    }
}