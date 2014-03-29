using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsRazorPrac.Models
{
    public class ComplexUser2DTO
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
        
        public Address UserAddress
        {
            get;
            set;
        }
    }


}