using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Student
    {
        [Key]
        public int StudentID
        {
            get;
            set;
        }

        [Required(ErrorMessage="Enter Name Please")]
        [StringLength(30, ErrorMessage="Must be under 30 characters")]
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

        [RegularExpression("[0-9]*\\.?[0-9]+", ErrorMessage = "Age must be a number")]
        [Range(15,50, ErrorMessage="Age must be between 15 and 50")]
        public int Age
        {
            get;
            set;
        }
    }
}