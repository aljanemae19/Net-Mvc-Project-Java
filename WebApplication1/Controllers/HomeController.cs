using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["firstname"];
            String lastName = fc["lastname"];
            String email = fc["email"];
            String diko = fc["password"];

            user use = new user();
            use.firstname = firstName;
            use.lastName = lastName;
            use.email = email;
            use.password = diko;
            use.roleID = 1;

            friendEntities fe = new friendEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("Login");
        }

        public ActionResult ShowUser()
        {
            friendEntities fe = new friendEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }
        public ActionResult EditUser(int id)
        {
            friendEntities fe = new friendEntities();
            var user = fe.users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(user updatedUser)
        {
            friendEntities fe = new friendEntities();
            fe.Entry(updatedUser).State = System.Data.Entity.EntityState.Modified;
            fe.SaveChanges();
            return RedirectToAction("ShowUser");
        }

        public ActionResult DeleteUser(int id)
        {
            friendEntities fe = new friendEntities();
            var user = fe.users.Find(id);
            fe.users.Remove(user);
            fe.SaveChanges();
            return RedirectToAction("ShowUser");
        }
        public ActionResult Update(int id, string new_firstname, string new_lastname, string new_email, string new_password)
        {
            friendEntities fe = new friendEntities();
            var user = fe.users.Find(id);

            // Update user properties with new values
            user.firstname = new_firstname;
            user.lastname = new_lastname;
            user.email = new_email;
            user.password = new_password;

            // Save changes to the database
            fe.SaveChanges();

            // Redirect to a different action (e.g., ShowUser)
            return RedirectToAction("ShowUser");
        }
    }


}
