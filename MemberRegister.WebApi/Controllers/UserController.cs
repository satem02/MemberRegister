using System;
using System.Collections.Generic;
using MemberRegister.Business.Abstract;
using MemberRegister.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MemberRegister.WebApi.Controllers {
    [Route("api/[controller]")]
    public class UserController {
        IUserService _userService;
        public UserController (IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        public void Add (User user) {
            _userService.Add (user);
        }

        [HttpGet]
        public IEnumerable<User> Get () {
            return _userService.GetList ();
        }
    }
}