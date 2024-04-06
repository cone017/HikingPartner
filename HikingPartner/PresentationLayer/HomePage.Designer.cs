using System.Drawing;

namespace PresentationLayer
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelKorisnik = new System.Windows.Forms.Label();
            this.buttonDodajAktivnost = new System.Windows.Forms.Button();
            this.checkBoxFiltriraj = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(396, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(21, 18);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // labelKorisnik
            // 
            this.labelKorisnik.AutoSize = true;
            this.labelKorisnik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelKorisnik.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKorisnik.Location = new System.Drawing.Point(824, 62);
            this.labelKorisnik.Name = "labelKorisnik";
            this.labelKorisnik.Size = new System.Drawing.Size(73, 25);
            this.labelKorisnik.TabIndex = 0;
            this.labelKorisnik.Text = "label1";
            this.labelKorisnik.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonDodajAktivnost
            // 
            this.buttonDodajAktivnost.BackColor = System.Drawing.Color.Brown;
            this.buttonDodajAktivnost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDodajAktivnost.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDodajAktivnost.ForeColor = System.Drawing.Color.White;
            this.buttonDodajAktivnost.Location = new System.Drawing.Point(826, 123);
            this.buttonDodajAktivnost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDodajAktivnost.Name = "buttonDodajAktivnost";
            this.buttonDodajAktivnost.Size = new System.Drawing.Size(273, 72);
            this.buttonDodajAktivnost.TabIndex = 3;
            this.buttonDodajAktivnost.Text = "Kreiraj svoju aktivnost";
            this.buttonDodajAktivnost.UseVisualStyleBackColor = false;
            this.buttonDodajAktivnost.Click += new System.EventHandler(this.buttonDodajAktivnost_Click);
            // 
            // checkBoxFiltriraj
            // 
            this.checkBoxFiltriraj.AutoSize = true;
            this.checkBoxFiltriraj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxFiltriraj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFiltriraj.Location = new System.Drawing.Point(826, 223);
            this.checkBoxFiltriraj.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkBoxFiltriraj.Name = "checkBoxFiltriraj";
            this.checkBoxFiltriraj.Size = new System.Drawing.Size(308, 29);
            this.checkBoxFiltriraj.TabIndex = 4;
            this.checkBoxFiltriraj.Text = "Filtriraj omiljenu aktivnost";
            this.checkBoxFiltriraj.UseVisualStyleBackColor = true;
            this.checkBoxFiltriraj.CheckedChanged += new System.EventHandler(this.checkBoxFiltriraj_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1443, 45);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(658, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Copyright © HP Team 2024.";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxFiltriraj);
            this.Controls.Add(this.buttonDodajAktivnost);
            this.Controls.Add(this.labelKorisnik);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomePage";
            this.Text = "Dostupne aktivnosti";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelKorisnik;
        private System.Windows.Forms.Button buttonDodajAktivnost;
        private System.Windows.Forms.CheckBox checkBoxFiltriraj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}