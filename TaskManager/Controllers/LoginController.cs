using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskManager.DAL;
using TaskManager.Models;
using TaskManager.Util;

namespace TaskManager.Controllers
{
    public class LoginController : Controller
    {
        private TaskManagerContext db = new TaskManagerContext();
        private const int  ENCYRPTION_KEY = 200;
        // GET: Login
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(User userr)
        {
            var loggedInUser = ValidateUser(userr.UserName, userr.Password);

            if (loggedInUser != null)
            {
                System.Web.HttpContext.Current.Session["userId"] = loggedInUser.UserId;
                FormsAuthentication.SetAuthCookie(userr.UserName, false);
                return RedirectToAction("Index", "Task", new { @id = loggedInUser.UserId });
            }
            else
            {
               ModelState.AddModelError("", "Login details are wrong.");
            }

            return View(userr);         
         }

        //Checks to see if a user exists in the database and passwords match
        [NonAction]
        private User ValidateUser(string userName, string password)
        {
            User loggedInUser;          
            try
            {
                loggedInUser = db.User.Where(u => u.UserName == userName).FirstOrDefault();
                
                if (loggedInUser != null)
                {
                    string decryptedPassword = SimpleEncryption.EncryptDecrypt(loggedInUser.Password, ENCYRPTION_KEY);
                    if (decryptedPassword == password)
                    {
                        return loggedInUser;
                    }
                    else
                    {
                        return null;
                    }                    
                }                    
                else
                    return null;
            }
            catch(Exception e)
            {
                return null;
                throw e;
            }           
        }     

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");             
        }     
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
