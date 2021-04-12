using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class AdminLoginController : ApiController
    {
        public IEnumerable<Adminlogin> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Adminlogins.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.Adminlogins.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message: "Login with Id " + id.ToString() + " Not Found!");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Adminlogin adminlogin)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.Adminlogins.Add(adminlogin);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, adminlogin);
                    message.Headers.Location = new Uri(Request.RequestUri + adminlogin.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.Adminlogins.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.Adminlogins.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Put(int id, [FromBody] Adminlogin adminlogin)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.Adminlogins.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Name = adminlogin.Name;
                        entity.Email = adminlogin.Email;
                        entity.Password = adminlogin.Password;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
