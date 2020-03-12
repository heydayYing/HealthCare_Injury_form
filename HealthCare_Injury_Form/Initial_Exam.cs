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
            //initialize the exam. if the patient id already exists in database initExam table, get that exam. otherwise create a new exam.
            this.exam = database.GetInitExam(patient.id)==null?new init_Exam { personID = patient.id, initExamDate = this.dpInitExamDate.Value.Date, position = "", handsOn = "",
                strikeOther = false,  struckBy=false, firstCollision="",secondCollision="",seatBeltWear=false, braceFImpact="",
                facingImpact="",steerWheel="",windshield="",leftSDoor="",rightSDoor="",leftSWindow="",rightSWindow="",
                roof="",dashboard="",otherItem="",sBackBrokenOBend=false,noAirBag=false,vSeatBeltSign=false, airBagDeployed=false,
                jawOLife=false,immFelt="",extendFelt="", otherFelt="",wentHosp=false,HospName="", amitTHos=false, duration="",whenTHos="",
                transport="",treatments ="",otherTreatments="",aComment=""}:database.GetInitExam(patient.id);
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
            
            if (this.exam.iExamID != 0)
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
                    Listbox_setupMultSelection(this.exam.firstCollision, this.lbFCollosion);
                    Listbox_setupMultSelection(this.exam.secondCollision, this.lbSCollision);
                }
                this.cbSBelt.Checked= this.exam.seatBeltWear;
                checkRadioButton(this.gbBrace, this.exam.braceFImpact);
                checkRadioButton(this.gbFacing, this.exam.facingImpact);
                this.cbSWheel.Checked = this.exam.steerWheel != null;
                this.txtSWheel.Text = this.exam.steerWheel;
                this.cbWShield.Checked = this.exam.windshield != null;
                this.txtWShield.Text = this.exam.windshield;
                this.cbLSDoor.Checked = this.exam.leftSDoor != null;
                this.txtLSDoor.Text = this.exam.leftSDoor;
                this.cbRSDoor.Checked = this.exam.rightSDoor != null;
                this.txtRSDoor.Text = this.exam.rightSDoor;
                this.cbLSWindow.Checked = this.exam.leftSWindow != null;
                this.txtLSWindow.Text = this.exam.leftSWindow;
                this.cbRSWindow.Checked = this.exam.rightSWindow != null;
                this.txtRSWindow.Text = this.exam.rightSWindow;
                this.cbRoof.Checked = this.exam.roof != null;
                this.txtRoof.Text = this.exam.roof;
                this.cbDashboard.Checked = this.exam.dashboard != null;
                this.txtDashboard.Text = this.exam.dashboard;
                this.cbOItem.Checked = this.exam.otherItem != null;
                this.txtOItem.Text = this.exam.otherItem;
                this.cbSBack.Checked=this.exam.sBackBrokenOBend;
                this.cbAbag.Checked = this.exam.noAirBag;
                this.cbSeatBelt.Checked= this.exam.vSeatBeltSign;
                this.cbAbag.Checked= this.exam.airBagDeployed ;
                this.cbEmergency.Checked = this.exam.jawOLife;
                Listbox_setupMultSelection(this.exam.immFelt, this.lbPFeel);
                this.txtPFelt.Text= this.exam.extendFelt ;
                this.txtOther.Text=this.exam.otherFelt;
                 this.cbPWHopspital.Checked= this.exam.wentHosp ;
                 this.txtHosName.Text= this.exam.HospName ;
                checkRadioButton(this.gpbATHos, this.exam.amitTHos==false?"No":"Yes");
                this.txtDuration.Text=this.exam.duration;
                this.cbbWtoHospital.SelectedItem = this.exam.whenTHos;
                this.cbbTBy.SelectedItem = this.exam.transport;
                Listbox_setupMultSelection(this.exam.treatments, this.lbTreatment);
                 this.txtOTreat.Text= this.exam.otherTreatments ;
                this.txtAHComments.Text=this.exam.aComment ;
            }
        
            }

        //set the selected treaments in multiple selectable listbox
        private void Listbox_setupMultSelection(string examProperty, ListBox listbox)
        {
            var items = examProperty.Split(';');        
            foreach (string item in items)
            {
                for (int i = 0; i < listbox.Items.Count; i++)
                {
                    if (item == listbox.Items[i].ToString())
                    {
                        listbox.SetSelected(i, true);
                    }
                }

            }
        }


        //select exam in list box to bring up responding tab control
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
            saveIndexTabPage(index);

        }

        public void saveIndexTabPage(int index)
        {
            switch (index)
            {
                case 0:
                    this.exam.initExamDate = this.dpInitExamDate.Value.Date;
                    break;

                case 1:
                    this.exam.position = groupRadioButon_Checked(this.gbPosition) == String.Empty ? null : groupRadioButon_Checked(this.gbPosition);
                    if (this.exam.position == "driver")
                    {
                        this.exam.handsOn = groupRadioButon_Checked(this.gbDriver) == String.Empty ? null : groupRadioButon_Checked(this.gbDriver);
                    }
                    break;

                case 2:
                    this.exam.strikeOther = this.cbStrick.Checked;
                    this.exam.struckBy = this.cbStruckBy.Checked;
                    if (this.exam.struckBy)
                    {
                        this.exam.firstCollision = Listbox_multiChoices(this.exam.firstCollision, this.lbFCollosion);
                        this.exam.secondCollision = Listbox_multiChoices(this.exam.secondCollision, this.lbSCollision);
                    }
                    this.exam.seatBeltWear = this.cbSBelt.Checked;
                    this.exam.braceFImpact = groupRadioButon_Checked(this.gbBrace) == String.Empty ? null : groupRadioButon_Checked(this.gbBrace);
                    this.exam.facingImpact = groupRadioButon_Checked(this.gbFacing) == String.Empty ? null : groupRadioButon_Checked(this.gbFacing);
                    break;

                case 3:
                    this.exam.steerWheel = this.cbSWheel.Checked ? this.txtSWheel.Text : null;
                    this.exam.windshield = this.cbWShield.Checked ? this.txtWShield.Text : null;
                    this.exam.leftSDoor = this.cbLSDoor.Checked ? this.txtLSDoor.Text : null;
                    this.exam.rightSDoor = this.cbRSDoor.Checked ? this.txtRSDoor.Text : null;
                    this.exam.leftSWindow = this.cbLSWindow.Checked ? this.txtLSWindow.Text : null;
                    this.exam.rightSWindow = this.cbRSWindow.Checked ? this.txtRSWindow.Text : null;
                    this.exam.roof = this.cbRoof.Checked ? this.txtRoof.Text : null;
                    this.exam.dashboard = this.cbDashboard.Checked ? this.txtDashboard.Text : null;
                    this.exam.otherItem = this.cbOItem.Checked ? this.txtOItem.Text : null;
                    break;

                case 4:
                    this.exam.sBackBrokenOBend = this.cbSBack.Checked;
                    this.exam.noAirBag = this.cbAbag.Checked;
                    this.exam.vSeatBeltSign = this.cbSeatBelt.Checked;
                    this.exam.airBagDeployed = this.cbAbag.Checked;
                    this.exam.jawOLife = this.cbEmergency.Checked;
                    this.exam.immFelt = Listbox_multiChoices(this.exam.immFelt, this.lbPFeel);
                    this.exam.extendFelt = this.txtPFelt.Text;
                    this.exam.otherFelt = this.txtOther.Text;
                    break;

                case 5:
                    this.exam.wentHosp = this.cbPWHopspital.Checked;
                    this.exam.HospName = this.txtHosName.Text;
                    this.exam.amitTHos = groupRadioButon_Checked(this.gpbATHos) == "Yes";
                    this.exam.duration = this.txtDuration.Text;
                    this.exam.whenTHos = this.cbbWtoHospital.SelectedItem != null ? this.cbbWtoHospital.SelectedItem.ToString() : null;
                    this.exam.transport = this.cbbTBy.SelectedItem != null ? this.cbbTBy.SelectedItem.ToString() : null;
                    this.exam.treatments = Listbox_multiChoices(this.exam.treatments, this.lbTreatment);
                    this.exam.otherTreatments = this.txtOTreat.Text;
                    break;

                case 6:
                    this.exam.aComment = this.txtAHComments.Text;
                    break;

            }
            database.saveInit_exam(this.exam);
        }

        public string Listbox_multiChoices(string examProperty, ListBox listBox)
        {
            if (listBox.SelectedItems != null)
            {
                 var items = listBox.SelectedItems.OfType<string>().ToArray();
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < items.Count(); i++)
                            {
                                if (i != 0)
                                {
                                    builder.Append(";");
                                }
                                builder.Append(items[i]);

                            }
                            examProperty = builder.ToString();
            }
            return examProperty;
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

        private void btSave_Click(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)this.flowLayoutPanel1.Controls[0];
            int idex = tc.SelectedIndex;
            saveIndexTabPage(idex);
        }
    }

   
}
