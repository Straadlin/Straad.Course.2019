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
                       where s.name.Equals("Active")
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var dbContext = new Example001Entities())
            {
                var oUser = dbContext.users.Find(id);

                model.Id = oUser.id;
                model.Name = oUser.name;
                model.UserName = oUser.username;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var dbContext = new Example001Entities())
            {
                var oUser = dbContext.users.Find(model.Id);
                oUser.name = model.Name;
                oUser.username = model.UserName;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                dbContext.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var dbContext = new Example001Entities())
            {
                var oUser = dbContext.users.Find(id);
                var oState = dbContext.cstates.Where(s => s.name.Equals("Deleted")).FirstOrDefault();

                oUser.cstate = oState;
                dbContext.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }

            return Content("1");
        }
    }
}