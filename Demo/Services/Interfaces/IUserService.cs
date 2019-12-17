using Demo.Models;
using System.Collections.Generic;

namespace Demo.Services.Interfaces
{
    public interface IUserService
    {
         List<User> GetUsers();
         User AddUpdateUser(User userVM);
         User DeleteUser(int Id);
    }
}