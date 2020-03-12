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
            
            cmd.CommandText= @"CREATE TABLE IF NOT EXISTS InitExam (
                    iExamID   INTEGER PRIMARY KEY AUTOINCREMENT,
                    personID  INTEGER NOT NULL UNIQUE,
                    initExamDate  DATE,
	                position   TEXT,
	                handsOn   TEXT,
	                StrikeOther   BOOL,
	                StruckBy  BOOL,
	                firstCollision    TEXT,
	                secondCollision  TEXT,
	                seatBeltWear  BOOL,
	                braceFImpact  TEXT,
	                facingImpact  TEXT,
	                steerWheel    TEXT,
	                windshield    TEXT,
	                leftSDoor TEXT,
	                rightSDoor    TEXT,
	                leftSWindow   TEXT,
	                rightSWindow  TEXT,
	                roof  TEXT,
	                dashboard TEXT,
	                otherItem TEXT,
	                sBackBrokenOBend  BOOL,
	                noAirBag  BOOL,
	                vSeatBeltSign BOOL,
	                airBagDeployed    BOOL,
	                jawOLife  BOOL,
	                immFelt   TEXT,
	                extendFelt    TEXT,
	                otherFelt TEXT,
	                wentHosp  BOOL,
	                HospName  TEXT,
	                amitTHos  BOOL,
	                duration  TEXT,
	                whenTHos  TEXT,
	                transport TEXT,
	                treatments    TEXT,
	                otherTreatments   TEXT,
	                aComment  TEXT,
	                FOREIGN KEY(personID) REFERENCES people(id)
                )";
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

        //get all patients
        public Array getPatients()
        {
            var patients = database.Query<Patient>("Select * from People ORDER BY fname ASC, lname ASC", new DynamicParameters());
            return patients.ToArray();
        }

        //get one patient with given id
        public Patient getPatient(int id)
        {
            var patient = database.Query<Patient>("Select * from People Where id ='"+id+"'", new DynamicParameters()).FirstOrDefault();
            return patient;
        }

        //save or update the init_exam. if the exam has id>0, save it. otherwise update it
        public int saveInit_exam(init_Exam exam)
        {
            string sqlSave = "Insert INTO InitExam(personID, initExamDate, position, handsOn, StrikeOther, StruckBy, firstCollision, secondCollision, " +
                "seatBeltWear, braceFImpact, facingImpact, steerWheel, windshield, leftSDoor, rightSDoor, leftSWindow, rightSWindow, roof, dashboard, " +
                "otherItem, sBackBrokenOBend, noAirBag, vSeatBeltSign, airBagDeployed, jawOLife, immFelt, extendFelt, otherFelt, wentHosp, HospName, " +
                "amitTHos, duration, whenTHos, transport, treatments, otherTreatments, aComment) Values " +
                "(@personID, @initExamDate, @position, @handsOn, @strikeOther, @struckBy, @firstCollision, @secondCollision, " +
                 "@seatBeltWear, @braceFImpact, @facingImpact, @steerWheel, @windshield, @leftSDoor, @rightSDoor, @leftSWindow, @rightSWindow, @roof, @dashboard, " +
                "@otherItem, @sBackBrokenOBend, @noAirBag, @vSeatBeltSign, @airBagDeployed, @jawOLife, @immFelt, @extendFelt, @otherFelt, @wentHosp, @HospName, " +
                "@amitTHos, @duration, @whenTHos, @transport, @treatments, @otherTreatments, @aComment); ";

            string sqlUpdate = "Update InitExam SET initExamDate=@initExamDate, position=@position, handsOn=@handsOn, StrikeOther=@strikeOther, StruckBy=@struckBy, firstCollision=@firstCollision, secondCollision=@secondCollision, " +
                "seatBeltWear=@seatBeltWear, braceFImpact=@braceFImpact, facingImpact=@facingImpact, steerWheel=@steerWheel, windshield=@windshield, leftSDoor=@leftSDoor, rightSDoor=@rightSDoor, leftSWindow=@leftSWindow, rightSWindow=@rightSWindow, roof=@roof, dashboard=@dashboard, " +
                "otherItem=@otherItem, sBackBrokenOBend=@sBackBrokenOBend, noAirBag=@noAirBag, vSeatBeltSign=@vSeatBeltSign, airBagDeployed=@airBagDeployed, jawOLife=@jawOLife, immFelt=@immFelt, extendFelt=@extendFelt, otherFelt=@otherFelt, wentHosp=@wentHosp, HospName=@HospName, " +
                "amitTHos=@amitTHos, duration=@duration, whenTHos=@whenTHos, transport=@transport, treatments=@treatments, otherTreatments=@otherTreatments, aComment=@aComment WHERE personID=@personID";

            return GetInitExam(exam.personID)!=null?database.Execute(sqlUpdate,exam):database.Execute(sqlSave, exam);
        }

        //get init_exam with given personID
        public init_Exam GetInitExam(int id)
        {
            var exam= database.Query<init_Exam>("Select * from InitExam Where personID ='" + id + "'", new DynamicParameters()).FirstOrDefault();
            return exam;
        }
    }
}
