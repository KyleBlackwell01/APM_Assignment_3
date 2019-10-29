using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiG1N2.Models
{
    public class Student
    {
        public int Barcode { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }

        public Student()
        {

        }

        public Student(int bcode, int sid, string name)
        {
            Barcode = bcode;
            StudentID = sid;
            Name = name;
        }
    }
}