using StudentCRUDDemo.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.Models
{
    [Table("UserTable")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required First Name")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Firstname Should be > 3 & < 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Firstname Should be > 3 & < 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [EmailAddress(ErrorMessage ="Not a valid email")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password mismatch")]
        public string Confirm_Password { get; set; }

        [Required(ErrorMessage = "Required Mobile Number")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage ="Required DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage ="Required Gender")]
        public string Gender { get; set; }  

        [Required(ErrorMessage ="Required Role ")]
        public int RoleId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDt { get; set; } = DateTime.Now;


        [NotMapped]
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}