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
    public partial class Patients : Form
    {
        static SqliteDataAccess database = fmLogin.Database;
        public Patients()
        {
            InitializeComponent();
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            var patients = database.getPatients();
            foreach(Patient p in patients)
            {
                ListViewItem item = new ListViewItem(p.id.ToString());
                item.SubItems.Add(p.Fname + " "+p.Mname+" " + p.Lname);
                item.SubItems.Add(p.Age.ToString());
                item.SubItems.Add(p.Gender);
                item.SubItems.Add(p.Phone);
                lvPatient.Items.Add(item);
            }       
        }

        private void lvPatient_ItemClick(object sender, EventArgs e)
        {
            int i = lvPatient.SelectedIndices[0];
            string s = lvPatient.Items[i].Text;
            Patient p = database.getPatient(Convert.ToInt32(s));
            this.Hide();
            new Registration(p).Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }

  
    }
}
