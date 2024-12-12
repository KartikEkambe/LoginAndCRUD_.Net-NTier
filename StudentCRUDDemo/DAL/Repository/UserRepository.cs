using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCRUDDemo.Models;

namespace StudentCRUDDemo.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDbContext _dbContext;
        public UserRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User ValidUser(string email, string hashedPassword)
        {
            return _dbContext.Users.Where(u => u.Email == email && u.Password == hashedPassword)
            .FirstOrDefault();
        }
        public bool ExistEmail(string email)
        {
            return _dbContext.Users.Any(e=>e.Email==email);
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }

       
    }
}