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

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class AdminLogin : KryptonForm
    {
        public static int adminId, restoranId, kategoriId;
        public static string adSoyad, restoranAdi, anaKategori, email, sifre;
        public AdminLogin()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;

        private void bttnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM view_tablolar WHERE email=@email AND password_=@password_", baglanti);
            komut.Parameters.AddWithValue("@email", txtEposta.Text);
            komut.Parameters.AddWithValue("@password_", txtSifre.Text);
            dr = komut.ExecuteReader();

            if (dr.Read())
            {
                adminId = int.Parse(dr["adminid"].ToString());
                restoranId = int.Parse(dr["restaurantid"].ToString());
                kategoriId = int.Parse(dr["categoryid"].ToString());         
                adSoyad = dr["namesurname"].ToString();
                restoranAdi = dr["restaurantname"].ToString();
                anaKategori = dr["maincategory"].ToString();
                email = dr["email"].ToString();
                sifre = dr["password_"].ToString();

                AdminMainMenu form = new AdminMainMenu();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-mail adresi veya şifrenizi yanlış girdiniz.\n\tLütfen tekrar deneyiniz.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void lblUyeOl_Click(object sender, EventArgs e)
        {
            AdminSignUp form = new AdminSignUp();
            form.Show();
            this.Hide();
        }

        private void lblKullaniciGirisi_Click(object sender, EventArgs e)
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
