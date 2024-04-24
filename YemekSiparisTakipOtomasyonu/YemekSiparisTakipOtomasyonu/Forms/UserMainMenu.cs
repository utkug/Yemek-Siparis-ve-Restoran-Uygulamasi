using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using YemekGosterme;

namespace YemekSiparisTakipOtomasyonu.Forms
{
    public partial class UserMainMenu : KryptonForm
    {
        private Form currentChildForm;
        //public static int userId;
        bool sidebarExpand;
        public UserMainMenu()
        {
            InitializeComponent();
        }
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width==sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width==sidebar.MaximumSize.Width)
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

        public void OpenChildForm(Form childForm) 
        {
            //currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;    
            panel5.Controls.Add(childForm);
            panel5.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            RestoranlarForm restoranlarForm = new RestoranlarForm();
            OpenChildForm(restoranlarForm);
        }

        private void buttonRestoranlar_Click_1(object sender, EventArgs e)
        {
            RestoranlarForm restoranlarForm = new RestoranlarForm();
            OpenChildForm(restoranlarForm);
        }

        private void bttnGecmisSiparisler_Click(object sender, EventArgs e)
        {
            UserSiparisler userSiparisler = new UserSiparisler();
            //userSiparisler.userId = email;
            OpenChildForm(userSiparisler);
        }

        private void buttonAdreslerim_Click_1(object sender, EventArgs e)
        {
            Address address = new Address();
            OpenChildForm(address);
        }

        private void bttnOdemeYontemlerim_Click(object sender, EventArgs e)
        {
            PaymentMethod payment = new PaymentMethod();
            OpenChildForm(payment);
        }

        private void buttonHesabım_Click(object sender, EventArgs e)
        {
            UserHesabim userHesabim = new UserHesabim();
            OpenChildForm(new UserHesabim());
        }

        private void bttnCikisYap_Click_1(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }
    }
}
