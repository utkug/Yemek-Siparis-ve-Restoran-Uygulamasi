namespace YemekSiparisTakipOtomasyonu
{
    partial class UCOrders
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelFiyat = new System.Windows.Forms.Label();
            this.labelYemekAdi = new System.Windows.Forms.Label();
            this.labelAdet = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelFiyat);
            this.panel3.Controls.Add(this.labelYemekAdi);
            this.panel3.Controls.Add(this.labelAdet);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 32);
            this.panel3.TabIndex = 100;
            // 
            // labelFiyat
            // 
            this.labelFiyat.AutoSize = true;
            this.labelFiyat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFiyat.Location = new System.Drawing.Point(278, 4);
            this.labelFiyat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFiyat.Name = "labelFiyat";
            this.labelFiyat.Size = new System.Drawing.Size(81, 23);
            this.labelFiyat.TabIndex = 26;
            this.labelFiyat.Text = "149,99 TL";
            // 
            // labelYemekAdi
            // 
            this.labelYemekAdi.AutoSize = true;
            this.labelYemekAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelYemekAdi.Location = new System.Drawing.Point(40, 4);
            this.labelYemekAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYemekAdi.Name = "labelYemekAdi";
            this.labelYemekAdi.Size = new System.Drawing.Size(137, 23);
            this.labelYemekAdi.TabIndex = 25;
            this.labelYemekAdi.Text = "Whopper Burger";
            // 
            // labelAdet
            // 
            this.labelAdet.AutoSize = true;
            this.labelAdet.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAdet.Location = new System.Drawing.Point(4, 4);
            this.labelAdet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdet.Name = "labelAdet";
            this.labelAdet.Size = new System.Drawing.Size(28, 23);
            this.labelAdet.TabIndex = 24;
            this.labelAdet.Text = "2x";
            // 
            // UCOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Name = "UCOrders";
            this.Size = new System.Drawing.Size(363, 32);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label labelFiyat;
        public System.Windows.Forms.Label labelYemekAdi;
        public System.Windows.Forms.Label labelAdet;
    }
}
