using DotNetCoreMVC.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Demo Method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Ok();
        }

        /// <summary>
        /// This method is used to get all users.
        /// </summary>
        /// <returns code="200">Successfully Fetched</returns>
        /// <returns code="404">Users Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users.IsSuccess)
                    return Ok(users);
                else
                    return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// This method is used to add/update an user.
        /// </summary>
        /// <returns code="200">Successfully Added/Updated</returns>
        /// <returns code="404">User Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult AddUpdateUser()
        {
            try
            {
                var user = _userService.AddUpdateUser();
                if (user.IsSuccess)
                    return Ok();
                else
                    return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// This method is used to delete an user
        /// </summary>
        /// <returns code="200">Successfully Deleted</returns>
        /// <returns code="404">User Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult DeleteUser()
        {
            try
            {
                var user = _userService.DeleteUser();
                if (user.IsSuccess)
                    return Ok(user);
                else
                    return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}