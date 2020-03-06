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
        public Initial_Exam(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            lbSection.ItemHeight = 23;
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

        
            }

        private void lbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSection.SelectedIndex;
            lbSection.ItemHeight = 32;
            switch (index)
            {
                case 0:
                    lbSection.ItemHeight = 32;
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

        private void tabInit_SelectedIndexChanged(object sender, TabControlEventArgs e)
        {
            int index = e.TabPageIndex;
            switch (index)
            {
                case 0:
                    this.exam.initExamDate = this.dpInitExamDate.Value.Date;
                    break;

                case 1:
                    this.exam.position = groupRadioButon_Checked(this.gbPosition);
                    if (this.exam.position == "driver")
                    {
                        this.exam.handsOn = this.lblHand.Text +" "+ groupRadioButon_Checked(this.gbDriver);
                    }
                    break;

                case 2:
                    this.exam.strikeOther = this.cbStrick.Checked;
                    this.exam.struckBy = this.cbStruckBy.Checked;
                    if (this.exam.struckBy)
                    {
                        this.exam.firstCollision = this.cbFCollision.SelectedItem!=null?this.cbFCollision.SelectedItem.ToString():"";
                        this.exam.secondCollision = this.cbSCollision.SelectedItem != null? this.cbSCollision.SelectedItem.ToString():"";
                    }
                    this.exam.seatBeltWear = this.cbSBelt.Checked;
                    this.exam.braceFImpact = "Braced: " +groupRadioButon_Checked(this.gbBrace);
                    this.exam.facingImpact = groupRadioButon_Checked(this.gbFacing);
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

        
    }

    public class BuddyListBox : ListBox
    {
        int thisIndex = -1;

        public BuddyListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                else
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                base.OnDrawItem(e);
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            thisIndex = this.SelectedIndex;
            this.RecreateHandle();
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index > -1)
            {
                if (e.Index == thisIndex)
                    e.ItemHeight = 32;
                else
                    e.ItemHeight = 16;
            }
            base.OnMeasureItem(e);
        }
    }
}
