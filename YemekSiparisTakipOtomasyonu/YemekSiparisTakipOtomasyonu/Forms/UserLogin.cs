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
using YemekSiparisTakipOtomasyonu.Forms;

namespace YemekSiparisTakipOtomasyonu
{
    public partial class UserLogin : KryptonForm
    {
        public static string userEmail;
        public static int userId;
        public UserLogin()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        private void bttnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM users WHERE email=@email " +
                "AND password_=@password_", baglanti);
            komut.Parameters.AddWithValue("@email", txtEposta.Text);
            komut.Parameters.AddWithValue("@password_", txtSifre.Text);
            NpgsqlDataReader dr = komut.ExecuteReader();
            
            if (dr.Read())
            {
                userEmail = dr["email"].ToString();
                UserMainMenu form11 = new UserMainMenu();
                userId = Convert.ToInt32(dr["id"].ToString());
                form11.Show();
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
            UserSignUp form = new UserSignUp();
            form.Show();
            this.Hide();
        }

        private void lblAdminGirisi_Click(object sender, EventArgs e)
        {
            AdminLogin form = new AdminLogin();
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
