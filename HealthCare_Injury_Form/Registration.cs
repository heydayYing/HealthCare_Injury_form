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

        private void Registration_Load(object sender, EventArgs e)
        {
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "yyyy/MM/dd";

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "hh:mm:ss";
            timePicker.ShowUpDown = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
