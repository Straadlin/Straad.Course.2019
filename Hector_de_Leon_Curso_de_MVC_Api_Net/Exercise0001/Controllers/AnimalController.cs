namespace Exercise0001.Controllers
{
    using Exercise0001.Models;
    using Exercise0001.Models.WS;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
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
                                   where s.Name.Equals("Active")
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

        [HttpPost]
        public Reply Add([FromBody]AnimalViewModel model)
        {
            var oReply = new Reply();
            oReply.result = 0;

            if (!Verify(model.token))
            {
                oReply.message = "Not authorized";
                return oReply;
            }

            if (!Validate(model))
            {
                oReply.message = error;
                return oReply;
            }

            try
            {
                using (var dbContext = new Example002Entities())
                {
                    var oAnimal = new Animal();
                    oAnimal.IdState = 1;
                    oAnimal.Name = model.Name;
                    oAnimal.Foots = model.Foots;

                    dbContext.Animals.Add(oAnimal);
                    dbContext.SaveChanges();

                    oReply.result = 1;

                    oReply.data = (from a in dbContext.Animals
                                   join s in dbContext.States on a.IdState equals s.Id
                                   where s.Name.Equals("Active")
                                   select new ListAnimalsViewModel
                                   {
                                       Name = a.Name,
                                       Foots = a.Foots
                                   }).ToList();
                }
            }
            catch (Exception exception)
            {
                oReply.message = string.Format("There was an error. {0}", exception);
            }

            return oReply;
        }

        [HttpPost]
        public Reply Edit([FromBody]AnimalViewModel model)
        {
            var oReply = new Reply();
            oReply.result = 0;

            if (!Verify(model.token))
            {
                oReply.message = "Not authorized";
                return oReply;
            }

            if (!Validate(model))
            {
                oReply.message = error;
                return oReply;
            }

            try
            {
                using (var dbContext = new Example002Entities())
                {
                    var oAnimal = dbContext.Animals.Find(model.Id);

                    oAnimal.Name = model.Name;
                    oAnimal.Foots = model.Foots;

                    dbContext.Entry(oAnimal).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();

                    oReply.result = 1;

                    oReply.data = (from a in dbContext.Animals
                                   join s in dbContext.States on a.IdState equals s.Id
                                   where s.Name.Equals("Active")
                                   select new ListAnimalsViewModel
                                   {
                                       Name = a.Name,
                                       Foots = a.Foots
                                   }).ToList();
                }
            }
            catch (Exception exception)
            {
                oReply.message = string.Format("There was an error. {0}", exception);
            }

            return oReply;
        }

        [HttpDelete]
        public Reply Delete([FromBody]AnimalViewModel model)
        {
            var oReply = new Reply();
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
                    var oAnimal = dbContext.Animals.Find(model.Id);
                    oAnimal.IdState = 2;

                    dbContext.Entry(oAnimal).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();

                    oReply.result = 1;

                    oReply.data = (from a in dbContext.Animals
                                   join s in dbContext.States on a.IdState equals s.Id
                                   where s.Name.Equals("Active")
                                   select new ListAnimalsViewModel
                                   {
                                       Name = a.Name,
                                       Foots = a.Foots
                                   }).ToList();
                }
            }
            catch (Exception exception)
            {
                oReply.message = string.Format("There was an error. {0}", exception);
            }

            return oReply;
        }

        [HttpPost]
        public async Task<Reply> Photo([FromUri]AnimalPictureViewModel model)
        {
            var oReply = new Reply();
            oReply.result = 0;

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            if (!Verify(model.token))
            {
                oReply.message = "Not authorized";
                return oReply;
            }

            if(!Request.Content.IsMimeMultipartContent())
            {
                oReply.message = "Doesn't contain image";
                return oReply;
            }

            await Request.Content.ReadAsMultipartAsync(provider);

            FileInfo oFileInfoPicture = null;

            foreach (var item in provider.FileData)
            {
                // Didn't work with this 'if' line.
                if (item.Headers.ContentDisposition.Name.Replace("\\","").Replace("\"","").Equals("picture"))
                    oFileInfoPicture = new FileInfo(item.LocalFileName);
            }

            if(oFileInfoPicture!=null)
            {
                using (FileStream oFileStream = oFileInfoPicture.Open(FileMode.Open, FileAccess.Read))
                {
                    byte[] b = new byte[oFileInfoPicture.Length];
                    var temp = new UTF8Encoding(true);

                    while (oFileStream.Read(b, 0, b.Length) > 0) ;

                    try
                    {
                        using (var dbContext = new Example002Entities())
                        {
                            var oAnimal = dbContext.Animals.Find(model.Id);
                            oAnimal.picture = b;
                            dbContext.Entry(oAnimal).State = System.Data.Entity.EntityState.Modified;
                            dbContext.SaveChanges();
                            oReply.result = 1;
                        }
                    }
                    catch(Exception exception)
                    {
                        oReply.message = string.Format("Try again later. {0}", exception);
                    }
                }
            }

            return oReply;
        }

        #region Helpers

        private bool Validate(AnimalViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                error = "Name is neccesary.";
                return false;
            }

            return true;
        }

        #endregion Helpers
    }
}