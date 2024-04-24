using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class UserHesabim : Form
    {
        //public static int userId;
        public UserHesabim()
        {
            InitializeComponent();
            Goster();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        public void Goster()
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM users WHERE id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", UserLogin.userId);
            NpgsqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtAdSoyad.Text = dr["namesurname"].ToString();
                txtEposta.Text = dr["email"].ToString();
                txtSifre.Text = dr["password_"].ToString();
                txtTelefon.Text = dr["telno"].ToString();
            }
            baglanti.Close();
        }

        private void bttnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("UPDATE users SET namesurname=@namesurname, email=@email, password_=@password_, telno=@telno WHERE id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", UserLogin.userId);

            komut.Parameters.AddWithValue("@namesurname", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@password_", txtSifre.Text);
            komut.Parameters.AddWithValue("@email", txtEposta.Text);
            komut.Parameters.AddWithValue("@telno", txtTelefon.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");
            // This parameter is used in the WHERE clause to identify the user to update
            //komut.Parameters.AddWithValue("@oldEmail", "ali.veli@email.com");
        }
    }
}
