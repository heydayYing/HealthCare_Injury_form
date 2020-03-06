using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_Injury_Form
{
    public partial class init_Exam
    {
        public int iExamID { get; set; }
        public int personID { get; set; }
        public DateTime initExamDate { get; set; }
        
    }

    public partial class init_Exam
    {
        public String position { get; set; }
        public String handsOn { get; set; }
    }

    public partial class init_Exam
    {
        public bool strikeOther { get; set; }
        public bool struckBy { get; set; }
        public string firstCollision { get; set; }
        public string secondCollision { get; set; }
        public bool seatBeltWear { get; set; }
        public string braceFImpact { get; set; }
        public string facingImpact { get; set; }
    }

    public partial class init_Exam
    {
        public string steerWheel { get; set; }
        public string windshield { get; set; }
        public string leftSDoor { get; set; }
        public string rightSDoor { get; set; }
        public string leftSWindow { get; set; }
        public string rightSWindow { get; set; }
        public string roof { get; set; }
        public string dashboard { get; set; }
        public string otherItem { get; set; }
    }

    public partial class init_Exam
    {
        public bool sBackBrokenOBend { get; set; }
        public bool noAirBag { get; set; }
        public bool vSeatBeltSign { get; set; }
        public bool airBagDeployed { get; set; }
        public bool jawOLife { get; set; }
        public string immFelt { get; set; }
        public string extendFelt { get; set; }
        public string otherFelt { get; set; }
    }

    public partial class init_Exam
    {
        public bool wentHosp { get; set; }
        public string HospName { get; set; }
        public bool amitTHos { get; set; }
        public string duration { get; set; }
        public string whenTHos { get; set; }
        public string transport { get; set; }
        public Array treatments { get; set; }
        public string otherTreatments { get; set; }
    }

    public partial class init_Exam
    {
        public string aComment { get; set; }
    }
}
