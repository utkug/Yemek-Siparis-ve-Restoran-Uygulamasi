using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Npgsql;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class UserSignUp : KryptonForm
    {
        public UserSignUp()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;
        DateTime simdi = DateTime.Now;
        string email;

        private void bttnUyeOl_Click(object sender, EventArgs e)
        {
            Bul();
        }   

        private void Kaydet()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("INSERT INTO users (namesurname,gender,telno,birthdate,createddate,email,password_) " +
                "VALUES (@namesurname,@gender,@telno,@birthdate,@createddate,@email,@password_)", baglanti);
            komut.Parameters.AddWithValue("@namesurname", txtAdSoyad.Text);
            if (rdbErkek.Checked)
            {
                komut.Parameters.AddWithValue("@gender", rdbErkek.Text);
            }
            else if (rdbKadın.Checked)
            {
                komut.Parameters.AddWithValue("@gender", rdbKadın.Text);
            }
            komut.Parameters.AddWithValue("@telno", txtCepTelefonu.Text);
            komut.Parameters.AddWithValue("@birthdate", DateTime.Parse(dtpDogumTarihi.Text));
            komut.Parameters.AddWithValue("@createddate", DateTime.Parse(simdi.ToString()));
            komut.Parameters.AddWithValue("@email", txtEposta.Text);
            komut.Parameters.AddWithValue("@password_", txtSifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyeliğiniz başarıyla gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Bul()
        {
            email = txtEposta.Text;
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM users WHERE email='" + email + "'",baglanti);
            dr = komut.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Girmiş olduğunuz e-mail adresi ile üyeliğiniz bulunmaktadır.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
            else
            {
                baglanti.Close();
                Kaydet();
            }
        }

        private void lblGirisYap_Click(object sender, EventArgs e)
        {
            UserLogin form = new UserLogin();
            form.Show();
            this.Hide();
        }

        private void checkBoxSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSifreGoster.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '●';
            }
        }
    }
}
