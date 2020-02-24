using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HealthCare_Injury_Form
{
    public class SqliteDataAccess
    {
        readonly IDbConnection database;
        
        public SqliteDataAccess()
        {
            string parentDir= Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string relativePath = "HealthCareDB.db";
            string absolutePath = Path.Combine(parentDir, relativePath);
            string cnn = string.Format("Data Source={0};Version=3;Integrated Security=True", absolutePath);
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
