using Demo.ViewModels;

namespace Demo.Services.Interfaces
{
    public interface IUserService
    {
         ResponseVM GetUsers();
         ResponseVM AddUpdateUser(UserVM userVM);
         ResponseVM DeleteUser(int Id);
    }
}