using Npgsql;
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

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class OrderDetails : Form
    {
        public string orderNo;
        public static int orderNoCount;
        public OrderDetails(string orderNo)
        {
            InitializeComponent();
            this.orderNo = orderNo;
            GetData();
            Create();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataReader dr;

        public void GetData()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT * FROM order_view WHERE orderno = @orderno", baglanti);
            komut.Parameters.AddWithValue("@orderno", orderNo);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelSiparisNo.Text = dr["orderno"].ToString();
                labelTarih.Text = dr["orderdate"].ToString() + " tarihinde sipariş verildi";
                labelRestoranAdi.Text = dr["restaurantname"].ToString();
                labelAdres.Text = dr["useraddress"].ToString();
                labelSiparisNotu.Text = dr["ordernote"].ToString();
                labelOdemeSekli.Text = dr["paymenttype"].ToString();
            }
            baglanti.Close();
            //labelFiyat.Text = "Toplam " + totalPrice + " TL";
        }

        public void Create()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT COUNT(orderno) FROM user_orders_view WHERE orderno=@orderno", baglanti);
            komut.Parameters.AddWithValue("@orderno", orderNo);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                orderNoCount = Convert.ToInt16(dr[0]);
            }
            baglanti.Close();
            for (int i = 0; i < orderNoCount; i++)
            {
                UCOrders order = new UCOrders(orderNo);
                order.labelAdet.Text = order.orderList[i].adet.ToString() + "x";
                order.labelYemekAdi.Text = order.orderList[i].yemekAdi.ToString();
                order.labelFiyat.Text = (order.orderList[i].fiyat * order.orderList[i].adet).ToString() + " TL";
                labelOdenenTutar.Text = order.totalPrice + " TL";
                flowLayoutPanel1.Controls.Add(order);     
            }           
        }
    }
}
