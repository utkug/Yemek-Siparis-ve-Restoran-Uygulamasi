namespace YemekGosterme
{
    partial class UCAdresler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdresler));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAdresid = new System.Windows.Forms.Label();
            this.labelililce = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAdres = new System.Windows.Forms.Label();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelAdresid);
            this.panel1.Controls.Add(this.labelililce);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelAdres);
            this.panel1.Controls.Add(this.labelBaslik);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 69);
            this.panel1.TabIndex = 24;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // labelAdresid
            // 
            this.labelAdresid.AutoSize = true;
            this.labelAdresid.Location = new System.Drawing.Point(378, -1);
            this.labelAdresid.Name = "labelAdresid";
            this.labelAdresid.Size = new System.Drawing.Size(0, 13);
            this.labelAdresid.TabIndex = 27;
            this.labelAdresid.Visible = false;
            // 
            // labelililce
            // 
            this.labelililce.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelililce.Location = new System.Drawing.Point(3, 23);
            this.labelililce.Name = "labelililce";
            this.labelililce.Size = new System.Drawing.Size(179, 20);
            this.labelililce.TabIndex = 24;
            this.labelililce.Text = "İlçe/İl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(375, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelAdres
            // 
            this.labelAdres.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAdres.Location = new System.Drawing.Point(3, 43);
            this.labelAdres.Name = "labelAdres";
            this.labelAdres.Size = new System.Drawing.Size(367, 20);
            this.labelAdres.TabIndex = 15;
            this.labelAdres.Text = "Açık Adres";
            // 
            // labelBaslik
            // 
            this.labelBaslik.AutoSize = true;
            this.labelBaslik.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBaslik.Location = new System.Drawing.Point(3, 3);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(100, 20);
            this.labelBaslik.TabIndex = 14;
            this.labelBaslik.Text = "Adres Başlığı";
            // 
            // Adresler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Adresler";
            this.Size = new System.Drawing.Size(418, 69);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelililce;
        public System.Windows.Forms.Label labelAdres;
        public System.Windows.Forms.Label labelBaslik;
        public System.Windows.Forms.Label labelAdresid;
    }
}
