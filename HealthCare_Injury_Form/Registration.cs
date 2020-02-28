using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Injury_Form
{
    public partial class Registration : Form
    {
        static SqliteDataAccess database=fmLogin.Database;
        Patient p;
        public Registration()
        {
            InitializeComponent();
        }

        public Registration(Patient patient) : this(){
            this.p = patient;
            txtFName.Text = patient.Fname;
            txtMName.Text = patient.Mname;
            txtLName.Text = patient.Lname;
            txtAddress.Text = patient.Address;
            txtCity.Text = patient.City;
            txtPhone.Text = patient.Phone;
            txtPost.Text = patient.Postal;
            txtProvince.Text = patient.Province;
            nmAge.Value = patient.Age;
            rdbFemale.Checked = patient.Gender == "Female";
            rdbMale.Checked= patient.Gender == "Male";
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == null || txtLName.Text == null || !(rdbFemale.Checked || rdbMale.Checked))
            {
                MessageBox.Show("Please input information for required field(*)");
                return;
            }
            else
            {
                string gender = rdbMale.Checked ? "Male" : "Female";
                try
                {
                    if (this.p == null)
                    {
                        database.savePatient(txtFName.Text, txtMName.Text, txtLName.Text, gender,
                        txtPhone.Text, txtMobile.Text, txtAddress.Text, txtCity.Text, txtProvince.Text, txtPost.Text, (int)nmAge.Value);
                    }
                    else {
                        this.p.Fname = txtFName.Text;
                        this.p.Mname = txtMName.Text;
                        this.p.Lname = txtLName.Text;
                        this.p.Gender = gender;
                        this.p.Phone = txtPhone.Text;
                        this.p.Mobile = txtMobile.Text;
                        this.p.Address = txtAddress.Text;
                        this.p.City = txtCity.Text;
                        this.p.Province = txtProvince.Text;
                        this.p.Postal = txtPost.Text;
                        this.p.Age = (int)nmAge.Value;
                        database.updatePatient(this.p);
                    }
                    }
                catch (Exception error)
                {
                    string message = error.Message;
                    MessageBox.Show(message);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFName.Text = null; txtMName.Text = null; txtLName.Text = null;
            rdbMale.Checked = false;rdbFemale.Checked = false;
            txtPhone.Text = null; txtMobile.Text = null; txtAddress.Text = null;
            txtCity.Text = null; txtProvince.Text = null; txtPost.Text = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Patients().Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
