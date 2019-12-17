using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers {
    public class UserController : Controller {
        private readonly IUserService _userService;

        public UserController (IUserService userService) {
            _userService = userService;
        }

        /// <summary>
        /// This method is used to get all users.
        /// </summary>
        /// <returns code="200">Successfully Fetched</returns>
        /// <returns code="404">Users Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult GetUsers ( ) {
            try {
                var users = _userService.GetUsers ( );
                if (users != null)
                    return View (users);
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }

        public IActionResult AddUpdate ( ) {
            return View();
        }

        /// <summary>
        /// This method is used to add/update an user.
        /// </summary>
        /// <returns code="200">Successfully Added/Updated</returns>
        /// <returns code="404">User Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult AddUpdateUser ([Bind] User uservm) {
            try {
                var user = _userService.AddUpdateUser (uservm);
                if (user != null)
                    return RedirectToAction("GetUsers");
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }

        /// <summary>
        /// This method is used to delete an user
        /// </summary>
        /// <returns code="200">Successfully Deleted</returns>
        /// <returns code="404">User Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        public IActionResult DeleteUser ([Bind] int Id) {
            try {
                var user = _userService.DeleteUser (Id);
                if (user != null)
                    return RedirectToAction ("GetUsers");
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }
    }
}