namespace YemekSiparisTakipOtomasyonu.Forms
{
    partial class UserSiparisler
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inceleButton = new Krypton.Toolkit.KryptonButton();
            this.labelDurum = new System.Windows.Forms.Label();
            this.labelFiyat = new System.Windows.Forms.Label();
            this.labelTarih = new System.Windows.Forms.Label();
            this.labelRestoran = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 47);
            this.label4.TabIndex = 21;
            this.label4.Text = "SIPARISLER";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.inceleButton);
            this.panel1.Controls.Add(this.labelDurum);
            this.panel1.Controls.Add(this.labelFiyat);
            this.panel1.Controls.Add(this.labelTarih);
            this.panel1.Controls.Add(this.labelRestoran);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(284, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 103);
            this.panel1.TabIndex = 22;
            this.panel1.Visible = false;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // inceleButton
            // 
            this.inceleButton.Location = new System.Drawing.Point(212, 49);
            this.inceleButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inceleButton.Name = "inceleButton";
            this.inceleButton.Size = new System.Drawing.Size(83, 20);
            this.inceleButton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.inceleButton.StateCommon.Border.Rounding = 10F;
            this.inceleButton.TabIndex = 23;
            this.inceleButton.Values.Text = "İncele";
            // 
            // labelDurum
            // 
            this.labelDurum.AutoSize = true;
            this.labelDurum.BackColor = System.Drawing.Color.White;
            this.labelDurum.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDurum.Location = new System.Drawing.Point(5, 69);
            this.labelDurum.Name = "labelDurum";
            this.labelDurum.Size = new System.Drawing.Size(173, 20);
            this.labelDurum.TabIndex = 19;
            this.labelDurum.Text = "Sipariş Durumuuuuuuu";
            // 
            // labelFiyat
            // 
            this.labelFiyat.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiyat.Location = new System.Drawing.Point(5, 49);
            this.labelFiyat.Name = "labelFiyat";
            this.labelFiyat.Size = new System.Drawing.Size(178, 20);
            this.labelFiyat.TabIndex = 17;
            this.labelFiyat.Text = "Ürün Fiyatııııııııııı";
            // 
            // labelTarih
            // 
            this.labelTarih.AutoSize = true;
            this.labelTarih.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTarih.Location = new System.Drawing.Point(3, 28);
            this.labelTarih.Name = "labelTarih";
            this.labelTarih.Size = new System.Drawing.Size(250, 20);
            this.labelTarih.TabIndex = 15;
            this.labelTarih.Text = "Tarihhhhhhhhhhhhhhhhhhhhhhhh";
            // 
            // labelRestoran
            // 
            this.labelRestoran.AutoSize = true;
            this.labelRestoran.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestoran.Location = new System.Drawing.Point(3, 8);
            this.labelRestoran.Name = "labelRestoran";
            this.labelRestoran.Size = new System.Drawing.Size(105, 20);
            this.labelRestoran.TabIndex = 14;
            this.labelRestoran.Text = "Restoran İsmi";
            // 
            // UserSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserSiparisler";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFiyat;
        private System.Windows.Forms.Label labelTarih;
        private System.Windows.Forms.Label labelRestoran;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDurum;
        private Krypton.Toolkit.KryptonButton inceleButton;
    }
}