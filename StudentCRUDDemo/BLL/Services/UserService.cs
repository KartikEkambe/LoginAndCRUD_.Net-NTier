using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCRUDDemo.DAL.Repository;
using StudentCRUDDemo.Models;

namespace StudentCRUDDemo.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
      

        public UserService(IUserRepository userRepository,IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public IEnumerable<Role> GetRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAllUsers();
        }

        public User ValidUser(string email, string password)
        {
            return _userRepository.ValidUser(email, password);
        }

        public bool ExistEmail(string email)
        {
            return _userRepository.ExistEmail(email);
        }
    }
}