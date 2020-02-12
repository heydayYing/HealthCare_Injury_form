using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HealthCare_Injury_Form
{
    public class SqliteDataAccess
    {
        readonly IDbConnection database;
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public SqliteDataAccess()
        {
            string cnn = LoadConnectionString();
            database = new SQLiteConnection(cnn);
            
        }

        public bool verifyUser(string userName, string pwd)
        {
            //var userItem = database.c
            //return userItem != null;
            return false;
        }

    }
}
