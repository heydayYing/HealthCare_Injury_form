using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
            database.Open();
            
        }

        public bool verifyUser(string name, string pswd)
        {
            
                var userItem = database.Query<User>("Select * from User where userName = '"+name+"'"+" and pwd = '"+pswd+"'", new DynamicParameters());
                
                return userItem.Count() != 0;
            
           
           
        }

    }
}
