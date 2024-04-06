using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using BusinessLayer;

namespace DataLayerTests
{
    [TestClass]
    public class Class1
    {
        private HikingPartnerBL hiking;

        private Korisnik korisnik = new Korisnik
        {
            KorisnikID = 12,
            ImePrezime = "Aleksa Matovic",
            MejlAdresa = "aleksamatovic@gmail.com",
            Telefon = "0621592555",
            Pol = "Muski",
            Interesovanje = "Trcanje"
        };

        private Aktivnost aktivnost = new Aktivnost
        {
            AktivnostID = 15,
            NazivAktivnosti = "Testna aktivnost",
            DatumPocetka = new DateTime(2024, 12, 12),
            Trajanje = 1,
            Opis = "testna aktivnost opis",
            Lokacija = "Test",
            TipAktivnostiID = 1,
            MejlAdresa = "ojdraganevino@gmail.com"
        };

        [TestMethod]
        public void isKorisnikInserted()
        {
            this.hiking = new HikingPartnerBL();
            var result = hiking.CheckInsertUser(korisnik);

            if (result)
                result = true;
            else
                result = false;
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void isAktivnostInserted()
        {
            this.hiking = new HikingPartnerBL();
            var result = hiking.InsertAktivnost(aktivnost);

            if (result)
                result = true;
            else
                result = false;
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void isKorisnikReturned()
        {
            this.hiking = new HikingPartnerBL();
            var result = hiking.GetKorisnik(korisnik.ImePrezime);
            bool tacno = true;

            if (result.ImePrezime == korisnik.ImePrezime)
                tacno = true;
            else
                tacno = false;
            // Assert
            Assert.IsTrue(tacno);
        }

        [TestMethod]
        public void isGetAllAktivnostiReturned()
        {
            this.hiking = new HikingPartnerBL();
            var result = hiking.GetAllAktivnosti();
            bool tacno = true;

            if (result != null)
                tacno = true;
            else
                tacno = false;
            // Assert
            Assert.IsTrue(tacno);
        }

        [TestMethod]
        public void isGetAlClanoviReturned()
        {
            this.hiking = new HikingPartnerBL();
            var result = hiking.GetAllClanovi(aktivnost.AktivnostID);
            bool tacno = true;

            if (result != null)
                tacno = true;
            else
                tacno = false;
            // Assert
            Assert.IsTrue(tacno);
        }

    }
}