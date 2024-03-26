using EFFrm.Entity;
using EFFrm.StudentFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm
{

    public class Student 
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? departmentId { get; set; }
        public Department Department { get; set; }
    }
}
