using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class UserPage : Form
    {
        public static int idAktivnosti;
        public string user = HomePage.user;
        readonly HikingPartnerBL hiking = new HikingPartnerBL();

        public UserPage()
        {
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            labelKorisnik.Text = "Prijavljeni korisnik: " + user;

            Korisnik korisnik = new Korisnik();

            PojedinacnaAktivnost a = new PojedinacnaAktivnost
            {
                NazivAktivnosti = labelImePrezime.Text,

            };

            korisnik = hiking.GetKorisnik(user);

            labelImePrezime.Text = korisnik.ImePrezime;
            labelMejl.Text = korisnik.MejlAdresa;
            textBoxPassword.Text = korisnik.Sifra;
            textBoxTelefon.Text = korisnik.Telefon;
            labelPol.Text = korisnik.Pol;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonPlaninarenje_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonBiciklizam_CheckedChanged(object sender, EventArgs e)
        {

        }
      

        private void btnOdaberiOmiljenuAktivnosti_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik();
            korisnik = hiking.GetKorisnik(user);
            if (radioButtonTrcanje.Checked)
            {
                idAktivnosti = 1;
                hiking.InsertInteresovanje(korisnik,radioButtonTrcanje.Text);

            }
            if (radioButtonPlaninarenje.Checked)
            {
                idAktivnosti = 2;
                hiking.InsertInteresovanje(korisnik, radioButtonPlaninarenje.Text);
            }
            if (radioButtonBiciklizam.Checked)
            {
                idAktivnosti = 3;
                hiking.InsertInteresovanje(korisnik, radioButtonBiciklizam.Text);
            }

            HomePage home = new HomePage();
            home.Show();
            this.Close();

        }

        private void labelKorisnik_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelPol_Click(object sender, EventArgs e)
        {

        }

        private void buttonAzuriraj_Click(object sender, EventArgs e)
        {

            Korisnik k2 = hiking.GetKorisnik(user);

            Korisnik k = new Korisnik
            {
                KorisnikID = k2.KorisnikID,
                ImePrezime = k2.ImePrezime,
                MejlAdresa = k2.MejlAdresa,
                Sifra = textBoxPassword.Text,
                Telefon = textBoxTelefon.Text,
                Pol = k2.Pol,
                Interesovanje = k2.Interesovanje,
            };

            hiking.UpdateKorisnik(k);
            MessageBox.Show("Uspesno ste azurirali korisnika");
        }
    }
}
