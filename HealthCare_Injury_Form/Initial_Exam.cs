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
        static SqliteDataAccess database = fmLogin.Database;
        private Patient patient;
        private init_Exam exam;
        private int index;
        public Initial_Exam(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            lbSection.ItemHeight = 23;
            this.exam = database.GetInitExam(patient.id);
            //initialize the exam. if the patient id already exists in database initExam table, get that exam. otherwise create a new exam.
            this.exam = database.GetInitExam(patient.id)==null?new init_Exam { personID = patient.id, initExamDate = this.dpInitExamDate.Value.Date, position = "", handsOn = "",
                strikeOther = false,  struckBy=false, firstCollision="",secondCollision="",seatBeltWear=false, braceFImpact="",
                facingImpact="",steerWheel="",windshield="",leftSDoor="",rightSDoor="",leftSWindow="",rightSWindow="",
                roof="",dashboard="",otherItem="",sBackBrokenOBend=false,noAirBag=false,vSeatBeltSign=false, airBagDeployed=false,
                jawOLife=false,immFelt="",extendFelt="", otherFelt="",wentHosp=false,HospName="", amitTHos=false, duration="",whenTHos="",
                transport="",treatments = { },otherTreatments="",aComment=""}:database.GetInitExam(patient.id);
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
            if (this.exam != null)
            {
                this.dpInitExamDate.Value = this.exam.initExamDate;
                checkRadioButton(this.gbPosition, this.exam.position);
                if (this.exam.position == "driver")
                {
                    checkRadioButton(this.gbDriver, this.exam.handsOn);
                }
                else
                {
                    checkRadioButton(this.gbDriver, "");
                }
                 this.cbStrick.Checked= this.exam.strikeOther ;
                this.cbStruckBy.Checked=this.exam.struckBy;
                if (this.exam.struckBy)
                {
                    this.cbFCollision.SelectedItem=this.exam.firstCollision;
                    this.cbSCollision.SelectedItem = this.exam.secondCollision;
                }
                this.cbSBelt.Checked= this.exam.seatBeltWear;
                checkRadioButton(this.gbBrace, this.exam.braceFImpact);
                checkRadioButton(this.gbFacing, this.exam.facingImpact);

            }
        
            }

        private void lbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.index = lbSection.SelectedIndex;           
            switch (index)
            {
                case 0:
                    this.flowLayoutPanel1.Controls.Clear();
                    this.flowLayoutPanel1.Controls.Add(this.tabInit);
                    break;

                case 1:
                    this.flowLayoutPanel1.Controls.Clear();
                    break;

            }
        }

        /*
         * When user click the driver button in Position tabpage, the hands position buttons enabled. otherwise they are disabled.   
         */
        private void gbPosition_Enter(object sender, EventArgs e)
        {
            if(rbDriver.Checked)
            {
                foreach (Control rbControl in gbDriver.Controls)
                {
                    rbControl.Enabled = true;
                }
            }
            else{
                foreach (Control rbControl in gbDriver.Controls)
                {
                    rbControl.Enabled = false;
                    ((RadioButton)rbControl).Checked = false;
                }
            }
        }

        private void checkRadioButton(GroupBox rdbuttons, string indicator)
        {
            foreach(Control c in rdbuttons.Controls)
            {
                if (c.GetType()==typeof(RadioButton)&& c.Text == indicator)
                {
                    ((RadioButton)c).Checked = true;
                }
            }
        }

        /*
         *when use selecte one tabpage, the deselected page will store info into database. 
         */
        private void tabInit_SelectedIndexChanged(object sender, TabControlEventArgs e)
        {
            int index = e.TabPageIndex;
            switch (index)
            {
                case 0:
                    this.exam.initExamDate = this.dpInitExamDate.Value.Date;
                    break;

                case 1:
                    this.exam.position = groupRadioButon_Checked(this.gbPosition)==String.Empty?null: groupRadioButon_Checked(this.gbPosition);
                    if (this.exam.position == "driver")
                    {
                        this.exam.handsOn = groupRadioButon_Checked(this.gbDriver)==String.Empty?null:groupRadioButon_Checked(this.gbDriver);
                    }
                    break;

                case 2:
                    this.exam.strikeOther = this.cbStrick.Checked;
                    this.exam.struckBy = this.cbStruckBy.Checked;
                    if (this.exam.struckBy)
                    {
                        this.exam.firstCollision = this.cbFCollision.SelectedItem!=null?this.cbFCollision.SelectedItem.ToString():null;
                        this.exam.secondCollision = this.cbSCollision.SelectedItem != null? this.cbSCollision.SelectedItem.ToString():null;
                    }
                    this.exam.seatBeltWear = this.cbSBelt.Checked;
                    this.exam.braceFImpact = groupRadioButon_Checked(this.gbBrace)==String.Empty?null: groupRadioButon_Checked(this.gbBrace);
                    this.exam.facingImpact = groupRadioButon_Checked(this.gbFacing)==String.Empty?null: groupRadioButon_Checked(this.gbFacing);
                    break;

                case 3:
                    this.exam.steerWheel = this.cbSWheel.Checked ? this.cbSWheel.Text + ": " + this.txtSWheel.Text:null;
                    this.exam.windshield = this.cbWShield.Checked ? this.cbWShield.Text + ": " + this.txtWShield.Text : null;
                    this.exam.leftSDoor = this.cbLSDoor.Checked ? this.cbLSDoor.Text + ": " + this.txtLSDoor.Text : null;
                    this.exam.rightSDoor = this.cbRSDoor.Checked ? this.cbRSDoor.Text + ": " + this.txtRSDoor.Text : null;
                    this.exam.leftSWindow= this.cbLSWindow.Checked ? this.cbLSWindow.Text + ": " + this.txtLSWindow.Text : null;
                    this.exam.rightSDoor = this.cbRSWindow.Checked ? this.cbRSWindow.Text + ": " + this.cbRSWindow.Text : null;
                    this.exam.roof= this.cbRoof.Checked ? this.cbRoof.Text + ": " + this.txtRoof.Text : null;
                    this.exam.dashboard= this.cbDashboard.Checked ? this.cbDashboard.Text + ": " + this.txtDashboard.Text : null;
                    this.exam.otherItem = this.cbOItem.Checked ? this.cbOItem.Text + ": " + this.txtOItem.Text : null;
                    break;

                case 4:
                    this.exam.sBackBrokenOBend = this.cbSBack.Checked;
                    this.exam.noAirBag = this.cbAbag.Checked;
                    this.exam.vSeatBeltSign = this.cbSeatBelt.Checked;
                    this.exam.airBagDeployed = this.cbAbag.Checked;
                    this.exam.jawOLife = this.cbEmergency.Checked;
                    this.exam.immFelt = this.cbbPFelt.SelectedItem!=null?this.cbbPFelt.SelectedItem.ToString():null;
                    this.exam.extendFelt = this.txtPFelt.Text;
                    this.exam.otherFelt = this.txtOther.Text;
                    break;


            }
            database.saveInit_exam(this.exam);

        }

        public string groupRadioButon_Checked(GroupBox group)
        {
            string result = "";
            foreach(Control control in group.Controls)
            {
                if(control.GetType() == typeof(RadioButton)&&((RadioButton)control).Checked)
                {
                    result = control.Text;
                }
            }
            return result;
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            }
            else
            {
                // Otherwise, draw the rectangle filled in beige.
                e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
            }

            // Draw a rectangle in blue around each item.
            e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);

            // Draw the text in the item.
            e.Graphics.DrawString(this.lbSection.Items[e.Index].ToString(),
                this.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index > -1)
            {
                if (e.Index == this.index)
                {
                    e.ItemHeight += 10;
                }
                else
                {
                    e.ItemHeight = 23;
                }
            }

        }
    }

   
}
