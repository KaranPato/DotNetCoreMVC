using Demo.Services.Interfaces;
using Demo.ViewModels;
using Demo.Models;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace Demo.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UserService(UserContext userContext, IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
        }

        public ResponseVM AddUpdateUser(UserVM userVM)
        {
            ResponseVM responseVM = new ResponseVM();

            if (userVM != null)
            {
                User user = _mapper.Map<UserVM, User>(userVM);
                _userContext.User.Add(user);
                _userContext.SaveChanges();

                UserVM uservm = _mapper.Map<User, UserVM>(user);

                responseVM.Content = uservm;
                responseVM.IsSuccess = true;
                responseVM.Message = "Added Successfully";
                responseVM.StatusCode = 200;
            }

            else
            {
                responseVM.Content = null;
                responseVM.IsSuccess = false;
                responseVM.Message = "Invalid Data";
                responseVM.StatusCode = 404;
            }

            return responseVM;
        }

        public ResponseVM DeleteUser(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public ResponseVM GetUsers()
        {
            ResponseVM responseVM = new ResponseVM();
            var users = _userContext.User.ToList();
            List<UserVM> userVM = _mapper.Map<User, UserVM>(users);

            if (users.Count() > 0)
            {
                responseVM.Content = userVM;
                responseVM.IsSuccess = true;
                responseVM.Message = "Success";
                responseVM.StatusCode = 200;
            }
            else
            {
                responseVM.Content = null;
                responseVM.IsSuccess = false;
                responseVM.Message = "No Record found";
                responseVM.StatusCode = 404;
            }

            return responseVM;
        }
    }
}