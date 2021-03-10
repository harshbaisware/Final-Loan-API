using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class PersonalAppDocController : ApiController
    {
        public IEnumerable<PersonalAppDoc> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PersonalAppDocs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.PersonalAppDocs.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] PersonalAppDoc personalappdoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.PersonalAppDocs.Add(personalappdoc);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, personalappdoc);
                    message.Headers.Location = new Uri(Request.RequestUri + personalappdoc.ID.ToString());
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
                    var entity = entities.PersonalAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.PersonalAppDocs.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] PersonalAppDoc personalappdoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.PersonalAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Doc1_Name = personalappdoc.Doc1_Name;
                        entity.Doc1 = personalappdoc.Doc1;
                        entity.Doc2_Name = personalappdoc.Doc2_Name;
                        entity.Doc2 = personalappdoc.Doc2;
                        entity.Doc3_Name = personalappdoc.Doc3_Name;
                        entity.Doc3 = personalappdoc.Doc3;
                        entity.Doc4_Name = personalappdoc.Doc4_Name;
                        entity.Doc4 = personalappdoc.Doc4;
                        entity.Doc5_Name = personalappdoc.Doc5_Name;
                        entity.Doc5 = personalappdoc.Doc5;
                        entity.Doc6_Name = personalappdoc.Doc6_Name;
                        entity.Doc6 = personalappdoc.Doc6;
                        entity.Doc7_Name = personalappdoc.Doc7_Name;
                        entity.Doc7 = personalappdoc.Doc7;
                        entity.Doc8_Name = personalappdoc.Doc8_Name;
                        entity.Doc8 = personalappdoc.Doc8;
                        entity.Doc9_Name = personalappdoc.Doc9_Name;
                        entity.Doc9 = personalappdoc.Doc9;
                        entity.Doc10_Name = personalappdoc.Doc10_Name;
                        entity.Doc10 = personalappdoc.Doc10;
                        entity.Doc11_Name = personalappdoc.Doc11_Name;
                        entity.Doc11 = personalappdoc.Doc11;
                        entity.Doc12_Name = personalappdoc.Doc12_Name;
                        entity.Doc12 = personalappdoc.Doc12;
                        entity.Doc13_Name = personalappdoc.Doc13_Name;
                        entity.Doc13 = personalappdoc.Doc13;
                        entity.Doc14_Name = personalappdoc.Doc14_Name;
                        entity.Doc14 = personalappdoc.Doc14;
                        entity.Doc15_Name = personalappdoc.Doc15_Name;
                        entity.Doc15 = personalappdoc.Doc15;
                        entity.Doc16_Name = personalappdoc.Doc16_Name;
                        entity.Doc16 = personalappdoc.Doc16;
                        entity.Doc17_Name = personalappdoc.Doc17_Name;
                        entity.Doc17 = personalappdoc.Doc17;
                        entity.Doc18_Name = personalappdoc.Doc18_Name;
                        entity.Doc18 = personalappdoc.Doc18;
                        entity.Doc19_Name = personalappdoc.Doc19_Name;
                        entity.Doc19 = personalappdoc.Doc19;
                        entity.Doc20_Name = personalappdoc.Doc20_Name;
                        entity.Doc20 = personalappdoc.Doc20;

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
