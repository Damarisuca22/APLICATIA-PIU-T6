using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
namespace NivelStocareDate
{
    public class AdministrareUtilizatoriFisier
    {
        private const string numeFisier = "utilizatori.txt";

        public static void ScrieUtilizatori(List<Utilizator> utilizatori)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier))
            {
                foreach (var utilizator in utilizatori)
                {
                    writer.WriteLine(utilizator.Info());  // Scriem doar numele utilizatorului
                }
            }
        }

        public static List<Utilizator> CitesteUtilizatori()
        {
            List<Utilizator> utilizatori = new List<Utilizator>();

            if (File.Exists(numeFisier))
            {
                foreach (var linie in File.ReadAllLines(numeFisier))
                {
                    utilizatori.Add(Utilizator.FromString(linie));  // Creăm utilizatori din fișier
                }
            }

            return utilizatori;
        }
    }
}
