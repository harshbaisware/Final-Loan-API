using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        public IEnumerable<ForgotPassword> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.ForgotPasswords.ToList();
            }
        }

        public HttpResponseMessage Get(string Uid)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.ForgotPasswords.FirstOrDefault(e => e.U_ID == Uid);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message: "Login with Id " + Uid.ToString() + " Not Found!");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] ForgotPassword forgotpassword)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.ForgotPasswords.Add(forgotpassword);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, forgotpassword);
                    message.Headers.Location = new Uri(Request.RequestUri + forgotpassword.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(string Uid)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.ForgotPasswords.FirstOrDefault(e => e.U_ID == Uid);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + Uid.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.ForgotPasswords.Remove(entity);
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


        public HttpResponseMessage Put(string id, [FromBody] ForgotPassword forgotpassword)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.ForgotPasswords.FirstOrDefault(e => e.U_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.U_ID = forgotpassword.U_ID;
                        entity.RequestDateTime = forgotpassword.RequestDateTime;

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
