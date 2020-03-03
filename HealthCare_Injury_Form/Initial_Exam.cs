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


        private Control initialTab()
        {
            var initialTabl = new TabControl();
            initialTabl.Location = new Point(270,139);
            initialTabl.Size = new Size(468, 238);
            TabPage page1 = new TabPage { Text="Date"};
            page1.Controls.Add(new Label { Text = "Initial Exam date.." });
            page1.Controls.Add(new TextBox { Name = "exam_date" });
            initialTabl.Controls.Add(page1);
            return initialTabl;
        }

        private void lbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSection.SelectedIndex;
            switch (index)
            {
                case 0:
                    this.Controls.Add(initialTab());
                    break;


            }
        }
    }
}
