namespace HealthCare_Injury_Form
{
    partial class Patients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvPatient = new System.Windows.Forms.ListView();
            this.clnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPatient
            // 
            this.lvPatient.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnID,
            this.clnName,
            this.clnAge,
            this.clnGender,
            this.clnPhone});
            this.lvPatient.Location = new System.Drawing.Point(109, 52);
            this.lvPatient.Name = "lvPatient";
            this.lvPatient.Size = new System.Drawing.Size(587, 278);
            this.lvPatient.TabIndex = 0;
            this.lvPatient.UseCompatibleStateImageBehavior = false;
            this.lvPatient.View = System.Windows.Forms.View.Details;
            this.lvPatient.ItemActivate += new System.EventHandler(this.lvPatient_ItemClick);
            // 
            // clnID
            // 
            this.clnID.Text = "ID";
            // 
            // clnName
            // 
            this.clnName.Text = "Name";
            this.clnName.Width = 143;
            // 
            // clnAge
            // 
            this.clnAge.Text = "Age";
            // 
            // clnGender
            // 
            this.clnGender.Text = "Gender";
            // 
            // clnPhone
            // 
            this.clnPhone.Text = "Phone";
            this.clnPhone.Width = 161;
            // 
            // btnAddNew
            // 
            this.btnAddNew.AllowDrop = true;
            this.btnAddNew.Location = new System.Drawing.Point(621, 349);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New ";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lvPatient);
            this.Name = "Patients";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPatient;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ColumnHeader clnID;
        private System.Windows.Forms.ColumnHeader clnName;
        private System.Windows.Forms.ColumnHeader clnGender;
        private System.Windows.Forms.ColumnHeader clnPhone;
        private System.Windows.Forms.ColumnHeader clnAge;
    }
}