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
        static SqliteDataAccess database;
        public static SqliteDataAccess Database
        {
            get
            {
                if (database == null) {
                    database = new SqliteDataAccess();
                }
                return database;
            }  
        }

        public fmLogin()
        {
            InitializeComponent();
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLgn_Click(object sender, EventArgs e)
        {
            database = Database;
            try
            {
                if (database.verifyUser(txtName.Text, txtPwd.Text))
                {
                    this.Hide();
                    Registration regForm = new Registration();
                    regForm.Show();
                }
                else
                {
                    string message = "The user name doesn't exist or the password doesn't match";
                    string caption = "Login Failure";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        // Clean the text boxes for new input
                        txtName.Text = "";
                        txtPwd.Text = "";
                    }
                }
            }
            catch (Exception error)
            {
                string message = error.Message;
                MessageBox.Show(message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
