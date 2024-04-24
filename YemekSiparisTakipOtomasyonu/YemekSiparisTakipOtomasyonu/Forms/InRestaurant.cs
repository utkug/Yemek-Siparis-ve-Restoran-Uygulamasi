using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using YemekSiparisTakipOtomasyonu.Forms;

namespace YemekSiparisTakipOtomasyonu
{
    public partial class InRestaurant : Form
    {
        public int restaurantId;
        public int addressId;
        public class Food
        {
            public int foodId;
            public string foodName;
            public string foodDescription;
            public double foodPrice;
            public string category;
        }
        public InRestaurant(int restaurantId, int addressId)
        {
            InitializeComponent();
            this.restaurantId = restaurantId;
            this.addressId = addressId;
            SetRestaurantInfo();
            AddFoodsToList();
            AddCategoriesToList();
            ListFoods();
            Debug.WriteLine("inres: " + addressId);
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        List<Food> foodList = new List<Food>();
        List<String> categoryList = new List<String>();

        public void AddFoodsToList()
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT id,foodname, unitprice, description, category FROM foods WHERE restaurantid=@restaurantid ORDER BY category", baglanti);
                komut.Parameters.AddWithValue("@restaurantid", restaurantId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Food food = new Food();
                    food.foodId = Convert.ToInt32(dr["id"].ToString());
                    food.foodName = dr["foodname"].ToString();
                    food.foodDescription = dr["description"].ToString();
                    food.foodPrice = Convert.ToDouble(dr["unitprice"]);
                    food.category = dr["category"].ToString();
                    foodList.Add(food);
                }
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void AddCategoriesToList()
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT category FROM foods WHERE restaurantid=@restaurantid ORDER BY category", baglanti);
                komut.Parameters.AddWithValue("@restaurantid", restaurantId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    categoryList.Add(dr["category"].ToString());
                    Debug.WriteLine(dr["category"].ToString());
                }
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void ListFoods()
        {
            for (int i = 0; i < foodList.Count; i++)
            {

                Panel pnl = new Panel();
                pnl.Location = new Point(1, 150 + (i * 105));
                PutLabel(i, 150 + (i * 105));
                pnl.BorderStyle = panelYemek.BorderStyle;
                pnl.BackColor = panelYemek.BackColor;
                pnl.Size = panelYemek.Size;
                pnl.Visible = true;
                pnl.Tag = i;

                foreach (Control c in panelYemek.Controls)
                {
                    Control c2;

                    if (c.GetType() == typeof(Krypton.Toolkit.KryptonButton))
                    {
                        Krypton.Toolkit.KryptonButton originalButton = (Krypton.Toolkit.KryptonButton)c;

                        Krypton.Toolkit.KryptonButton newButton = new Krypton.Toolkit.KryptonButton();
                        newButton.Text = "Sepete Ekle";  // Set the Text property here
                        newButton.StateCommon.Border.Rounding = originalButton.StateCommon.Border.Rounding;
                        newButton.Click += new EventHandler(SepeteEkleButton_Click);
                        c2 = newButton;
                    }
                    else if (c.GetType() == typeof(Label))
                    {
                        c2 = new Label();
                        c2.Font = c.Font;

                        if (c.Name == "labelYemekAd")
                        {
                            ((Label)c2).Text = foodList[i].foodName;
                        }
                        else if (c.Name == "labelAciklama")
                        {
                            ((Label)c2).Text = foodList[i].foodDescription;
                        }
                        else if (c.Name == "labelFiyat")
                        {
                            ((Label)c2).Text = foodList[i].foodPrice.ToString() + "TL";
                        }
                    }
                    else
                        c2 = new Control();

                    c2.Location = c.Location;
                    c2.Size = c.Size;
                    pnl.Controls.Add(c2);
                }
                this.Controls.Add(pnl);
            }
        }
        public Label PutLabel(int i, int location)
        {
            if (i == 0)
            {
                Label label = new Label();
                label.Text = categoryList[i];
                label.Font = new Font("Arial", 12, FontStyle.Bold);
                label.ForeColor = Color.Orange;
                label.Location = new Point(1, location - 10);
                this.Controls.Add(label);
                return label;
            }
            else if (categoryList[i - 1] != foodList[i].category)
            {
                Label label = new Label();
                label.Text = categoryList[i];
                label.Font = new Font("Arial", 12, FontStyle.Bold);
                label.ForeColor = Color.Orange;
                label.Location = new Point(1, location - 10);
                this.Controls.Add(label);
                return label;
            }
            return null;
        }

        public void SetRestaurantInfo()
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT restaurantname, maincategory, city, town FROM view_tablolar WHERE restaurantid=@restaurantid", baglanti);
                komut.Parameters.AddWithValue("@restaurantid", restaurantId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    labelRestoran.Text = dr["restaurantname"].ToString();
                    labelKategori.Text = "Kategori: " + dr["maincategory"].ToString();
                    labelAdres.Text = dr["city"].ToString() + "/" + dr["town"].ToString();
                }
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void SepeteEkleButton_Click(object sender, EventArgs e)
        {
            // Find the button that triggered the click event
            Krypton.Toolkit.KryptonButton clickedButton = (Krypton.Toolkit.KryptonButton)sender;
            Panel clickedPanel = (Panel)clickedButton.Parent;
            Debug.WriteLine(clickedPanel.Tag);
            SepeteEkle(Convert.ToInt32(clickedPanel.Tag));
        }
        public void SepeteEkle(int index)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                NpgsqlCommand komut = new NpgsqlCommand("INSERT INTO cart (foodid, restaurantid, userid, addressid) VALUES(@foodid, @restaurantid, @userid, @addressid)", baglanti);
                komut.Parameters.AddWithValue("@restaurantid", restaurantId);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);
                komut.Parameters.AddWithValue("@foodid", foodList[index].foodId);
                komut.Parameters.AddWithValue("@addressid",addressId);
                komut.ExecuteNonQuery(); // ExecuteNonQuery kullanılmalıdır, çünkü sadece bir etkilenen satır var, bir okuma işlemi beklenmiyor.
            }
            catch (NpgsqlException ex)
            {
                // Hata durumunda işlemleri gerçekleştir
                DialogResult dialogResult = MessageBox.Show("Sadece bir restorandan sepete yemek eklenebilir. Sepeti temizlemek ister misiniz?", "Hata", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Yeniden bağlantı açma işlemini kaldırın
                        // baglanti.Open();

                        NpgsqlCommand deleteCommand = new NpgsqlCommand("DELETE FROM cart WHERE userid=@userid", baglanti);
                        deleteCommand.Parameters.AddWithValue("@userid", UserLogin.userId);
                        deleteCommand.ExecuteNonQuery();
                    }
                    finally
                    {
                        // baglanti.Close(); // Burada kapatmaya gerek yok, aşağıda zaten finally bloğu içinde kapatılıyor.
                    }
                }
            }
            finally
            {
                baglanti.Close();
            }
        }




        private void sepetButton_Click(object sender, EventArgs e)
        {
            Sepet sepet = new Sepet(addressId);
            //sepet.addressId = addressId;
            sepet.Show();
        }

        private void sepeteEkleButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
