namespace Exercise0001.Controllers
{
    using Exercise0001.Models;
    using Exercise0001.Models.WS;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class AnimalController : BaseController
    {
        [HttpPost]
        public Reply Get([FromBody]SecurityViewModel model)
        {
            Reply oReply = new Reply();
            oReply.result = 0;

            if (!Verify(model.token))
            {
                oReply.message = "Not authorized";
                return oReply;
            }

            try
            {
                using (var dbContext = new Example002Entities())
                {
                    oReply.data = (from a in dbContext.Animals
                                   join s in dbContext.States on a.IdState equals s.Id
                                   select new ListAnimalsViewModel
                                   {
                                       Name = a.Name,
                                       Foots = a.Foots
                                   }).ToList();

                    oReply.result = 1;
                }
            }
            catch (Exception exception)
            {
                oReply.message = string.Format("There was an error. {0}", exception.Message);
            }

            return oReply;
        }
    }
}