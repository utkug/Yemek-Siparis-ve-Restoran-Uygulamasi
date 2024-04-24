namespace YemekSiparisTakipOtomasyonu
{
    partial class UCCards
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCards));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.rdbCard = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttnKartıSil = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(13, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 45);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 108;
            this.pictureBox4.TabStop = false;
            // 
            // rdbCard
            // 
            this.rdbCard.BackColor = System.Drawing.Color.White;
            this.rdbCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbCard.Location = new System.Drawing.Point(0, 0);
            this.rdbCard.Name = "rdbCard";
            this.rdbCard.Size = new System.Drawing.Size(208, 45);
            this.rdbCard.TabIndex = 107;
            this.rdbCard.Text = "Kredi / Banka Kartı\r\n5555******55";
            this.rdbCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbCard.UseVisualStyleBackColor = false;
            this.rdbCard.Click += new System.EventHandler(this.rdbCard_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 38);
            this.panel1.TabIndex = 109;
            // 
            // bttnKartıSil
            // 
            this.bttnKartıSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnKartıSil.Location = new System.Drawing.Point(201, 9);
            this.bttnKartıSil.Margin = new System.Windows.Forms.Padding(4);
            this.bttnKartıSil.Name = "bttnKartıSil";
            this.bttnKartıSil.Size = new System.Drawing.Size(61, 30);
            this.bttnKartıSil.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.bttnKartıSil.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.bttnKartıSil.StateCommon.Border.Color1 = System.Drawing.Color.MediumSlateBlue;
            this.bttnKartıSil.StateCommon.Border.Color2 = System.Drawing.Color.MediumSlateBlue;
            this.bttnKartıSil.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.bttnKartıSil.StateCommon.Border.Rounding = 5F;
            this.bttnKartıSil.StateCommon.Border.Width = 2;
            this.bttnKartıSil.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.MediumSlateBlue;
            this.bttnKartıSil.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.MediumSlateBlue;
            this.bttnKartıSil.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bttnKartıSil.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bttnKartıSil.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bttnKartıSil.TabIndex = 110;
            this.bttnKartıSil.Values.Text = "Kartı Sil";
            this.bttnKartıSil.Visible = false;
            this.bttnKartıSil.Click += new System.EventHandler(this.bttnKartıSil_Click);
            // 
            // UCCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bttnKartıSil);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.rdbCard);
            this.Name = "UCCards";
            this.Size = new System.Drawing.Size(266, 46);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.RadioButton rdbCard;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonButton bttnKartıSil;
    }
}
