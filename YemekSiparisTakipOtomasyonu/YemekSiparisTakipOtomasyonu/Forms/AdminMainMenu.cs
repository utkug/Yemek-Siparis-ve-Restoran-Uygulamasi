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
using ComponentFactory.Krypton.Toolkit;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class AdminMainMenu : KryptonForm
    {
        bool sidebarExpand;
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void bttnYemekler_Click(object sender, EventArgs e)
        {
            Foods foods = new Foods();
            panel5.Controls.Clear();
            panel5.Controls.Add(foods);
            foods.Dock = DockStyle.Fill;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblRestoranAdi.Text = AdminLogin.restoranAdi;
            AdminOrders adminOrders = new AdminOrders();
            adminOrders.TopLevel = false;
            adminOrders.FormBorderStyle = FormBorderStyle.None;
            panel5.Controls.Clear();
            panel5.Controls.Add(adminOrders);
            adminOrders.Dock = DockStyle.Fill;
            adminOrders.BringToFront();
            adminOrders.Show();
        }

        private void bttnHesabım_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            panel5.Controls.Clear();
            panel5.Controls.Add(account);
            account.Dock = DockStyle.Fill;
        }

        private void bttnCikisYap_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void buttonSiparislerim_Click(object sender, EventArgs e)
        {
            AdminOrders adminOrders = new AdminOrders();
            adminOrders.TopLevel = false;
            adminOrders.FormBorderStyle = FormBorderStyle.None;
            panel5.Controls.Clear();
            panel5.Controls.Add(adminOrders);
            adminOrders.Dock = DockStyle.Fill;
            adminOrders.BringToFront();
            adminOrders.Show();
        }

        private void buttonAdres_Click(object sender, EventArgs e)
        {
            AdminAddress adminAddress = new AdminAddress();
            adminAddress.TopLevel = false;
            adminAddress.FormBorderStyle = FormBorderStyle.None;
            panel5.Controls.Clear();
            panel5.Controls.Add(adminAddress);
            adminAddress.Dock = DockStyle.Fill;
            adminAddress.BringToFront();
            adminAddress.Show();
        }
    }
}
