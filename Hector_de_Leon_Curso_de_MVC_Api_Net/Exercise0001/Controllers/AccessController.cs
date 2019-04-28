using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exercise0001.Models.WS;

namespace Exercise0001.Controllers
{
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
    }
}