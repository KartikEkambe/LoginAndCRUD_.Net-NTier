using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUDDemo.DAL.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<Role> GetRoles();
        void AddUser(User user);
        User ValidUser(string email,string password);
        bool ExistEmail(string email);
    }
}
