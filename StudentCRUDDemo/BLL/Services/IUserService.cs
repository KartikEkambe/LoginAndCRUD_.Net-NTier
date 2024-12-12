using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUDDemo.BLL.Services
{
    public interface IUserService
    {
        IEnumerable<Role> GetRoles();
        void AddUser(User user);
        IEnumerable<User> GetAllUser();
        User ValidUser(string email, string password);
        bool ExistEmail(string email);
    }
}
