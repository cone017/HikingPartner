using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Korisnik
    {
        public int KorisnikID;
        public string ImePrezime;
        public string MejlAdresa;
        public string Sifra;
        public string Telefon;
        public string Pol;
        public string Interesovanje;

        public Korisnik() { }

        public Korisnik(int korisnikID, string imePrezime, string mejlAdresa, string sifra, string telefon, string pol, string interesovanje)
        {
            KorisnikID = korisnikID;
            ImePrezime = imePrezime;
            MejlAdresa = mejlAdresa;
            Sifra = sifra;
            Telefon = telefon;
            Pol = pol;
            Interesovanje = interesovanje;
        }
    }
}
