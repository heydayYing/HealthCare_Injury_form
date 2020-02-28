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
        readonly SQLiteConnection database;
        
        public SqliteDataAccess()
        {
            string parentDir= Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string relativePath = "HealthCareDB.db";
            string absolutePath = Path.Combine(parentDir, relativePath);
            string cnn = string.Format("Data Source={0};Version=3;Integrated Security=True", absolutePath);
            database = new SQLiteConnection(cnn);
            database.Open();

            SQLiteCommand cmd = new SQLiteCommand(cnn, database);
           
            //create people table
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS people(id INTEGER PRIMARY KEY,
                    fname TEXT(50) NOT NULL, mname TEXT, lname TEXT(50) NOT NULL, 
                    gender TEXT NOT NULL,
                    phone TEXT, mobile TEXT, address TEXT, city TEXT, province TEXT, postal TEXT,
                    age INT)";
            cmd.ExecuteNonQuery();
            
            database.Close();
            Console.WriteLine("Table people created");
        }

        //verify user by login form. return the user is null or not
        public bool verifyUser(string name, string pswd)
        {
                var userItem = database.Query<User>("Select * from User where userName = '"+name+"'"+" and pwd = '"+pswd+"'", new DynamicParameters());
                return userItem.Count() != 0; 
        }

        //save patient data into database
        public int savePatient(string fname, string mname, string lname, string gender,
            string phone, string mobile, string address, string city, string province,string postal, int age)
        {
            string sqlInsert = "Insert INTO people(fname, mname, lname, gender, phone, mobile, address, city, province, postal, age) Values" +
                " (@fname, @mname, @lname, @gender, @phone, @mobile, @address, @city, @province, @postal, @age);  ";
            Patient p = new Patient(fname, mname, lname, gender, phone, mobile, address, city, province, postal,age);
            var insert = database.Execute(sqlInsert, p);
            return insert;
        }

        //update existing patient
        public int updatePatient(Patient p)
        {
            string sqlUpdate = "Update people SET fname=@fname, mname= @mname, lname=@lname, gender=@gender, phone=@phone, " +
                "mobile=@mobile, address=@address, city=@city, province=@province, postal= @postal, age=@age WHERE id=@id";        
            var update = database.Execute(sqlUpdate, p);
            return update;
        }

        public Array getPatients()
        {
            var patients = database.Query<Patient>("Select * from People ORDER BY fname ASC, lname ASC", new DynamicParameters());
            return patients.ToArray();
        }

        public Patient getPatient(int id)
        {
            var patient = database.Query<Patient>("Select * from People Where id ='"+id+"'", new DynamicParameters()).FirstOrDefault();
            return patient;
        }
    }
}
