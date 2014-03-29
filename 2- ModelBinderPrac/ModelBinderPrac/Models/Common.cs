using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinderPrac.Models
{
    public class Address
    {
        public String City
        {
            get;
            set;
        }
        public String Country
        {
            get;
            set;
        }
    }

    public class EducationInfo
    {
        public String College
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
    }

    public class TestUser
    {
        public String UserName
        {
            get;
            set;
        }
        public String Company
        {
            get;
            set;
        }
        public String DOB
        {
            get;
            set;
        }
    }
}