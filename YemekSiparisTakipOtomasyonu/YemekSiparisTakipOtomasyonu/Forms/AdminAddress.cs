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

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class AdminAddress : Form
    {
        public AdminAddress()
        {
            InitializeComponent();
            GetAddressData();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        public void GetAddressData() 
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM restaurants WHERE adminid=@adminid", baglanti);
            komut.Parameters.AddWithValue("@adminid", AdminLogin.adminId);
            NpgsqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) 
            {
                txtSehir.Text = dr["city"].ToString();
                txtIlce.Text = dr["town"].ToString();
            }
            baglanti.Close();
        }
        public void Update() 
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("UPDATE restaurants SET city=@city, town=@town WHERE adminid=@adminid", baglanti);
            komut.Parameters.AddWithValue("@adminid", AdminLogin.adminId);

            komut.Parameters.AddWithValue("@city", txtSehir.Text);
            komut.Parameters.AddWithValue("@town", txtIlce.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");
        }

        private void bttnGuncelle_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
