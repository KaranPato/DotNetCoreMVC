using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Demo.Models;
using Demo.Services.Interfaces;

namespace Demo.Services.Implementation {
    public class UserService : IUserService {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UserService (UserContext userContext, IMapper mapper) {
            _userContext = userContext;
            _mapper = mapper;
        }

        public User AddUpdateUser (User user) {
            if (user != null) {
                if (user.UserId > 0) {
                    _userContext.User.Update (user);
                } else {
                    _userContext.User.Add (user);
                }
                _userContext.SaveChanges ( );

                return user;
            } else {
                return null;
            }
        }

        public User DeleteUser (int Id) {
            if (Id > 0) {
                var user = _userContext.User.SingleOrDefault (s => s.UserId == Id);
                if (user != null) {
                    _userContext.Remove (user);
                    _userContext.SaveChanges ( );
                    return user;
                } else {
                    return null;
                }
            } else {
                return null;
            }
        }

        public void Dispose ( ) {
            throw new System.NotImplementedException ( );
        }

        public List<User> GetUsers ( ) {
            var users = _userContext.User.ToList ( );
            if (users.Count ( ) > 0) {
                return users;
            } else {
                return null;
            }
        }

        public User GetUserById (int? Id) {
            var user = _userContext.User.SingleOrDefault (s => s.UserId == Id);

            if (user != null) {
                return user;
            } else {
                return null;
            }
        }
    }
}