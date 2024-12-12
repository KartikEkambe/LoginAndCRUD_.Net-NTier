using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCRUDDemo.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() :base ("UsersConnection"){}
        public DbSet<User> Users { get; set; }
       
    }

    
}