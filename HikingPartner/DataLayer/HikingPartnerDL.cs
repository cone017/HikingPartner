using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HikingPartnerDL
    {
        static string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HikingPartner;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool CheckLogin(String username, String password)
        {

            bool pass = false;

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;

                try
                {
                    string comand = "SELECT * FROM Korisnik WHERE ImePrezime='" + username + "' AND Sifra='" + password + "'";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comand, sqlConnection);

                    DataTable dtable = new DataTable();
                    sqlDataAdapter.Fill(dtable);

                    Console.WriteLine(dtable.Rows.Count);

                    if (dtable.Rows.Count > 0)
                        pass = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    sqlConnection.Close();
                }
            }
            return pass;
        }

        public int UpdateKorisnik(Korisnik korisnik)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                string sqlCommand = "UPDATE Korisnik SET Sifra=@SIFRA, Telefon=@TELEFON WHERE MejlAdresa = @MEJLADRESA";
                SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);
                command.Parameters.AddWithValue("@SIFRA", korisnik.Sifra);
                command.Parameters.AddWithValue("@TELEFON", korisnik.Telefon);
                command.Parameters.AddWithValue("@MEJLADRESA", korisnik.MejlAdresa);

                sqlConnection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public Aktivnost GetAktivnost(int id)
        {
            Aktivnost a = new Aktivnost();


            using (SqlConnection sql = new SqlConnection(connString)) {
                sql.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sql;

                sqlCommand.CommandText = "SELECT * FROM Aktivnost WHERE AktivnostID=" + id;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    a.AktivnostID = reader.GetInt32(0);
                    a.NazivAktivnosti = reader.GetString(1);
                    a.DatumPocetka = reader.GetDateTime(2);
                    a.Trajanje = reader.GetInt32(3);
                    a.Opis = reader.GetString(4);
                    a.Lokacija = reader.GetString(5);
                    a.TipAktivnostiID = reader.GetInt32(6);
                    a.MejlAdresa = reader.GetString(7);
                }
            }
            return a;
        }

        public List<Aktivnost> GetAllAktivnosti()
        {

            var productList = new List<Aktivnost>();

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM Aktivnost";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Aktivnost a = new Aktivnost();

                    a.AktivnostID = dataReader.GetInt32(0);
                    a.NazivAktivnosti = dataReader.GetString(1);
                    a.DatumPocetka = dataReader.GetDateTime(2);
                    a.Trajanje = dataReader.GetInt32(3);
                    a.Opis = dataReader.GetString(4);
                    a.Lokacija = dataReader.GetString(5);
                    a.TipAktivnostiID = dataReader.GetInt32(6);
                    a.MejlAdresa = dataReader.GetString(7);

                    productList.Add(a);
                }
            }
            return productList;
        }

        public int insertUser(Korisnik k)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("INSERT INTO Korisnik VALUES('{0}', '{1}', '{2}', '{3}', '{4}','{5}')", 
                    k.ImePrezime, k.MejlAdresa, k.Sifra, k.Telefon, k.Pol,k.Interesovanje);

                return sqlCommand.ExecuteNonQuery();

            }
        }

        public Korisnik GetKorisnik(string user)
        {
            Korisnik a = new Korisnik();

            using (SqlConnection sql = new SqlConnection(connString))
            {
                sql.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sql;

                sqlCommand.CommandText = string.Format("SELECT * FROM Korisnik WHERE ImePrezime='{0}'", user);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    
                    a.ImePrezime = reader.GetString(1);
                    a.MejlAdresa = reader.GetString(2);
                    a.Sifra = reader.GetString(3);
                    a.Telefon = reader.GetString(4);
                    a.Pol = reader.GetString(5);
                }
            }
            return a;
        }

        public List<ClanoviAktivnost> GetAllClanovi(int id)
        {
            List<ClanoviAktivnost> lista = new List<ClanoviAktivnost>();

            using (SqlConnection sql = new SqlConnection(connString))
            {
                sql.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sql;

                sqlCommand.CommandText = "SELECT * FROM ClanoviAktivnosti WHERE AktivnostId=" + id;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {

                    ClanoviAktivnost a = new ClanoviAktivnost();
                    
                    a.ClanoviAktivnostId = reader.GetInt32(0);
                    a.MejlAdresa = reader.GetString(1);
                    a.AktivnostID = reader.GetInt32(2);
                    a.Naziv = reader.GetString(3);
                    a.PridruzeniClan = reader.GetString(4);

                    lista.Add(a);
                }
            }
            return lista;
        }

        public int DeleteAktivnost(int id, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "DELETE FROM Aktivnost WHERE AktivnostID = @AktivnostID AND MejlAdresa = @Mejl";
                sqlCommand.Parameters.AddWithValue("@AktivnostID", id);
                sqlCommand.Parameters.AddWithValue("@Mejl", email);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteClanAktivnosti(int id, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "DELETE FROM ClanoviAktivnosti WHERE MejlAdresa = @Email AND AktivnostId = @ID";
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@ID", id);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int IsUserCreatorOfActivity(int id, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "SELECT * FROM Aktivnost WHERE AktivnostID = @ID AND MejlAdresa = @email";
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.Parameters.AddWithValue("@email", email);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int IsUserInActivity(int id, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "SELECT * FROM ClanoviAktivnosti WHERE AktivnostId = @ID AND MejlAdresa = @email";
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.Parameters.AddWithValue("@email", email);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public bool CheckKorisnik(string username, int id)
        {
            bool pass = true;

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;

                try
                {
                    string comand = "SELECT * FROM ClanoviAktivnosti WHERE PridruzeniClan='" + username + "' AND AktivnostId='" + id + "'";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comand, sqlConnection);

                    DataTable dtable = new DataTable();
                    sqlDataAdapter.Fill(dtable);

                    Console.WriteLine(dtable.Rows.Count);

                    if (dtable.Rows.Count > 0)
                        pass = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    sqlConnection.Close();
                }
            }
            return pass;
        }

        public bool CheckAktivnostId(int id)
        {
            bool pass = true;

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;

                try
                {
                    string comand = "SELECT * FROM Aktivnost WHERE AktivnostID=" + id;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comand, sqlConnection);

                    DataTable dtable = new DataTable();
                    sqlDataAdapter.Fill(dtable);

                    Console.WriteLine(dtable.Rows.Count);

                    if (dtable.Rows.Count > 0)
                        pass = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    sqlConnection.Close();
                }
            }
            return pass;
        }

        public int insertClan(Korisnik k, Aktivnost a)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("INSERT INTO ClanoviAktivnosti VALUES('{0}', '{1}', '{2}','{3}')",
                    k.MejlAdresa, a.AktivnostID, a.NazivAktivnosti,k.ImePrezime);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int insertAktivnost(Aktivnost a)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = string.Format("INSERT INTO Aktivnost VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
               a.AktivnostID, a.NazivAktivnosti, a.DatumPocetka, a.Trajanje, a.Opis, a.Lokacija, a.TipAktivnostiID, a.MejlAdresa);

                return sqlCommand.ExecuteNonQuery();

            }
        }
        public int insertInteresovanje(Korisnik k,string interesovanje)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = string.Format("UPDATE Korisnik SET Interesovanje = ('{0}') WHERE MejlAdresa = ('{1}')",
                    interesovanje,k.MejlAdresa);

                return sqlCommand.ExecuteNonQuery();

            }

        }
        public string GetInteresovanje(string nazivKorisnika)
        {
            string interesovanje = "";

            using (SqlConnection sql = new SqlConnection(connString))
            {
                sql.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT Interesovanje FROM Korisnik WHERE ImePrezime = @nazivKorisnika", sql))
                {
                    sqlCommand.Parameters.AddWithValue("@nazivKorisnika", nazivKorisnika);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interesovanje = reader.GetString(0);
                        }
                    }
                }
            }

            return interesovanje;
        }


    }
}
