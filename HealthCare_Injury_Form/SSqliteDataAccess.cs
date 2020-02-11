using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sqlite;

namespace HealthCare_Injury_Form
{
    class SSqliteDataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static bool GetUser(string userNam)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString())) { }
        }
    }
}
