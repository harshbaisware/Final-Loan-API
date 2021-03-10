using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class EduCoDocController : ApiController
    {
        public IEnumerable<EduCoDoc> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.EduCoDocs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.EduCoDocs.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] EduCoDoc educodoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.EduCoDocs.Add(educodoc);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, educodoc);
                    message.Headers.Location = new Uri(Request.RequestUri + educodoc.ID.ToString());
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
                    var entity = entities.EduCoDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.EduCoDocs.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] EduCoDoc educodoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.EduCoDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Doc1_Name = educodoc.Doc1_Name;
                        entity.Doc1 = educodoc.Doc1;
                        entity.Doc2_Name = educodoc.Doc2_Name;
                        entity.Doc2 = educodoc.Doc2;
                        entity.Doc3_Name = educodoc.Doc3_Name;
                        entity.Doc3 = educodoc.Doc3;
                        entity.Doc4_Name = educodoc.Doc4_Name;
                        entity.Doc4 = educodoc.Doc4;
                        entity.Doc5_Name = educodoc.Doc5_Name;
                        entity.Doc5 = educodoc.Doc5;
                        entity.Doc6_Name = educodoc.Doc6_Name;
                        entity.Doc6 = educodoc.Doc6;
                        entity.Doc7_Name = educodoc.Doc7_Name;
                        entity.Doc7 = educodoc.Doc7;
                        entity.Doc8_Name = educodoc.Doc8_Name;
                        entity.Doc8 = educodoc.Doc8;
                        entity.Doc9_Name = educodoc.Doc9_Name;
                        entity.Doc9 = educodoc.Doc9;
                        entity.Doc10_Name = educodoc.Doc10_Name;
                        entity.Doc10 = educodoc.Doc10;
                        entity.Doc11_Name = educodoc.Doc11_Name;
                        entity.Doc11 = educodoc.Doc11;
                        entity.Doc12_Name = educodoc.Doc12_Name;
                        entity.Doc12 = educodoc.Doc12;
                        entity.Doc13_Name = educodoc.Doc13_Name;
                        entity.Doc13 = educodoc.Doc13;
                        entity.Doc14_Name = educodoc.Doc14_Name;
                        entity.Doc14 = educodoc.Doc14;
                        entity.Doc15_Name = educodoc.Doc15_Name;
                        entity.Doc15 = educodoc.Doc15;
                        entity.Doc16_Name = educodoc.Doc16_Name;
                        entity.Doc16 = educodoc.Doc16;
                        entity.Doc17_Name = educodoc.Doc17_Name;
                        entity.Doc17 = educodoc.Doc17;
                        entity.Doc18_Name = educodoc.Doc18_Name;
                        entity.Doc18 = educodoc.Doc18;
                        entity.Doc19_Name = educodoc.Doc19_Name;
                        entity.Doc19 = educodoc.Doc19;
                        entity.Doc20_Name = educodoc.Doc20_Name;
                        entity.Doc20 = educodoc.Doc20;

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
