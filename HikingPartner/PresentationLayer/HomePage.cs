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
    public partial class HomePage : Form
    {
        readonly HikingPartnerBL hikingPartnerBL = new HikingPartnerBL();

        private FlowLayoutPanel flowLayoutPanelCards;

        public static int idAkt = UserPage.idAktivnosti;

        public static string user = Login.user;

        public Button detaljnije;

        public static int id;


        public HomePage()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
            this.MaximumSize = new Size(800, 750);
        }

        private void InitializeFlowLayoutPanel()
        {
            flowLayoutPanelCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            Controls.Add(flowLayoutPanelCards);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            RefreshCards();
            labelKorisnik.Text = "Korisnik:" + user;
            labelKorisnik.ForeColor = Color.Brown;
            labelKorisnik.Font = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Bold);
        }

        public void RefreshCards()
        {

            if (flowLayoutPanelCards == null)
            {
                InitializeFlowLayoutPanel();
            }

            flowLayoutPanelCards.Controls.Clear();

            List<DataLayer.Models.Aktivnost> aktivnostiList = hikingPartnerBL.GetAllAktivnosti();

            foreach (DataLayer.Models.Aktivnost a in aktivnostiList)
            {
                string nazivText = "Naziv: " + a.NazivAktivnosti;
                string kategorijaText = "Kategorija: " + GetKategorijaText(a.TipAktivnostiID);
                string datumText = "Datum: " + a.DatumPocetka.ToString("yyyy-MM-dd");
                id = a.AktivnostID;

                // Create a card for each Aktivnost
                Panel card = CreateCard(nazivText, kategorijaText, datumText, id);

                flowLayoutPanelCards.Controls.Add(card);
            }
        }
     
        private Panel CreateCard(string naziv, string kategorija, string datum, int id)
        {
            Panel panel = new Panel
            {
                Width = 250,  // Increased width for better visibility of content
                Height = 150, // Increased height for better visibility of content
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White, // Background color of the card
                Margin = new Padding(10), // Margin to provide spacing between cards
            };

            Label labelId = new Label
            {
                Text = "ID:" + id,
                TextAlign = ContentAlignment.TopLeft,
                Dock = DockStyle.Top,
                Font = new Font(Font.FontFamily, 7, FontStyle.Bold), // Set font and style
                ForeColor = Color.Red, // Set text color
            };

            Label labelNaziv = new Label
            {
                Text = naziv,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold),
                ForeColor = Color.Brown,
                Margin = new Padding(10),
            };

            Label labelTip = new Label
            {
                Text = kategorija,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                ForeColor = Color.Green,
            };

            Label labelDatum = new Label
            {
                Text = datum,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font.FontFamily, 13),
                ForeColor = Color.Chocolate,
            };

            Button detaljnije = new Button
            {
                Text = "Saznaj više...",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 12),
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.Brown,
                Tag = id,
                Cursor = Cursors.Hand,
            };

            detaljnije.Click += Detaljnije_Click;

            panel.Controls.Add(labelNaziv);
            panel.Controls.Add(labelTip);
            panel.Controls.Add(labelDatum);
            panel.Controls.Add(detaljnije);
            panel.Controls.Add(labelId);

            return panel;
        }
       
        private void Detaljnije_Click(object sender, EventArgs e)
        {
            if (labelKorisnik.Text.Equals("Korisnik:"))
            {
                ShowCustomMessageBox("Niste prijavljeni kao korisnik!");
            }

            else
            {
                Button detaljnijeButton = (Button)sender;
                int clickedAktivnostID = Convert.ToInt32(detaljnijeButton.Tag);

                PojedinacnaAktivnost a = new PojedinacnaAktivnost(clickedAktivnostID);
                a.Show();
            }
        }

        private string GetKategorijaText(int tipAktivnostiID)
        {
            switch (tipAktivnostiID)
            {
                case 1:
                    return "Trcanje";
                case 2:
                    return "Planinarenje";
                case 3:
                    return "Voznja bicikla";
                default:
                    return "Nepoznata kategorija";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (labelKorisnik.Text.Equals("Korisnik:"))
            {
                MessageBox.Show("Niste prijavljeni kao korisnik!");
                return;
            }

            else
            {
                UserPage user = new UserPage();
                user.Show();
                this.Hide();
            }
        }
        private void ShowCustomMessageBox(string message)
        {
            Form customMessageBox = new Form();
            customMessageBox.Text = "Registrujte se";
            customMessageBox.Size = new System.Drawing.Size(300, 200);

            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(20, 20);

            Button okButton = new Button();
            okButton.Text = "Registrujte se";
            okButton.Location = new System.Drawing.Point(100, 80);
            okButton.Size = new System.Drawing.Size(80, 40);

            okButton.Click += (sender, e) =>
            {
                customMessageBox.Close();
                NavigateToPage("Singup");
            };

            customMessageBox.Controls.Add(label);
            customMessageBox.Controls.Add(okButton);

            customMessageBox.ShowDialog();
        }

        private void NavigateToPage(string page)
        {
            if (page.Equals("Singup"))
            {
                Singup register = new Singup();
                register.Show();
                this.Hide();
            }
        }

        private void buttonDodajAktivnost_Click(object sender, EventArgs e)
        {
            if (user != "")
            {
                KreirajAktivnost k = new KreirajAktivnost();
                k.Show();
            }

            else
                MessageBox.Show("Ne mozete da kreirate aktivnost. Niste prijavljeni kao korisnik!");
        }

        private void checkBoxFiltriraj_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxFiltriraj.Checked)
            {
               RefreshCardsFiltrirane();
            }
            if (!checkBoxFiltriraj.Checked)
            {
                RefreshCards();
            }
        }

        public void RefreshCardsFiltrirane()
        {
            if (UserPage.idAktivnosti == 0)
            {
                MessageBox.Show("Odaberite zeljeni filter na Vasoj stranici!");
                checkBoxFiltriraj.Checked = false;
                // Create an instance of UserPage to initialize static variables
                UserPage userPage = new UserPage();
                // You may or may not need to call userPage.Show() depending on your application flow
            }

            // Now you can safely access UserPage.idAktivnosti
            int idAkt = UserPage.idAktivnosti;
            if (flowLayoutPanelCards == null)
            {
                // If it's null, try to initialize it
                InitializeFlowLayoutPanel();
            }

            // Clear existing cards
            flowLayoutPanelCards.Controls.Clear();

            // Clear existing cards

            // Fetch Aktivnost objects from your data source (e.g., database)
            List<DataLayer.Models.Aktivnost> aktivnostiList = hikingPartnerBL.GetAllAktivnostiFiltrirane(idAkt); // Assuming GetAllAktivnosti returns a list of Aktivnost objects

            foreach (DataLayer.Models.Aktivnost a in aktivnostiList)
            {
                string nazivText = "Naziv: " + a.NazivAktivnosti;
                string kategorijaText = "Kategorija: " + GetKategorijaText(a.TipAktivnostiID);
                string datumText = "Datum: " + a.DatumPocetka.ToString("yyyy-MM-dd");
                id = a.AktivnostID;

                // Create a card for each Aktivnost
                Panel card = CreateCard(nazivText, kategorijaText, datumText, id);

                flowLayoutPanelCards.Controls.Add(card);
            }
        }
    }
}
