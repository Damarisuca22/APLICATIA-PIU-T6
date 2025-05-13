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
        private DataGridView dgvCheltuieli;
        private TextBox txtCategorie, txtSuma, txtData;
        private Label lblCategorie, lblSuma, lblData, lblEroare;
        private Button btnAdauga;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            // Setări generale
            this.Text = "Lista Cheltuieli";
            this.BackColor = Color.Pink;
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label pentru titlu
            Label lblTitlu = new Label
            {
                Text = "Cheltuielile înregistrate",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 200
            };
            this.Controls.Add(lblTitlu);

            // DataGridView
            dgvCheltuieli = new DataGridView
            {
                Size = new Size(550, 250),
                Top = 60,
                Left = 20,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvCheltuieli);

            // Etichete și câmpuri pentru introducerea datelor
            lblCategorie = new Label { Text = "Categorie:", Top = 320, Left = 20 };
            txtCategorie = new TextBox { Top = 340, Left = 20, Width = 200 };
            lblSuma = new Label { Text = "Suma:", Top = 370, Left = 20 };
            txtSuma = new TextBox { Top = 390, Left = 20, Width = 200 };
            lblData = new Label { Text = "Data (YYYY-MM-DD):", Top = 420, Left = 20 };
            txtData = new TextBox { Top = 440, Left = 20, Width = 200 };

            btnAdauga = new Button
            {
                Text = "Adăugare Cheltuială",
                Top = 480,
                Left = 20,
                Width = 150
            };
            btnAdauga.Click += new EventHandler(AdaugaCheltuiala);

            lblEroare = new Label
            {
                Text = "",
                Top = 510,
                Left = 20,
                ForeColor = Color.Red,
                AutoSize = true
            };

            this.Controls.Add(lblCategorie);
            this.Controls.Add(txtCategorie);
            this.Controls.Add(lblSuma);
            this.Controls.Add(txtSuma);
            this.Controls.Add(lblData);
            this.Controls.Add(txtData);
            this.Controls.Add(btnAdauga);
            this.Controls.Add(lblEroare);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IncarcaCheltuieli();
        }

        private void IncarcaCheltuieli()
        {
            List<Cheltuiala> cheltuieli = AdministrareCheltuieliFisier.CitesteCheltuieli();

            dgvCheltuieli.ColumnCount = 3;
            dgvCheltuieli.Columns[0].Name = "Categorie";
            dgvCheltuieli.Columns[1].Name = "Suma";
            dgvCheltuieli.Columns[2].Name = "Data";

            foreach (var cheltuiala in cheltuieli)
            {
                dgvCheltuieli.Rows.Add(cheltuiala.Categorie, cheltuiala.Suma, cheltuiala.Data);
            }
        }

        private void AdaugaCheltuiala(object sender, EventArgs e)
        {
            string categorie = txtCategorie.Text;
            if (string.IsNullOrWhiteSpace(categorie))
            {
                lblCategorie.ForeColor = Color.Red;
                lblEroare.Text = "Categoria nu poate fi goală!";
                return;
            }
            else lblCategorie.ForeColor = Color.Black;

            if (!decimal.TryParse(txtSuma.Text, out decimal suma) || suma <= 0)
            {
                lblSuma.ForeColor = Color.Red;
                lblEroare.Text = "Suma trebuie să fie un număr pozitiv!";
                return;
            }
            else lblSuma.ForeColor = Color.Black;

            if (!DateTime.TryParse(txtData.Text, out DateTime data))
            {
                lblData.ForeColor = Color.Red;
                lblEroare.Text = "Format de dată invalid!";
                return;
            }
            else lblData.ForeColor = Color.Black;

            lblEroare.Text = "";

            dgvCheltuieli.Rows.Add(categorie, suma, data.ToString("yyyy-MM-dd"));
            txtCategorie.Clear();
            txtSuma.Clear();
            txtData.Clear();
        }
    }
}
