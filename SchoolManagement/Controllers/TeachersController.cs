using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolManagement.Models;
using SchoolManagement.ViewModel;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private ApplicationUserManager _userManager;

        public TeachersController()
        {
        }

        public TeachersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Teachers
        public ActionResult Index()
        {
            List<TeacherViewModel> list = new List<TeacherViewModel>();
            foreach (var user in UserManager.Users)
            {
                list.Add(new TeacherViewModel(user));
            }
            return View(list);
        }

    }
}