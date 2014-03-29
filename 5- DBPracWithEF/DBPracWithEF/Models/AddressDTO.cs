using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{

    [Table("Addresses")]
    public class AddressDTO
    {
        [Key]
        public int AddressID
        {
            get;
            set;
        }
        public String City
        {
            get;
            set;
        }
        public String ZipCode
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
    }
}