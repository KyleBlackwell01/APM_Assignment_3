using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiG1N2.Models
{
    public class Teacher
    {
        public string TName { get; set; }

        public Teacher()
        {

        }

        public Teacher(string name)
        {
            TName = name;
        }
    }
}