using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Administrator
    {
        public int AdministratorID;
        public string Username;
        public string Sifra;

        public Administrator() { }

        public Administrator(int administratorID, string username, string sifra)
        {
            AdministratorID = administratorID;
            Username = username;
            Sifra = sifra;
        }
    }
}
