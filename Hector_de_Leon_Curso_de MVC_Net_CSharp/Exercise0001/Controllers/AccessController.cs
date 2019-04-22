using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise0001.Models;

namespace Exercise0001.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (Example001Entities dbContext = new Example001Entities())
                {
                    var lst = from d in dbContext.users
                              join s in dbContext.cstates on d.idState equals s.id
                              where d.username.Equals(user) && d.password.Equals(password) && s.name.Equals("Active")
                              select d;

                    if (lst.Count() == 1)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                }

                return Content("Invalid user.");
            }
            catch (Exception ex)
            {
                return Content("Ocurred an error: " + ex.Message);
            }
            finally
            {

            }
        }
    }
}