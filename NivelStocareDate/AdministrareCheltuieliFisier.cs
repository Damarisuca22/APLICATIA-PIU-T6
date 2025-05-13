using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareCheltuieliFisier
    {
        private const string numeFisier = "cheltuieli.txt";

        public static void ScrieCheltuieli(List<Cheltuiala> cheltuieli)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier))
            {
                foreach (var cheltuiala in cheltuieli)
                {
                    writer.WriteLine(cheltuiala.Info());  // Scriem datele cheltuielii
                }
            }
        }

        public static List<Cheltuiala> CitesteCheltuieli()
        {
            List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

            if (File.Exists(numeFisier))
            {
                string[] linii = File.ReadAllLines(numeFisier);
                foreach (var linie in linii)
                {
                    Cheltuiala cheltuiala = Cheltuiala.FromString(linie);
                    if (cheltuiala != null)
                    {
                        cheltuieli.Add(cheltuiala);
                    }
                }
            }
           /* else
            {
                MessageBox.Show("Fișierul cheltuieli.txt nu a fost găsit!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            return cheltuieli;
        }
    }
}
