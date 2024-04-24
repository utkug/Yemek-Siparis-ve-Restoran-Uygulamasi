using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekSiparisTakipOtomasyonu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace YemekGosterme
{
    public partial class Address : Form
    {
        public class Adres
        {
            public int adresid;
            public string adresBaslik;
            public string il;
            public string ilce;
            public string acikAdres;
        }
        public Address()
        {
            InitializeComponent();
            GetData();
            Create();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;
        public static List<Adres> adresList = new List<Adres>();

        public void GetData()
        {
            adresList.Clear();
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM view_adresler WHERE userid=@userId ORDER BY addressid ASC", baglanti);
            komut.Parameters.AddWithValue("@userId", UserLogin.userId);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Adres adres = new Adres();
                adres.adresid = int.Parse(dr["addressid"].ToString());
                adres.adresBaslik = dr["addresstitle"].ToString();
                adres.il = dr["city"].ToString();
                adres.ilce = dr["town"].ToString();
                adres.acikAdres = dr["addresstext"].ToString();
                adresList.Add(adres);
            }
            baglanti.Close();
        }

        public void Create()
        {
            int i;
            if (adresList.Count == 0)
            {
                label1.Text = "Herhangi bir adresiniz mevcut değil";
                label1.BringToFront();
                label1.Visible = true;
            }
            for (i = 0; i < adresList.Count; i++)
            {
                UCAdresler adres = new UCAdresler(this);
                adres.Location = new Point(9, 9 + (i * 71));
                flowLayoutPanel1.Controls.Add(adres);

                adres.panel1.Tag = i;
                adres.labelBaslik.Text = adresList[i].adresBaslik;
                adres.labelililce.Text = adresList[i].ilce + "/" + adresList[i].il;
                adres.labelAdres.Text = adresList[i].acikAdres;
            }
        }

        private void bttnAdresEkle_Click(object sender, EventArgs e)
        {
            AddressColumns form = new AddressColumns(this);
            form.Show();
        }
    }
}