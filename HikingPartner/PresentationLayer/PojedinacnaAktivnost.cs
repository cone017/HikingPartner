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
    public partial class PojedinacnaAktivnost : Form
    {

        private static string user = HomePage.user;
        private readonly int AktivnostID;
        private DataLayer.Models.Aktivnost a;
        private HikingPartnerBL bl = new HikingPartnerBL();
        private int broj = 0;

        public string NazivAktivnosti { get; internal set; }

        public PojedinacnaAktivnost(int AktivnostID)
        {
            this.AktivnostID = AktivnostID;
            InitializeComponent();
            this.MaximumSize = new Size(800, 800);
        }

        public PojedinacnaAktivnost()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            a = bl.GetAktivnost(AktivnostID);

            label1.Text = "Id aktivnosti:" + Convert.ToString(a.AktivnostID);
            label2.Text = "Naziv aktivnosti:" + Convert.ToString(a.NazivAktivnosti);
            label3.Text = "Datum pocekta:" + Convert.ToDateTime(a.DatumPocetka);
            label4.Text = "Trajanje:" + Convert.ToInt32(a.Trajanje);
            label5.Text = "Lokacija:" + a.Lokacija;

        }

        private void buttonClanovi_Click(object sender, EventArgs e)
        {


            if(broj == 1)
            {
                MessageBox.Show("Vec ste prikazali clanove ove aktivnosti");
                return;
            }

            broj++;

            listBoxCLanovi.Items.Clear();

            foreach (var i in bl.GetAllClanovi(AktivnostID))
            {
                listBoxCLanovi.Items.Add(i.PridruzeniClan);
            }
        }

        private void buttonPridruziSe_Click(object sender, EventArgs e)
        {

            Korisnik k = bl.GetKorisnik(user);

            a = bl.GetAktivnost(AktivnostID);

            if (bl.CheckKorisnik(user, AktivnostID))
            {
                bl.InsertClan(k, a);

                listBoxCLanovi.Items.Clear();

                foreach (var i in bl.GetAllClanovi(AktivnostID))
                {
                    listBoxCLanovi.Items.Add(i.PridruzeniClan);
                }
            }

            else
                MessageBox.Show("Vec ste upisani na ovu aktivnost");
        }

        private void listBoxCLanovi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            HikingPartnerPL pl = new HikingPartnerPL();
            pl.Show();
            this.Hide();
        }


        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            Korisnik k1 = bl.GetKorisnik(user);

            // Check if the user created the activity
            if (bl.IsUserCreatorOfActivity(k1.MejlAdresa, AktivnostID))
            {
                // Check if the user is part of the activity in ClanoviAktivnosti table
                if (bl.IsUserInActivity(k1.MejlAdresa, AktivnostID))
                {
                    // Delete the user from ClanoviAktivnosti table
                    if (bl.DeleteClanAktivnost(AktivnostID, k1.MejlAdresa))
                    {
                        // Delete the activity
                        if (bl.DeleteAktivnost(AktivnostID, k1.MejlAdresa))
                        {
                            MessageBox.Show("Uspesno obrisano");
                            this.Hide();

                            // Refresh the cards on the home page
                            HomePage homePage = Application.OpenForms.OfType<HomePage>().FirstOrDefault();
                            if (homePage != null)
                            {
                                homePage.RefreshCards();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Greška prilikom brisanja aktivnosti");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom brisanja korisnika iz aktivnosti");
                    }
                }
                else
                {
                    MessageBox.Show("Niste deo ove aktivnosti");
                }
            }
            else
            {
                MessageBox.Show("Niste kreirali ovu aktivnost");
            }
        }
    }
}
