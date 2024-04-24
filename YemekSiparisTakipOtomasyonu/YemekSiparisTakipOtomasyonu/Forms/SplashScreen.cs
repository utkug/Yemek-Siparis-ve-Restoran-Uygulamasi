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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            circularProgressBar.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar.Value += 1;
            circularProgressBar.Text = circularProgressBar.Value.ToString() + "%";

            if (circularProgressBar.Value == 100)
            {
                timer1.Enabled = false;
                UserLogin login = new UserLogin();
                login.Show();
                this.Hide();
            }
        }
    }
}
