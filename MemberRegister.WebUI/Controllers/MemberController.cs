using MemberRegister.Business.Abstract;
using MemberRegister.Entities.Concrete;
using MemberRegister.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MemberRegister.Controllers {
    public class MemberController : Controller {
        private IMemberService _memberService;
        public MemberController (IMemberService memberService) {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult Index () {
            return View ();
        }

        [HttpGet]
        public IActionResult Welcome () {
            ViewData["Message"] = "Lastet Your welcome message";

            return View ();
        }

        [HttpGet]
        public IActionResult List () {
            var result = _memberService.GetList ();
            var response = new MemberListViewModel ();
            response.Members = result;
            return View (response);
        }

        [HttpGet]
        public IActionResult Add () {
            var model = new MemberAddViewModel () { MemberInfo = new Member () };
            return View (model);
        }

        [HttpPost]
        public IActionResult Add (MemberAddViewModel model) {
            _memberService.Add (model.MemberInfo);
            return RedirectToAction ("List");
        }

        public IActionResult Delete (string memberId) {
            _memberService.DeleteById (memberId);
            
            return RedirectToAction ("List");
        }

        [HttpPost]
        public IActionResult Update (MemberAddViewModel model) {
            var member = model.MemberInfo;
            _memberService.Update (member);
            return RedirectToAction ("List");
        }
        public IActionResult Update (string memberId) {
            var member = _memberService.GetById (memberId);
            var model = new MemberAddViewModel () { MemberInfo = member };
            return View (model);
        }
    }
}