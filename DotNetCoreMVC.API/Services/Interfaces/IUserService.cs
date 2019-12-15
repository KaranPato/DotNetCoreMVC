using System;
using DotNetCoreMVC.API.ViewModels;

namespace DotNetCoreMVC.API.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
         ResponseVM GetUsers();
         ResponseVM AddUpdateUser();
         ResponseVM DeleteUser();
    }
}