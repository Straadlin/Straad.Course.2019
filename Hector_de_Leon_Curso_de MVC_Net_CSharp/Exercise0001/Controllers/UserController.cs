namespace Exercise0001.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Exercise0001.Models;
    using Exercise0001.Models.TablesViewModels;

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = new List<UserTableViewModel>();

            using (Example001Entities dbContext = new Example001Entities())
            {
                lst = (from d in dbContext.users join s in dbContext.cstates on d.idState equals s.id
                      select new UserTableViewModel
                      {
                          Id = d.id,
                          Name = d.name,
                          UserName = d.username,
                          Password = d.password
                      }).ToList();

            }

            return View(lst);
        }
    }
}