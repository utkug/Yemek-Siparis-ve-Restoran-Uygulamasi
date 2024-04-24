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
using Krypton.Toolkit;
using System.Diagnostics;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class UserSiparisler : Form
    { 
        public class Food 
        {
            public double totalPrice;
            public string date;
            public string restaurantName;
            public string status_;
            public string packageid;
        }
       // public int userId { get; set; }
        public UserSiparisler()
        {
            InitializeComponent();
            GetData();
            Create();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);

        List<Food> foodList = new List<Food>();

        public void GetData() 
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT status,orderno,status_, date_, SUM(totalPrice) AS totalOrderPrice, restaurantid, restaurantname FROM user_orders_view WHERE userid = @userid GROUP BY status,orderno,status_, date_, restaurantid, restaurantname ORDER BY date_ DESC;", baglanti);
            komut.Parameters.AddWithValue("@userId",UserLogin.userId);
            NpgsqlDataReader dr = komut.ExecuteReader();
            while(dr.Read()) 
            {
                Food food = new Food();
                food.restaurantName = dr["restaurantname"].ToString();
                food.totalPrice = Convert.ToDouble(dr["totalOrderPrice"]);
                food.date = dr["date_"].ToString();
                food.status_ = dr["status"].ToString();
                food.packageid = dr["orderno"].ToString();
                foodList.Add(food); 
            }
        }

        public void Create()
        {
            for (int i = 0; i < foodList.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.Location = new Point(17, 68 + (i*105));
                pnl.BorderStyle = panel1.BorderStyle;
                pnl.BackColor = panel1.BackColor;
                pnl.Size = panel1.Size;
                pnl.Visible = true;
                pnl.Tag = i;
                pnl.Click += new EventHandler(panel1_Click);
                foreach (Control c in panel1.Controls)
                {
                    Control c2;

                    if(c.GetType() == typeof(Krypton.Toolkit.KryptonButton))
                    {
                        Krypton.Toolkit.KryptonButton originalButton = (Krypton.Toolkit.KryptonButton)c;

                        Krypton.Toolkit.KryptonButton newButton = new Krypton.Toolkit.KryptonButton();
                        newButton.Text = "İncele";  // Set the Text property here
                        newButton.StateCommon.Border.Rounding = originalButton.StateCommon.Border.Rounding;
                        newButton.Click += new EventHandler(kryptonButton1_Click);
                        c2 = newButton;
                    }
                    else if (c.GetType() == typeof(Label))
                    {
                        c2 = new Label();
                        c2.Font = c.Font;

                        if(c.Name == "labelRestoran") 
                        {
                            ((Label)c2).Text = foodList[i].restaurantName;
                        }
                       else if (c.Name == "labelTarih")
                        {
                            ((Label)c2).Text = "Tarih: " + foodList[i].date;
                        }
                        else if (c.Name == "labelFiyat")
                        {
                            ((Label)c2).Text = "Toplam: " + foodList[i].totalPrice.ToString() + "TL";
                        }
                        else if(c.Name == "labelDurum") 
                        {
                            //StatusChecker(foodList[i]);
                            ((Label)c2).ForeColor = Color.Green;
                            ((Label)c2).Text = "Durum: " + foodList[i].status_;
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
        private void kryptonButton1_Click(object sender, EventArgs e)
        {

           // OrderDetails orderDetails = new OrderDetails();
            //orderDetails.ShowDialog();
        }


        private void panel1_Click(object sender, EventArgs e)   
        {
            Panel clickedPanel = (Panel)sender;
            int tag = Convert.ToInt32(clickedPanel.Tag);
            //OrderDetails orderDetails = new OrderDetails(foodList[tag].packageid);
            //orderDetails.ShowDialog();

            OrderDetails form4 = new OrderDetails(foodList[tag].packageid);
            form4.ShowDialog();
        }
    }

}
