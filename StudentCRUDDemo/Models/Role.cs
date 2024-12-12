using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.Models
{
    [Table("RoleTable")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Required Role ")]
        [StringLength(50, ErrorMessage = "only 50 character")]
        public string RoleName { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDt { get; set; } = DateTime.Now;

        public virtual ICollection<User> Users { get; set; }
    }
}