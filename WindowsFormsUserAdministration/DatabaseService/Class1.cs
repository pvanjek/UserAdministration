using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace DatabaseService
{
    // Kako mi mozemo koristiti funkcije ?  Moramo dodati referencu i uklj biblioteku.
    public class Crud
    {
        public List<User> GetUsers()
        {
            List<User> lUsers = new List<User>();
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "SELECT * FROM users";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lUsers.Add(new User()
                        {
                            nUserID = (int)oReader["USER_ID"],
                            sUserName = (string)oReader["USERNAME"],
                            sUserPassword = (string)oReader["PASSWORD"],
                            sUserFirstName = (string)oReader["NAME"],
                            sUserLastName = (string)oReader["SURNAME"]
                        });
                    }
                }
            }
            return lUsers;
        }

        public void UpdateUsers(User oUser) // prima objekte usera
        {
            string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand()) // kada se izvsi da se oslobodni memorija koju je ta varijabla zauzela
            {
                oCommand.CommandText = "UPDATE USERS SET NAME = '" + oUser.sUserFirstName + "', SURNAME = '" + oUser.sUserLastName + "', PASSWORD = '" + oUser.sUserPassword + "' WHERE USER_ID = " + oUser.nUserID;// napravili query
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                }
            }
        }
        public void DeleteUsers(User oUser)
        {
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())

            {
                Debug.WriteLine("DELETE FROM users WHERE USER_ID = '" + oUser.nUserID + "'");
                oCommand.CommandText = "DELETE FROM users WHERE USER_ID = '" + oUser.nUserID + "'";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
            }
        }
        public void AddUsers(User oUser)
        {
            // string sSqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            String sSqlConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                oCommand.CommandText = "INSERT INTO users (USERNAME, PASSWORD, NAME, SURNAME) VALUES ('" + oUser.sUserName + "', '" + oUser.sUserPassword + "', '" + oUser.sUserFirstName + "', '" + oUser.sUserLastName + "');";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
            }

        }
    }
}