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

namespace YemekGosterme
{
    public partial class UCAdresler : UserControl
    {
        //public Address address { get; set; }
        public Address AddressForm { get; set; }

        //public Address address;
        int adresid;
        public UCAdresler(Address addressForm)
        {
            InitializeComponent();
            AddressForm = addressForm;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=DBYemek;User Id=postgres;Password=utku");
        NpgsqlCommand komut;

        private void panel1_Click(object sender, EventArgs e)
        {
            if (sender is Panel clickedPanel)
            {
                int index = (int)clickedPanel.Tag; // Adreslerim formunda tıklanan panelin adresList içindeki dizinini al
                AddressColumns frm = new AddressColumns(AddressForm);
                frm.txtBaslik.Text = Address.adresList[index].adresBaslik.ToString();
                frm.txtIl.Text = Address.adresList[index].il.ToString();
                frm.txtIlce.Text = Address.adresList[index].ilce.ToString();
                frm.txtAcikAdres.Text = Address.adresList[index].acikAdres.ToString();
                adresid = int.Parse(Address.adresList[index].adresid.ToString());
                frm.labelAdresId.Text = adresid.ToString();
                frm.bttnEkle.Text = "Güncelle";
                frm.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Adresini silmek istediğine emin misin?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                baglanti.Open();
                komut = new NpgsqlCommand("DELETE FROM address WHERE id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", adresid);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Adres başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Address address = new Address();
                address.Show();
                AddressForm.Hide();
            }
            else
                return;
        }
    }
}
