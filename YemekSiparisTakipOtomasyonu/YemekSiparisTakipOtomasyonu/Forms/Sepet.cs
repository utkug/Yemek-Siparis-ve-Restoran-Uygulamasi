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

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class Sepet : Form
    {
        //public int userId { get; set; }
        public static double totalPrice;
        public int addressId;
        public class Food
        {
            public int foodid;
            public string foodName;
            public string foodDescription;
            public double foodPrice;
            public int foodAmount;
        }
        public Sepet(int addressId)
        {
            InitializeComponent();
            this.addressId = addressId;
            GetData();
            ListFoods();
            Debug.WriteLine("adres " + addressId);
        }
        public void Set() 
        {
            InitializeComponent();
            GetData();
            ListFoods();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        List<Food> foodList = new List<Food>();
        List<Label> amountLabels = new List<Label>();
        List<Label> priceLabels = new List<Label>();
        public void GetData()
        {
            try
            {
                baglanti.Open();
                //NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM cart_view WHERE userid=@userid AND addressid=@addressid", baglanti);
                NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM cart_view WHERE userid=@userid", baglanti);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);
                //komut.Parameters.AddWithValue("@addressid",addressId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Food food = new Food();
                    food.foodName = dr["foodname"].ToString();
                    food.foodDescription = dr["description"].ToString();
                    food.foodPrice = Convert.ToDouble(dr["unitprice"].ToString());
                    food.foodAmount = Convert.ToInt32(dr["amount"].ToString());
                    food.foodid = Convert.ToInt32(dr["foodid"].ToString());
                    foodList.Add(food);
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
                pnl.Location = new Point(1, 86 + (i * 105));
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
                        newButton.Text = "Sil";  // Set the Text property here
                        newButton.StateCommon.Border.Rounding = originalButton.StateCommon.Border.Rounding;
                        newButton.Click += new EventHandler(silButton_Click);
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
                            ((Label)c2).Text = (foodList[i].foodPrice * foodList[i].foodAmount) + "TL";
                            priceLabels.Add((Label)c2);
                        }
                        else if (c.Name == "labelAdet")
                        {
                            ((Label)c2).Text = foodList[i].foodAmount.ToString() + " Adet";
                            amountLabels.Add((Label)c2);
                        }
                    }
                    else
                        c2 = new Control();

                    c2.Location = c.Location;
                    c2.Size = c.Size;
                    pnl.Controls.Add(c2);
                }
                this.Controls.Add(pnl);
                if((i+1) == foodList.Count) 
                {
                    //this.Paint += new PaintEventHandler(Form1_Paint);
                }
                TotalPrice();
            }
        }

        public void Sil(int foodid)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("UPDATE cart SET amount = amount - 1 WHERE foodid=@foodid AND userid = @userid", baglanti);
                //NpgsqlCommand komut = new NpgsqlCommand("SELECT decrease_amount_and_delete_if_zero(@userid, @foodid);", baglanti);
                komut.Parameters.AddWithValue("@foodid", foodid);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                //NpgsqlCommand komut = new NpgsqlCommand("DELETE FROM cart WHERE userid=@userid AND foodid=@foodid ",baglanti);
            }
            finally { baglanti.Close(); }
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            Krypton.Toolkit.KryptonButton clickedButton = (Krypton.Toolkit.KryptonButton)sender;
            Panel clickedPanel = (Panel)clickedButton.Parent;
            int panelId = Convert.ToInt32(clickedPanel.Tag);
            

            if((foodList[panelId].foodAmount - 1) >= 1 ) 
            {
                Sil(foodList[panelId].foodid);
                foodList[panelId].foodAmount = foodList[panelId].foodAmount - 1;
                priceLabels[panelId].Text = (foodList[panelId].foodPrice * (foodList[panelId].foodAmount) + "TL");
                amountLabels[panelId].Text = foodList[panelId].foodAmount.ToString() + " Adet";
                TotalPrice();
            }
            else if((foodList[panelId].foodAmount - 1) == 0) 
            {
                Sil(foodList[panelId].foodid);
                foodList[panelId].foodAmount = foodList[panelId].foodAmount = 0;
                clickedPanel.Visible = false;
                TotalPrice();
                this.Controls.Clear();
                amountLabels.Clear();
                priceLabels.Clear();
                foodList.Clear();
                Set(); 
            }       
        }
        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    // Çizgi rengini ve kalınlığını belirle
        //    Pen pen = new Pen(Color.Black, 2);

        //    // Başlangıç ve bitiş noktalarını belirle
        //    Point startPoint = new Point(1, 106 + (foodList.Count * 105));
        //    Point endPoint = new Point(400, 106 + (foodList.Count * 105));

        //    // Çizgiyi çiz
        //    e.Graphics.DrawLine(pen, startPoint, endPoint);

        //    // Artı işareti çiz
        //    int artiUzunluk = 20;
        //    Point artiCenter = new Point(endPoint.X + artiUzunluk / 2, endPoint.Y - artiUzunluk / 2);

        //    e.Graphics.DrawLine(pen, artiCenter.X - artiUzunluk / 2, artiCenter.Y, artiCenter.X + artiUzunluk / 2, artiCenter.Y);
        //    e.Graphics.DrawLine(pen, artiCenter.X, artiCenter.Y - artiUzunluk / 2, artiCenter.X, artiCenter.Y + artiUzunluk / 2);
        //}
        public void PutPlus()
        {
            pictureBox1.Location = new Point(1, 75 + (foodList.Count * 105));
        }
        public void putTotalPrice()
        {
            int newY = 200 + (foodList.Count * 105);
            labelToplam.Location = new Point(10, newY);
            labelToplam.Text = "Toplam: "+totalPrice + " TL";

            bttnOdemeYap.Location = new Point(10, newY + 40);    
        }

        public void TotalPrice() 
        {
            totalPrice = 0;
            for(int i=0; i<foodList.Count; i++) 
            {
                totalPrice = totalPrice + foodList[i].foodPrice * foodList[i].foodAmount;
            }
            Debug.WriteLine(totalPrice);
            putTotalPrice();
            PutPlus();
        }

        private void bttnOdemeYap_Click_1(object sender, EventArgs e)
        {
            Payment form = new Payment(addressId);
            form.Show();
        }
    }
}

