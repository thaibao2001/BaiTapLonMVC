using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shop.DataAccessLayer;
using Shop.Business;

namespace Shop.Application.Controllers
{

    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult Login(string user, string password)
        {
            LoginBuss loginBuss = new LoginBuss();
            Account account=loginBuss.CheckAccount(user, password);
            if (account == null)
            {
                return Json(account, JsonRequestBehavior.AllowGet);
            }
            else
            {
                
                FormsAuthentication.SetAuthCookie(user, true);
                return Json(account, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home");
        }
    }
}