namespace Exercise0001.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Exercise0001.Models.WS;
    using Exercise0001.Models;

    public class AccessController : ApiController
    {
        [HttpGet]
        public Reply HelloWorld()
        {
            var oReplay = new Reply();
            oReplay.result = 1;
            oReplay.message = "Hellow World";

            return oReplay;
        }

        [HttpPost]
        public Reply Login([FromBody]AccessViewModel model)
        {
            Reply oReplay = new Reply();

            try
            {
                using (var dbContext = new Example002Entities())
                {
                    var query = from u in dbContext.Users
                                join s in dbContext.States on u.IdState equals s.Id
                                where s.Name.Equals("Active") && u.Email.Equals(model.email) && u.Password.Equals(model.password)
                                select u;

                    if(query.Count()==1)
                    {
                        oReplay.result = 1;
                        oReplay.data = Guid.NewGuid().ToString();

                        User oUser = query.First();
                        oUser.Token = oReplay.data.ToString();
                        dbContext.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        oReplay.message = "User's data are incorrect.";
                    }
                }
            }
            catch(Exception exception)
            {
                oReplay.message = string.Format("There was an error.", exception.Message);
            }

            return oReplay;
        }
    }
}