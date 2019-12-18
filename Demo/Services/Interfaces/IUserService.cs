using Demo.Models;
using System.Collections.Generic;

namespace Demo.Services.Interfaces
{
    public interface IUserService
    {
         List<User> GetUsers();
         User GetUserById(int? Id);
         User AddUpdateUser(User userVM);
         User DeleteUser(int Id);
    }
}