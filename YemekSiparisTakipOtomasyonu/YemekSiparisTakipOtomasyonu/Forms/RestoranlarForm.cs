using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekGosterme;
using YemekSiparisTakipOtomasyonu.Forms;
using static YemekSiparisTakipOtomasyonu.RestoranlarForm;

namespace YemekSiparisTakipOtomasyonu
{
    public partial class RestoranlarForm : Form
    {
        private int addressIdFromCart;
        public bool formLoaded = false;
        public static string selectedAdres;
        public int selectedAddressId = 0;
        public class Restaurant
        {
            public int restaurantId;
            public string restaurantName;
            public string restaurantCategory;
        }
        public class Addresses 
        {
            public int addressId;
            public string addressText;
            public string addressTitle;
            public string addressCity;
            public string addressTown;
        }
        public RestoranlarForm()
        {          
            InitializeComponent();
            GetAddressData();
            FillComboBox();
            GetCartAddressData();

            
            formLoaded = true;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(SQLPassword.text);
        List<Restaurant> restaurantList = new List<Restaurant>();
        List<Panel> panelList = new List<Panel>();
        List<Addresses> addressList = new List<Addresses>();    
        private void txtRestoranAra_TextChanged(object sender, EventArgs e)
        {
            Bul();
        }
        public void Bul() 
        {
            ClearPanels();
            try
            {
                baglanti.Open();

                // Check if the text box is empty
                if (string.IsNullOrEmpty(txtRestoranAra.Text))
                {
                    ClearPanels();
                }
                else
                {
                    NpgsqlCommand komut = new NpgsqlCommand("SELECT r.id As resid,restaurantname, city, town, maincategory  FROM categories c JOIN restaurants r ON c.id = r.categoryid WHERE restaurantname LIKE @restaurantname AND city=@city AND town=@town", baglanti);
                    komut.Parameters.AddWithValue("@restaurantname", "%" + txtRestoranAra.Text + "%");
                    komut.Parameters.AddWithValue("@city", addressList[comboBoxAdres.SelectedIndex].addressCity);
                    komut.Parameters.AddWithValue("@town", addressList[comboBoxAdres.SelectedIndex].addressTown);
                    // Ensure the previous reader is closed before executing a new command
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open(); // Reopen the connection after closing it                
                    restaurantList.Clear(); // Move this line outside of the while loop

                    using (NpgsqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Restaurant reastaurant = new Restaurant();
                            reastaurant.restaurantName = dr["restaurantname"].ToString();
                            reastaurant.restaurantId = Convert.ToInt32(dr["resid"].ToString());
                            reastaurant.restaurantCategory = dr["maincategory"].ToString() ;
                            restaurantList.Add(reastaurant);
                            Debug.WriteLine("id:" + Convert.ToInt32(dr["resid"].ToString()));
                        }
                    }

                    // Call Create() after retrieving all restaurants
                    Create();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed in the finally block
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        public void Create()
        {
            for (int i = 0; i < restaurantList.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.Location = new Point(17, 12 + (i * 105));
                pnl.BorderStyle = panel1.BorderStyle;
                pnl.BackColor = panel1.BackColor;
                pnl.Size = panel1.Size;
                pnl.Tag = i;
                pnl.Visible = true;

                foreach (Control c in panel1.Controls)
                {
                    Control c2;

                    if (c.GetType() == typeof(Krypton.Toolkit.KryptonButton))
                    {
                        Krypton.Toolkit.KryptonButton originalButton = (Krypton.Toolkit.KryptonButton)c;

                        Krypton.Toolkit.KryptonButton newButton = new Krypton.Toolkit.KryptonButton();
                        newButton.Text = "İncele";  // Set the Text property here
                        newButton.StateCommon.Border.Rounding = originalButton.StateCommon.Border.Rounding;
                        newButton.Click += new EventHandler(inceleButton_Click);
                        c2 = newButton;
                    }
                    else if (c.GetType() == typeof(Label))
                    {
                        c2 = new Label();
                        c2.Font = c.Font;

                        if (c.Name == "labelRestoran")
                        {
                            ((Label)c2).Text = restaurantList[i].restaurantName;
                        }
                        else if (c.Name == "labelKategori")
                        {
                            ((Label)c2).Text = "Kategori: " + restaurantList[i].restaurantCategory;
                        }
                        else if (c.Name == "labelAdres")
                        {
                            ((Label)c2).Text = "Adres: " + addressList[comboBoxAdres.SelectedIndex].addressCity + "/" + addressList[comboBoxAdres.SelectedIndex].addressTown;
                        }

                    }
                    else
                        c2 = new Control();

                    c2.Location = c.Location;
                    c2.Size = c.Size;
                    pnl.Controls.Add(c2);
                }
                panelList.Add(pnl);
                panelMain.Controls.Add(pnl);
            }
        }
        private void ClearPanels()
        {
            panelList.Clear();
            panelMain.Controls.Clear();
        }
        public void GetCartAddressData() 
        {
            try 
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT addressid FROM cart_view WHERE userid=@userid", baglanti);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read()) 
                {
                    addressIdFromCart = Convert.ToInt32(dr["addressid"]);
                }
            }
            finally { baglanti.Close(); }
        }
        private void inceleButton_Click(object sender, EventArgs e)
        {
            selectedAdres = comboBoxAdres.SelectedItem.ToString();
            Krypton.Toolkit.KryptonButton clickedButton = (Krypton.Toolkit.KryptonButton)sender;
            Panel clickedPanel = (Panel)clickedButton.Parent;
            int panelId = Convert.ToInt32(clickedPanel.Tag);
            InRestaurant inRestaurant = new InRestaurant(restaurantList[panelId].restaurantId, selectedAddressId);
            //Debug.WriteLine("rest: " + restaurantList[panelId].restaurantId);
            //inRestaurant.addressId = selectedAddressId;
            inRestaurant.Show();
        }

        public void GetAddressData() 
        {
            try 
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM address_view WHERE userid=@userid",baglanti);
                komut.Parameters.AddWithValue("@userid", UserLogin.userId);
                NpgsqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Addresses address = new Addresses();
                    address.addressId = Convert.ToInt32(dr["address_id"]);
                    address.addressText = dr["addresstext"].ToString();
                    address.addressTitle = dr["addresstitle"].ToString();
                    address.addressCity = dr["user_city"].ToString();
                    address.addressTown = dr["user_town"].ToString();
                    addressList.Add(address);
                }
            }
            finally { baglanti.Close(); }
        }

        public void FillComboBox()
        {
            txtRestoranAra.Text = " ";
            string address;

            if (addressList.Count > 0)
            {
                for (int i = 0; i < addressList.Count; i++)
                {
                    address = addressList[i].addressTitle + ", \n" + addressList[i].addressText;
                    comboBoxAdres.Items.Add(address);
                }

                comboBoxAdres.SelectedItem = addressList[0].addressTitle + ", \n" + addressList[0].addressText;
                selectedAddressId = addressList[0].addressId;
            }
        }


        private void comboBoxAdres_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("cartidd: " + addressIdFromCart);
            GetCartAddressData();
            if (addressIdFromCart != 0)
            {
                for (int i = 0; i < addressList.Count; i++)
                {
                    if (addressList[i].addressId == addressIdFromCart && !formLoaded)
                    {
                        comboBoxAdres.SelectedIndex = i;
                    }
                }
            }

            if (addressList[comboBoxAdres.SelectedIndex].addressId != addressIdFromCart && formLoaded && addressIdFromCart != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Eğer adres değiştirirseniz sepet temizlenir", "Hata", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Yeniden bağlantı açma işlemini kaldırın
                        baglanti.Open();

                        NpgsqlCommand deleteCommand = new NpgsqlCommand("DELETE FROM cart WHERE userid=@userid", baglanti);
                        deleteCommand.Parameters.AddWithValue("@userid", UserLogin.userId);
                        deleteCommand.ExecuteNonQuery();
                    }
                    finally
                    {
                        baglanti.Close(); // Burada kapatmaya gerek yok, aşağıda zaten finally bloğu içinde kapatılıyor.
                    }
                    addressIdFromCart = 0;
                }
                if (dialogResult == DialogResult.No)
                {
                    comboBoxAdres.SelectedIndex = addressList.FindIndex(a => a.addressId == selectedAddressId);
                }
            }

            txtRestoranAra.Text = " ";
            selectedAddressId = addressList[comboBoxAdres.SelectedIndex].addressId;
            Bul();

            //Debug.WriteLine(comboBoxAdres.SelectedIndex);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Sepet sepet = new Sepet(selectedAddressId);          
        //    sepet.Show();
        //}
    }
}
