using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{
    public class Users
    {
        [Key]
        public Int32 UserID
        {
            get;
            set;
        }
        public String FirstName
        {
            get;
            set;
        }
        public String LastName
        {
            get;
            set;
        }
        public String Gender
        {
            get;
            set;
        }
        public DateTime DOB
        {
            get;
            set;
        }
        public String City
        {
            get;
            set;
        }
        public int AccountType
        {
            get;
            set;
        }
        public String Login
        {
            get;
            set;
        }
        
        [DataType(DataType.Password)]
        public String Password
        {
            get;
            set;
        }
        public DateTime EntryDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
    }


}