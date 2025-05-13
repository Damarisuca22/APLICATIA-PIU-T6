using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareCheltuieli
    {
        private List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

        // Metoda pentru a adăuga o cheltuială
        public void AddCheltuiala(Cheltuiala cheltuiala)
        {
            cheltuieli.Add(cheltuiala);
        }

        // Metoda pentru a obține lista de cheltuieli
        public List<Cheltuiala> GetCheltuieli()
        {
            return cheltuieli;
        }
    }
}
