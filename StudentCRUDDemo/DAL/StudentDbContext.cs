using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.DAL
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext():base("StudentsConnection") { }
        public DbSet<Student> students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        
    }
}