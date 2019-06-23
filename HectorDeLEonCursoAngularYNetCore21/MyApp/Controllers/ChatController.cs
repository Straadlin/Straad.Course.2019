namespace MyApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private Models.MyDBContext db;

        public ChatController(Models.MyDBContext context)
        {
            db = context;
        }

        [HttpGet("[action]")]
        public IActionResult Message()
        {
            List<Models.Message> lst = null;

            lst = new List<Models.Message>();
            lst.Add(new Models.Message() { Id = 1, Name = "Alfredo", Text = "Hello" });
            lst.Add(new Models.Message() { Id = 1, Name = "Amanda", Text = "Hi" });
            lst.Add(new Models.Message() { Id = 1, Name = "Alfredo", Text = "How are you" });

            //lst = db.Message.ToList();

            return Json(lst);
        }
    }
}
