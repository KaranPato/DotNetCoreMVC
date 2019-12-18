using System.Collections.Generic;
using Demo.Controllers;
using Demo.Models;
using Demo.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTest {
    [TestClass]
    public class Student {
        private readonly Mock<IUserService> _userService;

        public Student ( ) {
            _userService = new Mock<IUserService> ( );
        }

        List<User> expectedResult = new List<User> {
            new User {
            UserId = 10,
            FirstName = "Karan",
            LastName = "Patokar",
            Email = "karan@gmail.com",
            PhoneNumber = "7845123265",
            Address = "Akola"
            },
            new User {
            UserId = 11,
            FirstName = "Tushar",
            LastName = "Sontakke",
            Email = "tushar@gmail.com",
            PhoneNumber = "7896541230",
            Address = "Khapri"
            }
        };

        /// <summary>
        /// Test method for get user success
        /// </summary>
        [TestMethod]
        public void GetUsers_Success ( ) {
            StudentController _studentController = new StudentController (_userService.Object);
            _userService.Setup (s => s.GetUsers ( )).Returns (expectedResult);
            var response = (OkObjectResult) _studentController.GetUsers ( );
            var res = response.Value;
            res.Should ( ).BeEquivalentTo (expectedResult);
            Assert.AreEqual (200, response.StatusCode);
        }

        /// <summary>
        /// Test method for no users found.
        /// </summary>
        [TestMethod]
        public void GetUsers_NotFound ( ) {
            StudentController _studentController = new StudentController (_userService.Object);
            _userService.Setup (s => s.GetUsers ( )).Returns (new List<User> ( ));
            var response = (NotFoundResult) _studentController.GetUsers ( );
            Assert.AreEqual (404, response.StatusCode);
        }

        /// <summary>
        /// Test method for get users exception.
        /// </summary>
        [TestMethod]
        public void GetUsers_Exception ( ) {
            StudentController _studentController = new StudentController (_userService.Object);
            _userService.Setup (s => s.GetUsers ( )).Throws (new System.Exception ( ));
            var response = (StatusCodeResult) _studentController.GetUsers ( );
            Assert.AreEqual (500, response.StatusCode);
        }
    }
}