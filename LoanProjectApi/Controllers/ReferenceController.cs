using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class ReferenceController : ApiController
    {
        public IEnumerable<Reference> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.References.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.References.FirstOrDefault(e => e.P_ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message: "Person with P_Id " + id.ToString() + " Not Found!");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Reference reference)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.References.Add(reference);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, reference);
                    message.Headers.Location = new Uri(Request.RequestUri + reference.ID.ToString());
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
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.References.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.References.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] Reference reference)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.References.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Ref_Name1 = reference.Ref_Name1;
                        entity.Ref_Relat1 = reference.Ref_Relat1;
                        entity.Ref_Addr1 = reference.Ref_Addr1;
                        entity.Ref_Pin1 = reference.Ref_Pin1;
                        entity.Ref_City1 = reference.Ref_City1;
                        entity.Ref_State1 = reference.Ref_State1;
                        entity.Ref_Country1 = reference.Ref_Country1;
                        entity.Ref_Mob_Tel1 = reference.Ref_Mob_Tel1;
                        entity.Ref_Email1 = reference.Ref_Email1;
                        entity.Ref_Name2 = reference.Ref_Name2;
                        entity.Ref_Relat2 = reference.Ref_Relat2;
                        entity.Ref_Addr2 = reference.Ref_Addr2;
                        entity.Ref_Pin2 = reference.Ref_Pin2;
                        entity.Ref_City2 = reference.Ref_City2;
                        entity.Ref_State2 = reference.Ref_State2;
                        entity.Ref_Country2 = reference.Ref_Country2;
                        entity.Ref_Mob_Tel2 = reference.Ref_Mob_Tel2;
                        entity.Ref_Email2 = reference.Ref_Email2;


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
