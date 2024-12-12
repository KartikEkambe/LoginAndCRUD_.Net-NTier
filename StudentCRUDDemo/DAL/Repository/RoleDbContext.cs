using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.DAL.Repository
{
    public class RoleDbContext :DbContext
    {
        public RoleDbContext() : base("RolesConnection") { }
        public DbSet<Role> Roles { get; set; }
    }
}