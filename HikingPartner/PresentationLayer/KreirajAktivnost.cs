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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PresentationLayer
{
    public partial class KreirajAktivnost : Form
    {
        public static string user = HomePage.user;
        readonly HikingPartnerBL bl = new HikingPartnerBL();
        int id = 0;

        public KreirajAktivnost()
        {
            InitializeComponent();
            radioButtonTrcanje.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonPlaninarenje.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonBicikl.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTrcanje.Checked)
            {
                id = 1;
                return;
            }
            else if (radioButtonPlaninarenje.Checked)
            {
                id = 2;
                return;
            }
            else if (radioButtonBicikl.Checked)
            {
                id = 3;
                return;
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxTrajanje.Text, out int trajanje))
            {
                MessageBox.Show("Trajanje mora biti ceo broj.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxIdAktivnosti.Text, out int aktivnostId))
            {
                MessageBox.Show("Trajanje mora biti ceo broj.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text) ||
                string.IsNullOrWhiteSpace(textBoxLokacija.Text) ||
                string.IsNullOrWhiteSpace(textBoxOpis.Text) ||
                string.IsNullOrWhiteSpace(textBoxTrajanje.Text))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Korisnik k = bl.GetKorisnik(user);

            bool prosao = bl.CheckAktivnostId(Convert.ToInt32(textBoxIdAktivnosti.Text));


            if (prosao)
            {
                Aktivnost a = new Aktivnost
                {
                    AktivnostID = aktivnostId,
                    NazivAktivnosti = textBoxNaziv.Text,
                    DatumPocetka = dateTimePickerDatum.Value,
                    Trajanje = trajanje, // Use the parsed value
                    Opis = textBoxOpis.Text,
                    Lokacija = textBoxLokacija.Text,
                    TipAktivnostiID = id,
                    MejlAdresa = k.MejlAdresa
                };

                bl.InsertAktivnost(a);

                //OVA LINIJA KODA UBACUJE OVOG KORISNIKA KAO CLANA AKTIVNOSTI, ZEZA NAS FOREIGN KEY
                bl.InsertClan(k, a);
            }

            else
            {
                MessageBox.Show("Vec postoji aktivnost sa ovim Id-em");
                textBoxIdAktivnosti.Text = string.Empty;
            }
                
            HomePage homePage = Application.OpenForms.OfType<HomePage>().FirstOrDefault();
            if (homePage != null)
            {
                homePage.RefreshCards();
            }

            textBoxNaziv.Text = string.Empty;
            textBoxIdAktivnosti.Text = string.Empty;
            textBoxLokacija.Text = string.Empty;
            textBoxOpis.Text = string.Empty;
            textBoxTrajanje.Text = string.Empty;
            dateTimePickerDatum.Value = DateTime.Now;

            radioButtonBicikl.Checked = false;
            radioButtonPlaninarenje.Checked = false;
            radioButtonTrcanje.Checked = false;
        }

        private void KreirajAktivnost_Load(object sender, EventArgs e)
        {

        }

        private void textBoxTrajanje_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            HikingPartnerPL pl = new HikingPartnerPL();
            pl.Show();
            this.Hide();
        }
    }
}
