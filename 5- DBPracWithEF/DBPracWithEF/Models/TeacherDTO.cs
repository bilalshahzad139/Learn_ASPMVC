using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{

    [Table("Teachers")]
    public class TeacherDTO
    {
        [Column("TeacherID")]
        [Key]
        public int TID
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
        public String Subject
        {
            get;
            set;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn
        {
            get;
            set;
        }
    }
}