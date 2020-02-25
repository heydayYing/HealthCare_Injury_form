using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_Injury_Form
{
    public class Patient
    {
        public int id {get; set;}
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }

        public Patient(DateTime date, DateTime time, string fname, string mname, string lname,
            int gender, string phone, string mobile, string address, string city, string province, string post)
        {
            Date = date;
            Time = time;
            Fname = fname;
            Mname = mname;
            Lname = lname;
            Gender = gender;
            Phone = phone;
            Mobile = mobile;
            Address = address;
            City = city;
            Province = province;
            Postal = post;
        }
    }
}
