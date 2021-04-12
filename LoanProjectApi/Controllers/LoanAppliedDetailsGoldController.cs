using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class LoanAppliedDetailsGoldController : ApiController
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
                        entity.Gold_ID = loanapplieddetail.Gold_ID;
                        entity.Gold_Amount = loanapplieddetail.Gold_Amount;
                        entity.Gold_Rate = loanapplieddetail.Gold_Rate;
                        entity.Gold_Tenure = loanapplieddetail.Gold_Tenure;
                        entity.Gold_Emi = loanapplieddetail.Gold_Emi;
                        entity.Gold_Last_Emi = loanapplieddetail.Gold_Last_Emi;
                        entity.Gold_Interest = loanapplieddetail.Gold_Interest;

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
