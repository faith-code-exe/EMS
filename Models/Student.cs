using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Models
{
    class Student
    {
        public int id { get; set; }

        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }

        public string scholarshipGrant { get; set; }
        public string idNumber { get; set; }
        public string ay { get; set; }

        public string sex { get; set; }
        public string civilStatus { get; set; }
        public string program { get; set; }
        public string yrLevel { get; set; }
        public string sem { get; set; }

        public string basisOfAdmission { get; set; }
        public string dateOfBirth { get; set; }
        public string placeOfBirth { get; set; }

        public string elemCompleted { get; set; }
        public string elemYrGrad { get; set; }

        public string hsCompleted { get; set; }
        public string hsYrGrad { get; set; }

        public string parentsGuardian { get; set; }
        public string contactNo { get; set; }

        public string address { get; set; }
        public string email { get; set; }
    }
}
