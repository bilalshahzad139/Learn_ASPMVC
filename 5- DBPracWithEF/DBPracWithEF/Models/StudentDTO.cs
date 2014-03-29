using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{

    [Table("Students")]
    public class StudentDTO
    {
        [Key]
        public int StudentID
        {
            get;
            set;
        }
        public String StudentName
        {
            get;
            set;
        }
        public String FatherName
        {
            get;
            set;
        }

        public  List<AddressDTO> Addresses
        {
            get;
            set;
        }
    }
}