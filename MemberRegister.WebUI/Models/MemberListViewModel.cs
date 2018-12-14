using System;
using System.Collections.Generic;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.WebUI.Models {
    public class MemberListViewModel {
        public IEnumerable<Member> Members { get; set; }
        public MemberListViewModel () {
            Members = new List<Member> ();
        }
    }
}