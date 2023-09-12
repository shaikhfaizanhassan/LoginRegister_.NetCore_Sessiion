using loginregister.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginregister.Controllers
{
    public class UserController : Controller
    {
       
        private readonly userDbContext db;

        public UserController(userDbContext db) {
            this.db = db;

        }

      
        public IActionResult Index()
        {
            if (TempData["show"] != null)
            {
                return RedirectToAction("Welome");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Welcome()
        {

            //HttpContext.Session.SetString("MySessionVariable", "Hello, dynamic session!");
           // var sessionValue = HttpContext.Session.GetString("MySessionVariable");
           // ViewBag.sessionValue = sessionValue;

        if(TempData["show"]!=null)
            {
                return RedirectToAction("Welome");
            }
        else
            {
                return RedirectToAction("Index");
            }

            

        }

        public IActionResult login(usertb utb)
        {

            var login = db.usertbs.Where(x => x.email == utb.email && x.password == utb.password).SingleOrDefault();
            if (login != null)
            {
                HttpContext.Session.SetString("email", login.email.ToString());
                var sessionemail = HttpContext.Session.GetString("email");
                //HttpContext.Session.SetString("email", login.email.ToString());
                TempData["show"] = sessionemail;
                return RedirectToAction("Welcome");

            }
            else
            {
                TempData["errormessage"] = "Invalid Login";
                return RedirectToAction("Index");

            }
        }

            

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index");
        }
    }
}
