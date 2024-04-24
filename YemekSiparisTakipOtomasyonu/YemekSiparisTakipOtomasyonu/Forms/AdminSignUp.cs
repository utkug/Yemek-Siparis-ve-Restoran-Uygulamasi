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
using NpgsqlTypes;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class AdminSignUp : KryptonForm
    {
        //public static int adminId, restoranId, kategoriId;
        //public static string adSoyad, restoranAdi, kategori, email, sifre;
        public AdminSignUp()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;

        private void bttnUyeOl_Click(object sender, EventArgs e)
        {
            Bul();
        }

        private void Kaydet()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("admin_restoran_ekle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("p_namesurname", NpgsqlDbType.Varchar).Value = txtAdSoyad.Text;
            komut.Parameters.AddWithValue("p_restaurantname", NpgsqlDbType.Varchar).Value = txtRestoranAdi.Text;
            komut.Parameters.AddWithValue("p_maincategory", NpgsqlDbType.Varchar).Value = cmbKategori.Text;
            komut.Parameters.AddWithValue("p_email", NpgsqlDbType.Varchar).Value = txtEposta.Text;
            komut.Parameters.AddWithValue("p_password", NpgsqlDbType.Varchar).Value = txtSifre.Text;
            // Çıkış parametreleri ekleyin
            komut.Parameters.Add(new NpgsqlParameter("v_adminid", NpgsqlDbType.Integer)).Direction = ParameterDirection.Output;
            komut.Parameters.Add(new NpgsqlParameter("v_categoryid", NpgsqlDbType.Integer)).Direction = ParameterDirection.Output;
            komut.Parameters.Add(new NpgsqlParameter("v_restaurantid", NpgsqlDbType.Integer)).Direction = ParameterDirection.Output;
            // Çıkış parametrelerini alın3
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyeliğiniz başarıyla gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AdminLogin form = new AdminLogin();
            form.Show();
            this.Hide();
        }

        private void Bul()
        {
            string email = txtEposta.Text;
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM admins WHERE email='" + email + "'", baglanti);
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

        private void AdminSignUp_Load(object sender, EventArgs e)
        {
            komut = new NpgsqlCommand("SELECT * FROM categories", baglanti);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataView dv = dt.DefaultView;
            dv.Sort = "maincategory";

            cmbKategori.ValueMember = "id";
            cmbKategori.DisplayMember = "maincategory";
            cmbKategori.DataSource = dt;
        }

        private void lblGirisYap_Click(object sender, EventArgs e)
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
