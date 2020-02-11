using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Injury_Form
{
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLgn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\user2\source\repos\HealthCare_Injury_Form\HealthCare_Injury_Form\Database1.mdf; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Login where username=")
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
