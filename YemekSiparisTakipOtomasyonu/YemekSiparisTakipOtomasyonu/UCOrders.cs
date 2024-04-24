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

namespace YemekSiparisTakipOtomasyonu
{
    public partial class UCOrders : UserControl
    {
        public string orderNo;
        public double totalPrice = 0;
        public class Order
        {
            public int adet;
            public string yemekAdi;
            public double fiyat;
        }
        public UCOrders(string orderNo)
        {
            InitializeComponent();
            this.orderNo = orderNo;
            GetData();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=DBYemek;User Id=postgres;Password=utku");
        public List<Order> orderList = new List<Order>();
        
        public void GetData()
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM order_view WHERE orderno = @orderno", baglanti);
            komut.Parameters.AddWithValue("@orderno", orderNo);
            NpgsqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //labelAdet.Text = dr["amount"].ToString() + "x";
                //labelYemekAdi.Text = dr["foodname"].ToString();
                //labelFiyat.Text = dr["unitprice"].ToString() + " TL";
                //totalPrice += Convert.ToDouble(dr["amount"]) * Convert.ToDouble(dr["unitprice"]);
                Order order = new Order();
                order.adet = int.Parse(dr["amount"].ToString());
                order.yemekAdi = dr["foodname"].ToString();
                order.fiyat = double.Parse(dr["unitprice"].ToString());
                totalPrice += double.Parse(dr["ordertotalprice"].ToString());
                orderList.Add(order);
            }
            
            //Order order = new Order();
            //order.adet = int.Parse(labelAdet.Text);
            //order.yemekAdi = labelYemekAdi.Text;
            //order.fiyat = int.Parse(labelFiyat.Text);
            //orderList.Add(order);
            //labelFiyat.Text = "Toplam " + totalPrice + " TL";
        }
    }
}
