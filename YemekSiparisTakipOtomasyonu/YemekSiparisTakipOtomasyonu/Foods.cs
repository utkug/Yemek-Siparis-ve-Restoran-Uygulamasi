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
using YemekSiparisTakipOtomasyonu.Forms;

namespace YemekSiparisTakipOtomasyonu
{
    public partial class Foods : UserControl
    {
        FoodColumns foodColumns = new FoodColumns();
        public Foods()
        {
            InitializeComponent();

        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=DBYemek;User Id=postgres;Password=utku");
        NpgsqlCommand komut;
        NpgsqlDataAdapter da;
        DataTable dt;

        private void bttnEkle_Click(object sender, EventArgs e)
        {
            foodColumns.foods = this;
            foodColumns.Temizle();
            foodColumns.Ekle();
            foodColumns.ShowDialog();
        }

        private void Foods_Load(object sender, EventArgs e)
        {
            YemekGoster();
        }

        public void YemekGoster()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT id,category,foodname,unitprice,description FROM foods WHERE restaurantid=" + AdminLogin.restoranId + "", baglanti);
            da = new NpgsqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foodColumns.foodId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                foodColumns.kategori = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                foodColumns.yemekAdi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                foodColumns.fiyat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                foodColumns.aciklama = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                foodColumns.Guncelle();
                foodColumns.foods = this;
                foodColumns.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Yemek kaydını silmek istiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut = new NpgsqlCommand("DELETE FROM foods WHERE id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Yemek başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YemekGoster();    
                }
                return;
            }
        }
    }
}

