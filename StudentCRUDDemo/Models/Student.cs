using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.Models
{
    [Table("tblStudents")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Username Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage ="Department Required")]
        public string Department { get; set; }
        [Required(ErrorMessage ="Percentage Required")]
        public decimal Percentage { get; set; }
    }
}