namespace MyApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyApp.Models.ViewModels;

    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private Models.MyDBContext db;

        public ChatController(Models.MyDBContext context)
        {
            db = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<MessageViewModel> Message()
        {
            List<MessageViewModel> lst = null;

            lst = new List<MessageViewModel>();
            lst.Add(new MessageViewModel() { Id = 1, Name = "Alfredo", Text = "Hello" });
            lst.Add(new MessageViewModel() { Id = 2, Name = "Amanda", Text = "Hi" });
            lst.Add(new MessageViewModel() { Id = 3, Name = "Alfredo", Text = "How are you?" });

            return lst;
        }

        //[HttpGet("[action]")]
        //public IActionResult Message()
        //{
        //    List<Models.Message> lst = null;

        //    lst = new List<Models.Message>();
        //    lst.Add(new Models.Message() { Id = 1, Name = "Alfredo", Text = "Hello" });
        //    lst.Add(new Models.Message() { Id = 2, Name = "Amanda", Text = "Hi" });
        //    lst.Add(new Models.Message() { Id = 3, Name = "Alfredo", Text = "How are you?" });

        //    //lst = db.Message.ToList();

        //    return Json(lst);
        //}
    }
}
