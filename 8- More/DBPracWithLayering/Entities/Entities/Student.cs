using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Student
    {
        [Key]
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