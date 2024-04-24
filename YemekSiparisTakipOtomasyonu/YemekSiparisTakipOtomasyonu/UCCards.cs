using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekGosterme;
using YemekSiparisTakipOtomasyonu.Forms;

namespace YemekSiparisTakipOtomasyonu
{
    public partial class UCCards : UserControl
    {
        public PaymentMethod CardForm { get; set; }
        public UCCards(PaymentMethod cardForm)
        {
            InitializeComponent();
            CardForm = cardForm;
            rdbCard.Click += rdbCard_Click;
            //bttnKartıSil.Click += bttnKartıSil_Click;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=DBYemek;User Id=postgres;Password=utku");
        NpgsqlCommand komut;

        private void rdbCard_Click(object sender, EventArgs e)
        {
            // Tıklanan RadioButton'ın üzerindeki bttnKartıSil butonunu göster
            bttnKartıSil.Visible = true;
            
            // Diğer RadioButton'ların üzerindeki bttnKartıSil butonunu gizle
            foreach (Control control in this.Parent.Controls)
            {
                if (control is UCCards uc && uc.rdbCard != sender)
                {
                    uc.rdbCard.Checked = false;
                    uc.bttnKartıSil.Visible = false;
                }
            }
        }

        private void bttnKartıSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kart bilgilerini silmek istediğine emin misin?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                baglanti.Open();
                komut = new NpgsqlCommand("DELETE FROM cards WHERE cardno=@cardno", baglanti);
                string kartNo = PaymentMethod.kartList[rdbCard.TabIndex].kartNo.ToString();
                komut.Parameters.AddWithValue("@cardno", kartNo);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kart bilgileri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // Form1 form = new Form1();
                //form.Show();
                CardForm.Hide();
            }
            else
                return;
        }
    }
}
