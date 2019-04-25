namespace Exercise0001.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Exercise0001.Models;
    using Exercise0001.Models.TablesViewModels;
    using Exercise0001.Models.ViewModels;

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = new List<UserTableViewModel>();

            using (Example001Entities dbContext = new Example001Entities())
            {
                lst = (from d in dbContext.users
                       join s in dbContext.cstates on d.idState equals s.id
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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            using (var dbContext = new Example001Entities())
            {
                var idState = (from s in dbContext.cstates where s.name.Equals("Active") select s.id).FirstOrDefault();

                var oUser = new user()
                {
                    username = userViewModel.UserName,
                    password = userViewModel.Password,
                    name = userViewModel.Name,
                    idState = idState
                };

                dbContext.users.Add(oUser);
                dbContext.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    }
}