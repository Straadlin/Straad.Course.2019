namespace Exercise0001.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Exercise0001.Models;

    public class BaseController : ApiController
    {
        public string error = string.Empty;

        public bool Verify(string token)
        {
            using (var dbContext = new Example002Entities())
            {
                var query = (from u in dbContext.Users
                             join s in dbContext.States on u.IdState equals s.Id
                             where u.Token.Equals(token) && s.Name.Equals("Active")
                             select u);

                if (query.Count() == 1)
                    return true;
            }

            return false;
        }
    }
}
