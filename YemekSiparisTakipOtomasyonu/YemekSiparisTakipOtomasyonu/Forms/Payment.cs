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
using static YemekGosterme.Address;
using static YemekSiparisTakipOtomasyonu.RestoranlarForm;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class Payment : Form
    {
        public int addressId;
        private Form form;
        private Label label;
        private RadioButton rdbKrediBankaKartı;
        private RadioButton rdbNakit;
        private Button bttnSec;
        //public int addressId = RestoranlarForm.selectedAddressId;
        public Payment(int addressId)
        {
            InitializeComponent();
            SaatleriDoldur();
            this.addressId = addressId;
        }

        public class FoodInCart 
        {
            public int amount;
            public double unitPrice;

        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        DateTime simdikiZaman = DateTime.Now;
        List<FoodInCart> foodInCarts = new List<FoodInCart>();
        private void GetFoodInCartData() 
        {
            try 
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT amount, unitprice FROM cart_view WHERE userid=@userid",baglanti);
                komut.Parameters.AddWithValue("@userid",UserLogin.userId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    FoodInCart foodInCart = new FoodInCart();
                    foodInCart.amount = Convert.ToInt32(dr["amount"]);
                    foodInCart.unitPrice = Convert.ToDouble(dr["unitprice"]);
                   // totalPrice += foodInCart.amount * foodInCart.amount;
                    foodInCarts.Add(foodInCart);
                }
            }
            finally { baglanti.Close(); }
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            labelAdres.Text = RestoranlarForm.selectedAdres;
            labelSepetTutari.Text = Sepet.totalPrice.ToString() + "₺";
            labelToplamTutar.Text = Sepet.totalPrice.ToString() + "₺";
            GetFoodInCartData();
        }

        private void txtAcikAdres_Enter(object sender, EventArgs e)
        {
            if (txtAcikAdres.Text == "Sipariş notu ekle")
            {
                txtAcikAdres.Clear();
                txtAcikAdres.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void txtAcikAdres_Leave(object sender, EventArgs e)
        {
            if (txtAcikAdres.Text == "")
            {
                txtAcikAdres.StateCommon.Content.Color1 = Color.Gray;
                txtAcikAdres.Text = "Sipariş notu ekle";
            }
        }

        private void bttnSec_Click(object sender, EventArgs e)
        {
            if (rdbKrediBankaKartı.Checked)
            {
                rdbKapidaOdeme.Text += " - " + rdbKrediBankaKartı.Text;
                form.Close();
            }
            else if (rdbNakit.Checked)
            {
                rdbKapidaOdeme.Text += " - " + rdbNakit.Text;
                form.Close();
            }
            else if (!rdbKrediBankaKartı.Checked && !rdbNakit.Checked)
            {
                MessageBox.Show("Lütfen bir seçenek seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdbOnlineOdeme_Click(object sender, EventArgs e)
        {
            rdbOnlineOdeme.Text = "Online Ödeme";
            rdbKapidaOdeme.Text = "Kapıda Ödeme";
            PaymentMethod card = new PaymentMethod(this);
            card.ShowDialog();
        }

        private void rdbKapidaOdeme_Click(object sender, EventArgs e)
        {
            rdbOnlineOdeme.Text = "Online Ödeme";
            rdbKapidaOdeme.Text = "Kapıda Ödeme";
            form = new Form();
            form.Size = new Size(210, 200);
            form.FormBorderStyle = FormBorderStyle.None;

            label = new Label();
            label.Text = "Kapıda Ödeme Yöntemi Seç";
            label.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            label.ForeColor = Color.DarkSlateBlue;
            label.Location = new Point(5, 20);
            label.Size = new Size(250, 30);

            rdbKrediBankaKartı = new RadioButton();
            rdbKrediBankaKartı.Text = "Kredi / Banka Kartı";
            rdbKrediBankaKartı.TextAlign = ContentAlignment.MiddleRight;
            rdbKrediBankaKartı.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            rdbKrediBankaKartı.AutoSize = false;
            //rdbKrediBankaKartı.Image = Image.FromFile(@"C:\Users\Enes\OneDrive\Masaüstü\Yeni klasör\resims\nakit.png");
            rdbKrediBankaKartı.ImageAlign = ContentAlignment.MiddleLeft;
            rdbKrediBankaKartı.Location = new Point(20, 60);
            rdbKrediBankaKartı.Size = new Size(175, 24);

            rdbNakit = new RadioButton();
            rdbNakit.Text = "Nakit";
            rdbNakit.TextAlign = ContentAlignment.MiddleRight;
            rdbNakit.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            rdbNakit.AutoSize = false;
            //rdbNakit.Image = Image.FromFile(@"C:\Users\Enes\OneDrive\Masaüstü\Yeni klasör\resims\nakit.png");
            rdbNakit.ImageAlign = ContentAlignment.MiddleLeft;
            rdbNakit.Location = new Point(20, 100);
            rdbNakit.Size = new Size(86, 24);

            bttnSec = new Button();
            bttnSec.Text = "Seç";
            bttnSec.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            bttnSec.BackColor = Color.MediumSlateBlue;
            bttnSec.ForeColor = Color.White;
            bttnSec.FlatStyle = FlatStyle.Flat;
            bttnSec.FlatAppearance.BorderSize = 0;
            bttnSec.Location = new Point(20, 140);
            bttnSec.Size = new Size(175, 30);
            bttnSec.Click += bttnSec_Click;

            form.Controls.Add(label);
            form.Controls.Add(rdbKrediBankaKartı);
            form.Controls.Add(rdbNakit);
            form.Controls.Add(bttnSec);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void SaatleriDoldur()
        {
            // Saat ve dakika değerlerini al
            int suankiSaat = simdikiZaman.Hour;
            int suankiDakika = simdikiZaman.Minute;

            // ComboBox'ı temizle
            cmbSaat.Items.Clear();

            if (cmbTarih.SelectedIndex == 0) // Bugün ise tüm saatleri ekle
            {
                // Şuanki saatten sonraki saatleri ComboBox'a ekle
                for (int saat = suankiSaat; saat < 24; saat++)
                {
                    // Eğer şuanki saat ise dakikaları kontrol et
                    int baslangicDakikasi = (saat == suankiSaat) ? (suankiDakika + 15 - (suankiDakika % 15)) : 0;

                    // 15 dakika aralıklarıyla saatleri ve dakikaları ekleyerek ComboBox'ı doldur
                    for (int dakika = baslangicDakikasi; dakika < 60; dakika += 15)
                    {
                        cmbSaat.Items.Add($"{saat:D2}:{dakika:D2}");
                    }
                }
            }
            else if (cmbTarih.SelectedIndex == 1) // Yarın ise tüm saatleri ekle
            {
                // 12:00'dan başlayarak 23:45'e kadar 15 dakika aralıklarla saatleri ekleyin
                DateTime startTime = DateTime.Parse("12:00");
                DateTime endTime = DateTime.Parse("23:45");
                TimeSpan interval = TimeSpan.FromMinutes(15);

                while (startTime <= endTime)
                {
                    cmbSaat.Items.Add(startTime.ToString("HH:mm"));
                    startTime = startTime.Add(interval);
                }
            }
        }

        private void cmbTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaatleriDoldur();
        }

        private void rdbSimdiGelsin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSimdiGelsin.Checked)
            {
                cmbTarih.Visible = false;
                cmbSaat.Visible = false;
            }
        }

        private void rdbIleriTarihteGelsin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIleriTarihteGelsin.Checked)
            {
                cmbTarih.Visible = true;
                cmbSaat.Visible = true;
            }
        }

        private void bttnOnayla_Click(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Now;
            DateTime yarin = bugun.AddDays(1);
            try
            {
                baglanti.Open();

                // CREATE_PACKAGE_ID stored procedure'ını çağır
                string createPackageIdQuery = "CREATE_ORDER_NO";
                using (NpgsqlCommand command = new NpgsqlCommand(createPackageIdQuery, baglanti))
                {
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "generated_orderno",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                        Direction = ParameterDirection.Output
                    });

                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    // Çıkış parametresinin değerini alın
                    string generatedPackageId = command.Parameters["generated_orderno"].Value.ToString();

                    // INSERT_ORDER_AND_DETAILS stored procedure'ını çağır
                    string insertOrderAndDetailsQuery = "CALL insert_order_and_details(@p_userid, @p_date, @p_totalprice, @p_addressid, @p_status, @p_paymenttype, @p_ordernote)";
                    using (NpgsqlCommand insertCommand = new NpgsqlCommand(insertOrderAndDetailsQuery, baglanti))
                    {
                        // Parametreleri ekleyin
                       // insertCommand.CommandType = CommandType.StoredProcedure;

                        insertCommand.Parameters.AddWithValue("@p_userid", UserLogin.userId); // Kullanıcı ID'sini güncellemeniz gerekiyor.
                        if (rdbSimdiGelsin.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@p_date", DateTime.Now);
                        }
                        else if (rdbIleriTarihteGelsin.Checked)
                        {
                            if (cmbTarih.SelectedIndex == 0) // Bugün
                            {
                             //   insertCommand.Parameters.AddWithValue("@p_date", bugun.ToString("yyyy-MM-dd") + " " + cmbSaat.Text);
                                insertCommand.Parameters.AddWithValue("@p_date", Convert.ToDateTime(bugun.ToString("yyyy-MM-dd")));
                               
                            }
                            else if (cmbTarih.SelectedIndex == 1) // Yarın
                            {
                                insertCommand.Parameters.AddWithValue("@p_date", Convert.ToDateTime(yarin.ToString("yyyy-MM-dd")));

                                //insertCommand.Parameters.AddWithValue("@p_date", yarin.ToString("yyyy-MM-dd") + " " + cmbSaat.Text);
                            }
                        }    
                        insertCommand.Parameters.AddWithValue("@p_totalprice", Convert.ToDecimal(Sepet.totalPrice));
                        insertCommand.Parameters.AddWithValue("@p_addressid", addressId);   
                        insertCommand.Parameters.AddWithValue("@p_status", 0);
                        if (rdbOnlineOdeme.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@p_paymenttype", rdbOnlineOdeme.Text);
                        }
                        else if (rdbKapidaOdeme.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@p_paymenttype", rdbKapidaOdeme.Text);
                        }
                        // insertCommand.Parameters.AddWithValue("@paymanettype",);
                        insertCommand.Parameters.AddWithValue("@p_ordernote", txtAcikAdres.Text);

                        //insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show($"Sipariş başarıyla tamamlandı. Paket ID: {generatedPackageId}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Sipariş sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            finally
            {
                baglanti.Close();
            }
        }
    }
}
