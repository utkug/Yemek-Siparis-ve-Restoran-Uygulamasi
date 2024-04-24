using Npgsql;
using NpgsqlTypes;
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

namespace YemekSiparisTakipOtomasyonu
{
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
            Goster(AdminLogin.email);
            KategoriGetir(cmbKategori.Text);
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;

        private void KategoriGetir(string kategori)
        {
            komut = new NpgsqlCommand("SELECT * FROM categories", baglanti);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKategori.ValueMember = "id";
            cmbKategori.DisplayMember = "maincategory";
            cmbKategori.DataSource = dt;
            DataView dv = dt.DefaultView;
            dv.Sort = "maincategory";
            cmbKategori.Text = kategori;
        }

        public void Goster(string email)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM view_tablolar WHERE email=@email", baglanti);
            komut.Parameters.AddWithValue("@email", email);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtAdSoyad.Text = dr["namesurname"].ToString();
                txtRestoranAdi.Text = dr["restaurantname"].ToString();
                cmbKategori.Text = dr["maincategory"].ToString();
                txtEposta.Text = dr["email"].ToString();
                txtSifre.Text = dr["password_"].ToString();
            }
            baglanti.Close();
        }

        private void bttnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new NpgsqlCommand("admin_restoran_guncelle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("v_adminid", NpgsqlDbType.Integer).Value = AdminLogin.adminId;
            komut.Parameters.AddWithValue("v_maincategory", NpgsqlDbType.Varchar).Value = cmbKategori.Text;
            komut.Parameters.AddWithValue("p_categoryid", NpgsqlDbType.Integer).Value = AdminLogin.kategoriId;
            komut.Parameters.AddWithValue("p_namesurname", NpgsqlDbType.Varchar).Value = txtAdSoyad.Text;
            komut.Parameters.AddWithValue("p_restaurantname", NpgsqlDbType.Varchar).Value = txtRestoranAdi.Text;
            komut.Parameters.AddWithValue("p_email", NpgsqlDbType.Varchar).Value = txtEposta.Text;
            komut.Parameters.AddWithValue("p_password", NpgsqlDbType.Varchar).Value = txtSifre.Text;
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hesap bilgileriniz güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
