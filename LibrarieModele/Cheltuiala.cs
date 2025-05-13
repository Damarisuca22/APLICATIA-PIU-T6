using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarieModele
{
  
    public class Cheltuiala
    {
        
        public CategorieCheltuiala Categorie { get; set; }
        public double Suma { get; set; }
        public string Data { get; set; }
        public Utilizator Utilizator { get; set; }

        public Cheltuiala(CategorieCheltuiala categorie, double suma, string data, Utilizator utilizator)
        {
            Categorie = categorie;
            Suma = suma;
            Data = data;
            Utilizator = utilizator;
        }

        public string Info()
        {
            return $"{Categorie},{Suma},{Data},{Utilizator.Nume}";
        }

        public static Cheltuiala FromString(string linie)
        {
            string[] date = linie.Split(',');

            if (date.Length == 4) // Asigură-te că există exact 4 elemente
            {
                if (double.TryParse(date[1], out double suma))
                {
                    if (Enum.TryParse(date[0], true, out CategorieCheltuiala categorie))
                    {
                        Utilizator utilizator = new Utilizator(date[3]);
                        return new Cheltuiala(categorie, suma, date[2], utilizator);
                    }
                }
            }

            return null;
        }



    }
}
