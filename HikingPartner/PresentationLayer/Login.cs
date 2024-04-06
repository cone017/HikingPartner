using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{

    public partial class Login : Form
    {

        public static string user = "";

        readonly HikingPartnerBL hikingPartnerBL = new HikingPartnerBL();
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            bool tacno = hikingPartnerBL.CheckLogin(user, pass);

            if (tacno)
            {
                HomePage home = new HomePage();

                home.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("NETACNI PODACI");
            }

            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Singup singup = new Singup();
            singup.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HikingPartnerPL hp = new HikingPartnerPL();
            hp.Show();
            this.Hide();
        }
    }
}

