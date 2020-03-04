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
    public partial class Initial_Exam : Form
    {
        private Patient patient;
        public Initial_Exam(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            lbSection.ItemHeight = 23;
        }

        private void Initial_Exam_Load(object sender, EventArgs e)
        {
            lblFName.Text = patient.Fname;
            lblLName.Text = patient.Lname;
            if (patient.Mname == String.Empty)
            {
                lblLName.Left=113;
                lblMName.Hide();
            }
            else
            {
                lblMName.Text = patient.Mname;
            }
            lblGender.Text = this.patient.Gender;
            lblAge.Text = Convert.ToString(this.patient.Age);
            lblPhone.Text = this.patient.Phone;
            lblMobile.Text = this.patient.Mobile;
            lblAddress.Text = this.patient.Address;
            lblCity.Text = this.patient.City;
            lblProvince.Text = this.patient.Province;
            lblPost.Text = this.patient.Postal;
            
            
        }

        private void lbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSection.SelectedIndex;
            switch (index)
            {
                case 0:
                    this.flowLayoutPanel1.Controls.Add(this.tabInit);
                    break;

                case 1:
                    this.flowLayoutPanel1.Controls.Clear();
                    break;


            }
        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {

                if (!rbDriver.Checked)
                {
                    foreach (Control rbControl in gbDriver.Controls)
                    {
                         rbControl.Enabled = false;
                        ((RadioButton)rbControl).Checked = false;
                    }
                }
            
        }
    }
}
