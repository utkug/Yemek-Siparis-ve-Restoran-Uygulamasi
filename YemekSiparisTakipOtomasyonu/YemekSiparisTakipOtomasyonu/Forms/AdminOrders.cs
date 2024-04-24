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
using System.Windows.Forms.VisualStyles;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class AdminOrders : Form
    {
       
        List<DataGridViewComboBoxCell> allComboBoxCells;

        public AdminOrders()
        {
            InitializeComponent();
           dataGridView1.ReadOnly = false;
            SiparisleriGoster();

            Debug.WriteLine("fiyat " + dataGridView1.Columns["Column1"].Index);
            Debug.WriteLine("tarih " + dataGridView1.Columns["Column3"].Index);
            Debug.WriteLine("not " + dataGridView1.Columns["Column8"].Index);

        }
       // List<DataGridViewComboBoxCell> allComboBoxCells = GetAllComboBoxCells(dataGridView1);
        List<int> status = new List<int>(); 
        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        NpgsqlCommand komut;
        NpgsqlDataAdapter da;
        DataTable dt;
        public void SiparisleriGoster()
        {
            baglanti.Open();
            komut = new NpgsqlCommand("SELECT ordernote,status,username, SUM(ordertotalprice) AS ordertotalprice, orderdate, orderno FROM order_view WHERE restaurantid = " + AdminLogin.restoranId + " GROUP BY ordernote, username, orderdate, orderno, status ORDER BY orderdate DESC", baglanti);
            // komut = new NpgsqlCommand("SELECT username,ordertotalprice,orderdate,packageid FROM order_view WHERE restaurantid=" + AdminLogin.restoranId + "", baglanti);
            da = new NpgsqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            NpgsqlDataReader dr = komut.ExecuteReader();
            baglanti.Close();
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                OrderDetails orderDetails = new OrderDetails(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                //orderDetails.adminOrders = this;
                Debug.WriteLine(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                //orderDetails.musteriAdi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                //orderDetails.siparisTarih = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                //orderDetails.siparisTutari = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                //orderDetails.packageid = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                //orderDetails.Guncelle();
                //orderDetails.Guncelle();
                //orderDetails.GetData();
                orderDetails.ShowDialog();
                return;
            }
            else if(e.ColumnIndex == 3) 
            {
                
            }
        }
        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox && dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                // Remove existing event handler, if any, to avoid multiple subscriptions
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                // Attach the event handler to the SelectedIndexChanged event of the ComboBox
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the ComboBox SelectedIndexChanged event here
            if (sender is ComboBox comboBox)
            {
                // Access the selected value or index
                string selectedValue = comboBox.SelectedItem.ToString();
                int selectedIndex = comboBox.SelectedIndex;

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string packageId = dataGridView1.Rows[rowIndex].Cells["Column8"].Value.ToString();

                UpdateOrderStatus(packageId, selectedIndex);

            }
        }
        private void UpdateOrderStatus(string orderno, int newStatus) 
        {
            try 
            {
                baglanti.Open();
                komut = new NpgsqlCommand("UPDATE orders SET status_ = @newstatus WHERE orderno=@orderno",baglanti);
                komut.Parameters.AddWithValue("@orderno", orderno);
                komut.Parameters.AddWithValue("@newstatus", newStatus);
                NpgsqlDataReader dr = komut.ExecuteReader();
                Debug.WriteLine("pack" + orderno + " stat " + newStatus);
            }
            finally 
            {
                baglanti.Close();
            }
        }
        private void AdminOrders_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    }
}

