using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberRegister.Business.Abstract;
using MemberRegister.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MemberRegister.WebApi.Controllers {
    [Route ("api/[controller]")]
    public class MemberController : Controller {

        IMemberService _memberService;
        public MemberController (IMemberService memberService) {
            _memberService = memberService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Member> GetAll () {
            return _memberService.GetList ();
        }
        // GET api/values/5
        [HttpGet ("{id}")]
        public Member Get (string id) {
            return _memberService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post (Member member) { 
            _memberService.Add(member);
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (string id) { 
            _memberService.DeleteById(id);
        }
    }
}