using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Demo.Services.Interfaces;

namespace Demo.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {
        private readonly IUserService _userService;

        public StudentController (IUserService userService) {
            _userService = userService;
        }

        /// <summary>
        /// This method is used to get all users.
        /// </summary>
        /// <returns code="200">Successfully Fetched</returns>
        /// <returns code="404">Users Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        // GET api/student
        [HttpGet ("GetUsers")]
        public IActionResult GetUsers ( ) {
            try {
                var users = _userService.GetUsers ( );
                if (users.Count() > 0)
                    return Ok (users);
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }

        // GET api/student/5
        [HttpGet ("GetUserById/{id}")]
        public IActionResult GetUserById (int id) {
            try {
                var user = _userService.GetUserById (id);
                if (user != null)
                    return Ok (user);
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }

        /// <summary>
        /// This method is used to add/update an user.
        /// </summary>
        /// <returns code="200">Successfully Added/Updated</returns>
        /// <returns code="404">User Not Found</returns>
        /// <returns code="500">Exception occured</returns>
        // POST api/student
        [HttpPost ("AddUpdateUser")]
        public IActionResult AddUpdateUser ([Bind] User uservm) {
            try {
                var user = _userService.AddUpdateUser (uservm);
                if (user != null)
                    return Ok (user);
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
        [HttpDelete ("DeleteUser/{Id}")]
        public IActionResult DeleteUser (int Id) {
            try {
                var user = _userService.DeleteUser (Id);
                if (user != null)
                    return Ok (user);
                else
                    return NotFound ( );
            } catch (System.Exception) {
                return StatusCode (500);
            }
        }
    }
}