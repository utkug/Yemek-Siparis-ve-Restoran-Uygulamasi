using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using YemekGosterme;
using static YemekGosterme.Address;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class PaymentMethod : Form
    {
        public Payment FormPayment;
        public static string cardNo;
        public class Kart
        {
            public string adSoyad;
            public string kartNo;
            public string skt;
            public int cvc;
        }
        public PaymentMethod(Payment formPayment)
        {
            InitializeComponent();
            FormPayment = formPayment;
            GetData();
            Create();
        }
        public PaymentMethod()
        {
            InitializeComponent();
            GetData();
            Create();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;
        public static List<Kart> kartList = new List<Kart>();

        public void GetData()
        {
            kartList.Clear();
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM cards WHERE userid=@userId ORDER BY id", baglanti);
            komut.Parameters.AddWithValue("@userId", UserLogin.userId);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kart kart = new Kart();
                kart.adSoyad = dr["namesurname"].ToString();
                kart.kartNo = dr["cardno"].ToString();
                kart.skt = dr["skt"].ToString();
                kart.cvc = int.Parse(dr["cvc"].ToString());
                kartList.Add(kart);
            }
            baglanti.Close();
        }
        public void Create()
        {
            int i;
            if (kartList.Count == 0)
            {
                label1.Text = "Herhangi bir kartınız mevcut değil";
                label1.BringToFront();
                label1.Visible = true;
            }
            for (i = 0; i < kartList.Count; i++)
            {
                UCCards card = new UCCards(this);
                card.rdbCard.TabIndex = i;
                cardNo = kartList[i].kartNo;
                string ilkAltı = cardNo.Substring(0, 6); // İlk 6 karakteri al
                string sonIki = cardNo.Substring(14, 2); // Son 2 karakteri al
                string yildiz = new string('*', cardNo.Length - 8); // Geri kalan karakterleri '*' işareti ile doldur
                string maskedNo = $"{ilkAltı}{yildiz}{sonIki}"; // Bütün karakterleri birleştir
                card.rdbCard.Text = kartList[i].adSoyad + "\n" + maskedNo;
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void bttnKartEkle_Click(object sender, EventArgs e)
        {
            CardInformation kartBilgileri = new CardInformation(FormPayment);
            kartBilgileri.Show();
        }

        private void bttnSec_Click(object sender, EventArgs e)
        {
            bool cardChecked = false;  // Flag to check if any card is selected

            foreach (UCCards card in flowLayoutPanel1.Controls)
            {
                if (card is UCCards ucCard && ucCard.rdbCard != null)
                {
                    if (ucCard.rdbCard.Checked)
                    {
                        FormPayment.rdbOnlineOdeme.Text += " - " + ucCard.rdbCard.Text;
                        this.Close();
                        cardChecked = true;  // Set the flag to true since a card is selected
                        break;  // Exit the loop since we found a selected card
                    }
                }
            }

            if (!cardChecked)
            {
                MessageBox.Show("Kart seçmen gerekiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}