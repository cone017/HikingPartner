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
    public partial class Singup : Form
    {
        readonly HikingPartnerBL hikingPartnerBL = new HikingPartnerBL();   
        public Singup()
        {
            InitializeComponent();

            comboBoxPol.Items.Add("Muski");
            comboBoxPol.Items.Add("Zenski");
        }
        private void buttonRegistracija_Click(object sender, EventArgs e)
        {
            string imePrezime = txtBoxImePrezime.Text;
            string email = txtBoxEmail.Text;
            string sifra = txtBoxSifra.Text;
            string telefon = txtBoxTelefon.Text;

            string validationMessage = ValidateImePrezime(imePrezime);
            if (validationMessage == null)
            {
                validationMessage = ValidateEmail(email);
                if (validationMessage == null)
                {
                    validationMessage = ValidateSifra(sifra);
                    if (validationMessage == null)
                    {
                        validationMessage = ValidateTelefon(telefon);
                        if (validationMessage == null)
                        {
                            Korisnik k = new Korisnik()
                            {
                                ImePrezime = imePrezime,
                                MejlAdresa = email,
                                Sifra = sifra,
                                Telefon = telefon,
                                Pol = comboBoxPol.SelectedItem.ToString(),
                            };

                            hikingPartnerBL.CheckInsertUser(k);

                            MessageBox.Show("Uspesno unet korisnik!");
                            Login login = new Login();
                            login.Show();
                            this.Hide();
                            return; 
                        }
                    }
                }
            }

            MessageBox.Show($"Validacija nije uspela. {validationMessage}");
        }

        private string ValidateImePrezime(string imePrezime)
        {
            if (imePrezime.Length <= 5 || imePrezime.Any(char.IsDigit))
            {
                return "Ime i prezime mora biti duže od 5 karaktera i ne sme sadržavati brojeve.";
            }

            return null;
        }

        private string ValidateEmail(string email)
        {
            if (!email.EndsWith("@gmail.com"))
            {
                return "Mejl adresa mora završavati sa '@gmail.com'.";
            }

            return null;
        }

        private string ValidateSifra(string sifra)
        {
            if (sifra.Length <= 5)
            {
                return "Šifra mora biti duža od 5 karaktera";
            }

            return null;
        }

        private string ValidateTelefon(string telefon)
        {
            if (telefon.Length != 10 || !telefon.All(char.IsDigit))
            {
                return "Telefon mora sadržavati tačno 10 cifara.";
            }

            return null;
        }

        private void textBoxAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Singup_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            HikingPartnerPL hp = new HikingPartnerPL();
            hp.Show();
            this.Hide();
        }

    }
}
