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
        public Registration()
        {
            InitializeComponent();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == null || txtLName.Text == null || !(rdbFemale.Checked || rdbMale.Checked))
            {
                MessageBox.Show("Please input information for required field");
            }
            else
            {
                string gender = rdbMale.Checked ? "Male" : "Female";
                try
                {
                        database.savePatient(txtFName.Text, txtMName.Text, txtLName.Text, gender,
                        txtPhone.Text, txtMobile.Text, txtAddress.Text, txtCity.Text, txtProvince.Text, txtPost.Text);
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
    }
}
