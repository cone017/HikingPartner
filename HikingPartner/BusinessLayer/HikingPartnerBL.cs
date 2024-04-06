using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class HikingPartnerBL
    {
        readonly HikingPartnerDL hikingPartnerDL = new HikingPartnerDL();

        public bool CheckLogin(string username, string password)
        {
            return hikingPartnerDL.CheckLogin(username, password);
        }

        public bool CheckInsertUser(Korisnik k)
        {
            return hikingPartnerDL.insertUser(k) != 0;
        }

        public bool UpdateKorisnik(Korisnik k)
        {
            return hikingPartnerDL.UpdateKorisnik(k) != 0;    
        }

        public Aktivnost GetAktivnost(int id)
        {
            return hikingPartnerDL.GetAktivnost(id);
        }

        public List<Aktivnost> GetAllAktivnosti()
        {
            return hikingPartnerDL.GetAllAktivnosti();
        }

        public Korisnik GetKorisnik(string user)
        {
            return hikingPartnerDL.GetKorisnik(user);
        }

        public List<ClanoviAktivnost> GetAllClanovi(int id)
        {
            return hikingPartnerDL.GetAllClanovi(id);
        }

        public bool CheckKorisnik(string user, int id)
        {
            return hikingPartnerDL.CheckKorisnik(user, id);
        }

        public bool CheckAktivnostId(int id)
        {
            return hikingPartnerDL.CheckAktivnostId(id);
        }

        public bool InsertClan(Korisnik k, Aktivnost a)
        {
            return hikingPartnerDL.insertClan(k, a) != 0;
        }

        public bool DeleteAktivnost(int id, string email)
        {
            return hikingPartnerDL.DeleteAktivnost(id, email) != 0;
        }

        public bool DeleteClanAktivnost(int id, string email)
        {
            return hikingPartnerDL.DeleteClanAktivnosti(id, email) != 0;
        }

        public bool IsUserCreatorOfActivity(string email, int id)
        {
            return hikingPartnerDL.IsUserCreatorOfActivity(id, email) != 0;
        }

        public bool IsUserInActivity(string email, int id)
        {
            return hikingPartnerDL.IsUserCreatorOfActivity(id, email) != 0;
        }

        public bool InsertAktivnost(Aktivnost a)
        {
            return hikingPartnerDL.insertAktivnost(a) != 0;
        }
        public bool InsertInteresovanje(Korisnik k,string interesovanje)
        {
            return hikingPartnerDL.insertInteresovanje(k, interesovanje) != 0;
        }
        public List<Aktivnost> GetAllAktivnostiFiltrirane(int idInteresovanja)
        {
            return hikingPartnerDL.GetAllAktivnosti()
        .Where(aktivnost => aktivnost.TipAktivnostiID == idInteresovanja)
        .ToList();
        }
        public string GetInteresovanje(string nazivKorisnika)
        {
            return hikingPartnerDL.GetInteresovanje(nazivKorisnika);
        }

        

    }
}
