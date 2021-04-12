using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class EduAppDocController : ApiController
    {
        public IEnumerable<EduAppDoc> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.EduAppDocs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.EduAppDocs.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] EduAppDoc eduappdoc)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.EduAppDocs.Add(eduappdoc);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, eduappdoc);
                    message.Headers.Location = new Uri(Request.RequestUri + eduappdoc.ID.ToString());
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
                    var entity = entities.EduAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.EduAppDocs.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] EduAppDoc eduappdoc)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.EduAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Doc1_Name = eduappdoc.Doc1_Name;
                        entity.Doc1 = eduappdoc.Doc1;
                        entity.Doc2_Name = eduappdoc.Doc2_Name;
                        entity.Doc2 = eduappdoc.Doc2;
                        entity.Doc3_Name = eduappdoc.Doc3_Name;
                        entity.Doc3 = eduappdoc.Doc3;
                        entity.Doc4_Name = eduappdoc.Doc4_Name;
                        entity.Doc4 = eduappdoc.Doc4;
                        entity.Doc5_Name = eduappdoc.Doc5_Name;
                        entity.Doc5 = eduappdoc.Doc5;
                        entity.Doc6_Name = eduappdoc.Doc6_Name;
                        entity.Doc6 = eduappdoc.Doc6;
                        entity.Doc7_Name = eduappdoc.Doc7_Name;
                        entity.Doc7 = eduappdoc.Doc7;
                        entity.Doc8_Name = eduappdoc.Doc8_Name;
                        entity.Doc8 = eduappdoc.Doc8;
                        entity.Doc9_Name = eduappdoc.Doc9_Name;
                        entity.Doc9 = eduappdoc.Doc9;
                        entity.Doc10_Name = eduappdoc.Doc10_Name;
                        entity.Doc10 = eduappdoc.Doc10;
                        entity.Doc11_Name = eduappdoc.Doc11_Name;
                        entity.Doc11 = eduappdoc.Doc11;
                        entity.Doc12_Name = eduappdoc.Doc12_Name;
                        entity.Doc12 = eduappdoc.Doc12;
                        entity.Doc13_Name = eduappdoc.Doc13_Name;
                        entity.Doc13 = eduappdoc.Doc13;
                        entity.Doc14_Name = eduappdoc.Doc14_Name;
                        entity.Doc14 = eduappdoc.Doc14;
                        entity.Doc15_Name = eduappdoc.Doc15_Name;
                        entity.Doc15 = eduappdoc.Doc15;
                        entity.Doc16_Name = eduappdoc.Doc16_Name;
                        entity.Doc16 = eduappdoc.Doc16;
                        entity.Doc17_Name = eduappdoc.Doc17_Name;
                        entity.Doc17 = eduappdoc.Doc17;
                        entity.Doc18_Name = eduappdoc.Doc18_Name;
                        entity.Doc18 = eduappdoc.Doc18;
                        entity.Doc19_Name = eduappdoc.Doc19_Name;
                        entity.Doc19 = eduappdoc.Doc19;
                        entity.Doc20_Name = eduappdoc.Doc20_Name;
                        entity.Doc20 = eduappdoc.Doc20;

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
