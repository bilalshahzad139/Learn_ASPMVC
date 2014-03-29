using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicMVCApp.Models
{
    public class Student
    {
        public int StudentID
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }
        public String Address
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
    }
}