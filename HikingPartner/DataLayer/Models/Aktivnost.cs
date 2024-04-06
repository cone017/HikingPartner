using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Krsto...

namespace DataLayer.Models
{
    public class Aktivnost
    {
        public int AktivnostID;
        public string NazivAktivnosti;
        public DateTime DatumPocetka;
        public int Trajanje;
        public string Opis;
        public string Lokacija;
        public int TipAktivnostiID;
        public string MejlAdresa;


        public Aktivnost() { }


        public Aktivnost(int aktivnostID, string nazivAktivnosti, DateTime datumPocetka, int trajanje, string opis, string lokacija, int tipAktivnostiID, string mejlAdresa)
        {
            AktivnostID = aktivnostID;
            NazivAktivnosti = nazivAktivnosti;
            DatumPocetka = datumPocetka;
            Trajanje = trajanje;
            Opis = opis;
            Lokacija = lokacija;
            TipAktivnostiID = tipAktivnostiID;
            MejlAdresa = mejlAdresa;
        }
    }
}