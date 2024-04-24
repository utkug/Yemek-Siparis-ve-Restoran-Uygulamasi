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
using YemekSiparisTakipOtomasyonu;
using YemekSiparisTakipOtomasyonu.Forms;
using ComponentFactory.Krypton.Toolkit;
using static YemekGosterme.Address;
using static YemekSiparisTakipOtomasyonu.RestoranlarForm;

namespace YemekGosterme
{
    public partial class AddressColumns : KryptonForm
    {
        UserMainMenu anaMenu = new UserMainMenu();
        public Address Form;
        public AddressColumns(Address form)
        {
            InitializeComponent();
            Form = form;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;


        private void bttnEkle_Click_1(object sender, EventArgs e)
        {
            if (txtBaslik.Text == "" || txtIl.Text == "" || txtIlce.Text == "" || txtAcikAdres.Text == "")
            {
                MessageBox.Show("Alanlar boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (bttnEkle.Text == "Ekle")
            {
                baglanti.Open();
                komut = new NpgsqlCommand("INSERT INTO address (userid,cityid,townid,addresstitle,addresstext) " +
                    "VALUES (@userid,@cityid,@townid,@addresstitle,@addresstext)", baglanti);
                // komut.Parameters.AddWithValue("@id", 5);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);

                // İlçe ID'sini almak için başka bir NpgsqlCommand kullanın
                using (NpgsqlCommand komut1 = new NpgsqlCommand("SELECT id,cityid FROM towns WHERE town=@town", baglanti))
                {
                    komut1.Parameters.AddWithValue("@town", txtIlce.Text);

                    using (NpgsqlDataReader dr1 = komut1.ExecuteReader())
                    {
                        while (dr1.Read())
                        {
                            // townid değerini alın
                            komut.Parameters.AddWithValue("@cityid", int.Parse(dr1["cityid"].ToString()));
                            komut.Parameters.AddWithValue("@townid", int.Parse(dr1["id"].ToString()));
                        }
                    }
                }

                komut.Parameters.AddWithValue("@addresstitle", txtBaslik.Text);
                komut.Parameters.AddWithValue("@addresstext", txtAcikAdres.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Adres başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // Address adres = new Address();
               // anaMenu.OpenChildForm(adres);
                this.Close();


            }
            else if (bttnEkle.Text == "Güncelle")
            {
                baglanti.Open();
                komut = new NpgsqlCommand("UPDATE address SET addresstitle=@addresstitle," +
                    "cityid=@cityid,townid=@townid,addresstext=@addresstext WHERE id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(labelAdresId.Text));
                komut.Parameters.AddWithValue("@addresstitle", txtBaslik.Text);


                // İlçe ID'sini almak için başka bir NpgsqlCommand kullanın
                using (NpgsqlCommand komut1 = new NpgsqlCommand("SELECT id,cityid FROM towns WHERE town=@town", baglanti))
                {
                    komut1.Parameters.AddWithValue("@town", txtIlce.Text);

                    using (NpgsqlDataReader dr1 = komut1.ExecuteReader())
                    {
                        while (dr1.Read())
                        {
                            // townid değerini alın
                            komut.Parameters.AddWithValue("@cityid", int.Parse(dr1["cityid"].ToString()));
                            komut.Parameters.AddWithValue("@townid", int.Parse(dr1["id"].ToString()));
                        }
                    }
                }

                komut.Parameters.AddWithValue("@addresstext", txtAcikAdres.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Adres başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Address form = new Address();
                //form.Refresh();
                //form.Show();
                this.Hide();
            }
        }
    }
}
