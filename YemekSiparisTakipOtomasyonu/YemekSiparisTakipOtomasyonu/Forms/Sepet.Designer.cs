namespace YemekSiparisTakipOtomasyonu.Forms
{
    partial class Sepet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sepet));
            this.labelRestoran = new System.Windows.Forms.Label();
            this.panelYemek = new System.Windows.Forms.Panel();
            this.labelAdet = new System.Windows.Forms.Label();
            this.labelFiyat = new System.Windows.Forms.Label();
            this.silButton = new Krypton.Toolkit.KryptonButton();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.labelYemekAd = new System.Windows.Forms.Label();
            this.labelToplam = new System.Windows.Forms.Label();
            this.bttnOdemeYap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelYemek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRestoran
            // 
            this.labelRestoran.AutoSize = true;
            this.labelRestoran.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestoran.Location = new System.Drawing.Point(13, 9);
            this.labelRestoran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRestoran.Name = "labelRestoran";
            this.labelRestoran.Size = new System.Drawing.Size(108, 45);
            this.labelRestoran.TabIndex = 24;
            this.labelRestoran.Text = "Sepet";
            // 
            // panelYemek
            // 
            this.panelYemek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelYemek.Controls.Add(this.labelAdet);
            this.panelYemek.Controls.Add(this.labelFiyat);
            this.panelYemek.Controls.Add(this.silButton);
            this.panelYemek.Controls.Add(this.labelAciklama);
            this.panelYemek.Controls.Add(this.labelYemekAd);
            this.panelYemek.Location = new System.Drawing.Point(15, 68);
            this.panelYemek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelYemek.Name = "panelYemek";
            this.panelYemek.Size = new System.Drawing.Size(511, 108);
            this.panelYemek.TabIndex = 25;
            this.panelYemek.Visible = false;
            // 
            // labelAdet
            // 
            this.labelAdet.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdet.Location = new System.Drawing.Point(424, 64);
            this.labelAdet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdet.Name = "labelAdet";
            this.labelAdet.Size = new System.Drawing.Size(81, 41);
            this.labelAdet.TabIndex = 29;
            this.labelAdet.Text = "1 ADET";
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
            // silButton
            // 
            this.silButton.Location = new System.Drawing.Point(432, 23);
            this.silButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.silButton.Name = "silButton";
            this.silButton.Size = new System.Drawing.Size(55, 41);
            this.silButton.StateCommon.Back.Color1 = System.Drawing.Color.MediumSlateBlue;
            this.silButton.StateCommon.Back.Color2 = System.Drawing.Color.MediumSlateBlue;
            this.silButton.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("silButton.StateCommon.Back.Image")));
            this.silButton.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.silButton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.silButton.StateCommon.Border.Rounding = 10F;
            this.silButton.TabIndex = 29;
            this.silButton.Values.Text = "Sil";
            this.silButton.Click += new System.EventHandler(this.silButton_Click);
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
            // labelToplam
            // 
            this.labelToplam.AutoSize = true;
            this.labelToplam.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToplam.Location = new System.Drawing.Point(20, 366);
            this.labelToplam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelToplam.Name = "labelToplam";
            this.labelToplam.Size = new System.Drawing.Size(142, 45);
            this.labelToplam.TabIndex = 26;
            this.labelToplam.Text = "Toplam:";
            // 
            // bttnOdemeYap
            // 
            this.bttnOdemeYap.Location = new System.Drawing.Point(164, 465);
            this.bttnOdemeYap.Margin = new System.Windows.Forms.Padding(5);
            this.bttnOdemeYap.Name = "bttnOdemeYap";
            this.bttnOdemeYap.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.OverrideDefault.Back.ColorAngle = 45F;
            this.bttnOdemeYap.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.OverrideDefault.Border.ColorAngle = 45F;
            this.bttnOdemeYap.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.bttnOdemeYap.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.bttnOdemeYap.OverrideDefault.Border.Rounding = 12;
            this.bttnOdemeYap.OverrideDefault.Border.Width = 1;
            this.bttnOdemeYap.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.bttnOdemeYap.Size = new System.Drawing.Size(161, 49);
            this.bttnOdemeYap.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StateCommon.Back.ColorAngle = 45F;
            this.bttnOdemeYap.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StateCommon.Border.ColorAngle = 45F;
            this.bttnOdemeYap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.bttnOdemeYap.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.bttnOdemeYap.StateCommon.Border.Rounding = 12;
            this.bttnOdemeYap.StateCommon.Border.Width = 1;
            this.bttnOdemeYap.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.bttnOdemeYap.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.bttnOdemeYap.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnOdemeYap.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StatePressed.Back.ColorAngle = 135F;
            this.bttnOdemeYap.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StatePressed.Border.ColorAngle = 135F;
            this.bttnOdemeYap.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.bttnOdemeYap.StatePressed.Border.Rounding = 12;
            this.bttnOdemeYap.StatePressed.Border.Width = 1;
            this.bttnOdemeYap.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StateTracking.Back.ColorAngle = 45F;
            this.bttnOdemeYap.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bttnOdemeYap.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bttnOdemeYap.StateTracking.Border.ColorAngle = 45F;
            this.bttnOdemeYap.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.bttnOdemeYap.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.bttnOdemeYap.StateTracking.Border.Rounding = 12;
            this.bttnOdemeYap.StateTracking.Border.Width = 1;
            this.bttnOdemeYap.TabIndex = 27;
            this.bttnOdemeYap.Values.Text = "Ödeme Yap";
            this.bttnOdemeYap.Click += new System.EventHandler(this.bttnOdemeYap_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YemekSiparisTakipOtomasyonu.Properties.Resources.topla2;
            this.pictureBox1.Location = new System.Drawing.Point(15, 238);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Sepet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 530);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bttnOdemeYap);
            this.Controls.Add(this.labelToplam);
            this.Controls.Add(this.panelYemek);
            this.Controls.Add(this.labelRestoran);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Sepet";
            this.Text = "Sepet";
            this.panelYemek.ResumeLayout(false);
            this.panelYemek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRestoran;
        private System.Windows.Forms.Panel panelYemek;
        private System.Windows.Forms.Label labelFiyat;
        private Krypton.Toolkit.KryptonButton silButton;
        private System.Windows.Forms.Label labelAciklama;
        private System.Windows.Forms.Label labelYemekAd;
        private System.Windows.Forms.Label labelAdet;
        private System.Windows.Forms.Label labelToplam;
        private ComponentFactory.Krypton.Toolkit.KryptonButton bttnOdemeYap;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}