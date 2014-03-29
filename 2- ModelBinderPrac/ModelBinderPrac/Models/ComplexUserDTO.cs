using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinderPrac.Models
{

    //A class to hold our data, it constains 'UserAddress' which is object of another 'user defined' type
    public class ComplexUserDTO
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
        public String Login
        {
            get;
            set;
        }

        public String Password
        {
            get;
            set;
        }

        public Address UserAddress
        {
            get;
            set;
        }
    }

    
}