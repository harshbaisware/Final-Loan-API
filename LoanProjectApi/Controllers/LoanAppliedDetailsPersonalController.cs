using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class LoanAppliedDetailsPersonalController : ApiController
    {
        public IEnumerable<LoanAppliedDetail> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.LoanAppliedDetails.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.LoanAppliedDetails.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] LoanAppliedDetail loanapplieddetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.LoanAppliedDetails.Add(loanapplieddetail);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, loanapplieddetail);
                    message.Headers.Location = new Uri(Request.RequestUri + loanapplieddetail.ID.ToString());
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
                    var entity = entities.LoanAppliedDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.LoanAppliedDetails.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] LoanAppliedDetail loanapplieddetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.LoanAppliedDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Per_ID = loanapplieddetail.Per_ID;
                        entity.Per_Amount = loanapplieddetail.Per_Amount;
                        entity.Per_Rate = loanapplieddetail.Per_Rate;
                        entity.Per_Tenure = loanapplieddetail.Per_Tenure;
                        entity.Per_Emi = loanapplieddetail.Per_Emi;
                        entity.Per_Last_Emi = loanapplieddetail.Per_Last_Emi;
                        entity.Per_Interest = loanapplieddetail.Per_Interest;

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
