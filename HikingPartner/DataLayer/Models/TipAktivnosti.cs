using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TipAktivnosti
    {
        public int TipID;
        public string Naziv;
        public string Opis;

        public TipAktivnosti() { }

        public TipAktivnosti(int tipID, string naziv, string opis)
        {
            TipID = tipID;
            Naziv = naziv;
            Opis = opis;
        }
    }
}
