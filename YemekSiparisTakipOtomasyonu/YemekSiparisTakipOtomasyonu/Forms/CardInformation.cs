using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Npgsql;
using YemekGosterme;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class CardInformation : KryptonForm
    {
        public Payment payment;
        public CardInformation(Payment payment)
        {
            InitializeComponent();
            this.payment = payment;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        private void bttnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == "" || mskKartNo.Text == "" || mskSKT.Text == "" || mskCVC.Text == "")
            {
                MessageBox.Show("Alanlar boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (bttnEkle.Text == "Ekle")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("INSERT INTO cards (userid,namesurname,cardno,skt,cvc) " +
                    "VALUES (@userid,@namesurname,@cardno,@skt,@cvc)", baglanti);
                //komut.Parameters.AddWithValue("@id", 5);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId) ;
                komut.Parameters.AddWithValue("@namesurname", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@cardno", mskKartNo.Text);
                komut.Parameters.AddWithValue("@skt", mskSKT.Text);
                komut.Parameters.AddWithValue("@cvc", mskCVC.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kart bilgileri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Form1 form = new Form1(payment);
                //form.Refresh();
                this.Hide();
            }
        }
    }
}
