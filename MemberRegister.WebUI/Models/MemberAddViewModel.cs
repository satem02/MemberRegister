using System;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.WebUI.Models {
    public class MemberAddViewModel {
        public Member MemberInfo { get; set; }
        public MemberAddViewModel () {
            MemberInfo = new Member ();
        }
    }
}