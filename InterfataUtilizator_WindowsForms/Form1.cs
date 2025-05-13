using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NivelStocareDate;
using LibrarieModele;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        private DataGridView dgvCheltuieli; // Creăm un DataGridView

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            // Setăm titlul ferestrei
            this.Text = "Lista Cheltuieli";
            this.BackColor = Color.Pink; // Fundal roz
            this.Size = new Size(600, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Creăm un Label pentru titlu
            Label lblTitlu = new Label
            {
                Text = "Cheltuielile înregistrate",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 200
            };
            this.Controls.Add(lblTitlu);

            // Creăm și configurăm DataGridView
            dgvCheltuieli = new DataGridView
            {
                Size = new Size(550, 350),
                Top = 60,
                Left = 20,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvCheltuieli);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IncarcaCheltuieli();
        }

        private void IncarcaCheltuieli()
        {
            List<Cheltuiala> cheltuieli = AdministrareCheltuieliFisier.CitesteCheltuieli();

            // Creăm coloanele tabelului
            dgvCheltuieli.ColumnCount = 4;
            dgvCheltuieli.Columns[0].Name = "Categorie";
            dgvCheltuieli.Columns[1].Name = "Suma";
            dgvCheltuieli.Columns[2].Name = "Data";
            dgvCheltuieli.Columns[3].Name = "Utilizator";

            // Adăugăm fiecare cheltuială în tabel
            foreach (var cheltuiala in cheltuieli)
            {
                dgvCheltuieli.Rows.Add(cheltuiala.Categorie, cheltuiala.Suma, cheltuiala.Data, cheltuiala.Utilizator.Nume);
            }
        }
    }
}
