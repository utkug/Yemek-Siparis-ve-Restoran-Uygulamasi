namespace YemekSiparisTakipOtomasyonu
{
    partial class RestoranlarForm
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
            this.txtRestoranAra = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inceleButton = new Krypton.Toolkit.KryptonButton();
            this.labelAdres = new System.Windows.Forms.Label();
            this.labelKategori = new System.Windows.Forms.Label();
            this.labelRestoran = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.comboBoxAdres = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRestoranAra
            // 
            this.txtRestoranAra.Location = new System.Drawing.Point(152, 91);
            this.txtRestoranAra.Margin = new System.Windows.Forms.Padding(4);
            this.txtRestoranAra.Name = "txtRestoranAra";
            this.txtRestoranAra.Size = new System.Drawing.Size(300, 31);
            this.txtRestoranAra.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtRestoranAra.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtRestoranAra.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtRestoranAra.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtRestoranAra.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtRestoranAra.StateCommon.Border.Rounding = 5;
            this.txtRestoranAra.StateCommon.Border.Width = 1;
            this.txtRestoranAra.StateCommon.Content.Color1 = System.Drawing.SystemColors.ControlText;
            this.txtRestoranAra.StateCommon.Content.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestoranAra.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtRestoranAra.TabIndex = 11;
            this.txtRestoranAra.TextChanged += new System.EventHandler(this.txtRestoranAra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Restoran Ara:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.inceleButton);
            this.panel1.Controls.Add(this.labelAdres);
            this.panel1.Controls.Add(this.labelKategori);
            this.panel1.Controls.Add(this.labelRestoran);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 100);
            this.panel1.TabIndex = 9;
            // 
            // inceleButton
            // 
            this.inceleButton.Location = new System.Drawing.Point(208, 32);
            this.inceleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inceleButton.Name = "inceleButton";
            this.inceleButton.Size = new System.Drawing.Size(111, 25);
            this.inceleButton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.inceleButton.StateCommon.Border.Rounding = 10F;
            this.inceleButton.TabIndex = 28;
            this.inceleButton.Values.Text = "İncele";
            this.inceleButton.Click += new System.EventHandler(this.inceleButton_Click);
            // 
            // labelAdres
            // 
            this.labelAdres.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdres.Location = new System.Drawing.Point(4, 55);
            this.labelAdres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdres.Name = "labelAdres";
            this.labelAdres.Size = new System.Drawing.Size(301, 23);
            this.labelAdres.TabIndex = 27;
            this.labelAdres.Text = "Adres";
            // 
            // labelKategori
            // 
            this.labelKategori.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKategori.Location = new System.Drawing.Point(4, 32);
            this.labelKategori.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKategori.Name = "labelKategori";
            this.labelKategori.Size = new System.Drawing.Size(173, 23);
            this.labelKategori.TabIndex = 26;
            this.labelKategori.Text = "Kategori";
            // 
            // labelRestoran
            // 
            this.labelRestoran.AutoSize = true;
            this.labelRestoran.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestoran.Location = new System.Drawing.Point(4, 9);
            this.labelRestoran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRestoran.Name = "labelRestoran";
            this.labelRestoran.Size = new System.Drawing.Size(118, 23);
            this.labelRestoran.TabIndex = 25;
            this.labelRestoran.Text = "Restoran Ara:";
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Location = new System.Drawing.Point(15, 182);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(437, 451);
            this.panelMain.TabIndex = 25;
            // 
            // comboBoxAdres
            // 
            this.comboBoxAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAdres.FormattingEnabled = true;
            this.comboBoxAdres.Location = new System.Drawing.Point(152, 133);
            this.comboBoxAdres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAdres.Name = "comboBoxAdres";
            this.comboBoxAdres.Size = new System.Drawing.Size(299, 28);
            this.comboBoxAdres.TabIndex = 26;
            this.comboBoxAdres.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdres_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 59);
            this.label3.TabIndex = 27;
            this.label3.Text = "Restoranlar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YemekSiparisTakipOtomasyonu.Properties.Resources.restaurant;
            this.pictureBox1.Location = new System.Drawing.Point(271, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // RestoranlarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 660);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAdres);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRestoranAra);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RestoranlarForm";
            this.Text = "Restoranlar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRestoranAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRestoran;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelAdres;
        private System.Windows.Forms.Label labelKategori;
        private Krypton.Toolkit.KryptonButton inceleButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox comboBoxAdres;
    }
}