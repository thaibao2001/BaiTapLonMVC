using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Security;

namespace Shop.Application.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private DBContext db = new DBContext();
        public JsonResult LoginAdmin(Account account)
        {
            db.Configuration.ProxyCreationEnabled = false;
            bool check = false;
            foreach (Account item in db.Accounts.ToList())
            {
                if (item.Username.Trim().Equals(account.Username) && item.Password.Trim().Equals(account.Password))
                {
                    check = true;
                    Session["Account"] = item;
                }
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}