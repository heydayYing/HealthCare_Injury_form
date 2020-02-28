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
      
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }
        public int Age { get; set; }

        public Patient() { }

        public Patient(string fname, string mname, string lname,
            string gender, string phone, string mobile, string address, string city, string province, string post,int age)
        {
           
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
            Age = age;
        }

    }
}
