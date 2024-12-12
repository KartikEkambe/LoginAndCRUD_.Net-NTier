using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCRUDDemo.Models;

namespace StudentCRUDDemo.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StudentDbContext _dbContext;
        public RoleRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }
    }
}