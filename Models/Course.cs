using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Models
{
    class Course
    {
        public int id { get; set; }
        public string courseCode { get; set; }
        public string descriptiveTitle { get; set; }
        public int lec { get; set; }
        public int lab { get; set; }
        public int units { get; set; }
        public string instructor { get; set; }
    }
}
