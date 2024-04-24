using ComponentFactory.Krypton.Toolkit;
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
using YemekSiparisTakipOtomasyonu.Forms;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class FoodColumns : KryptonForm
    {
        public Foods foods { get; set; }
        public int foodId;
        public string kategori, yemekAdi, aciklama;
        public decimal fiyat;
        public FoodColumns()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        public void Guncelle()
        {
            this.Text = "Yemek Güncelle";
            bttnEkle.Text = "Güncelle";
            txtKategori.Text = kategori;
            txtYemekAdi.Text = yemekAdi;
            txtFiyat.Text = fiyat.ToString();
            txtAciklama.Text = aciklama;
        }

        public void Ekle()
        {
            this.Text = "Yemek Ekle";
            bttnEkle.Text = "Ekle";
        }

        public void Temizle()
        {
            txtKategori.Text = "";
            txtYemekAdi.Text = "";
            txtFiyat.Text = "";
            txtAciklama.Text = "";
        }

        private void bttnEkle_Click(object sender, EventArgs e)
        {
            if (txtKategori.Text == "" || txtYemekAdi.Text == "" || txtFiyat.Text == "" || txtAciklama.Text == "")
            {
                MessageBox.Show("Alanlar boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (bttnEkle.Text == "Ekle")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("INSERT INTO foods (categoryid,restaurantid,category,foodname,unitprice,description) " +
                    "VALUES (@categoryid,@restaurantid,@category,@foodname,@unitprice,@description)", baglanti);
                komut.Parameters.AddWithValue("@categoryid", AdminLogin.kategoriId);
                komut.Parameters.AddWithValue("@restaurantid", AdminLogin.restoranId);
                komut.Parameters.AddWithValue("@category", txtKategori.Text);
                komut.Parameters.AddWithValue("@foodname", txtYemekAdi.Text);
                komut.Parameters.AddWithValue("@unitprice", decimal.Parse(txtFiyat.Text));
                komut.Parameters.AddWithValue("@description", txtAciklama.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Yemek başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                foods.YemekGoster();
            }
            else if (bttnEkle.Text == "Güncelle")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("UPDATE foods SET category=@category,foodname=@foodname," +
                    "unitprice=@unitprice,description=@description WHERE id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", foodId);
                komut.Parameters.AddWithValue("@category", txtKategori.Text);
                komut.Parameters.AddWithValue("@foodname", txtYemekAdi.Text);
                komut.Parameters.AddWithValue("@unitprice", decimal.Parse(txtFiyat.Text));
                komut.Parameters.AddWithValue("@description", txtAciklama.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Yemek başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foods.YemekGoster();
            }
        }
    }
}

