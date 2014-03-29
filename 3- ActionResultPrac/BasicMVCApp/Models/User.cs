using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicMVCApp.Models
{
    public class User
    {
        public String username
        {
            get;
            set;
        }
        public String company
        {
            get;
            set;
        }
        public String login
        {
            get;
            set;
        }

        public String password
        {
            get;
            set;
        }

        public List<Address> UserAddress
        {
            get;
            set;
        }

        public List<String> Education
        {
            get;
            set;
        }
    }

    public class Address
    {
        public String Country
        {
            get;
            set;
        }
        public String City
        {
            get;
            set;
        }
    }
}