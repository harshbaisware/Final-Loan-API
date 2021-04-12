using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class GoldAppDocController : ApiController
    {
        public IEnumerable<GoldAppDoc> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.GoldAppDocs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.GoldAppDocs.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] GoldAppDoc goldappdoc)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.GoldAppDocs.Add(goldappdoc);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, goldappdoc);
                    message.Headers.Location = new Uri(Request.RequestUri + goldappdoc.ID.ToString());
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
                    var entity = entities.GoldAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.GoldAppDocs.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] GoldAppDoc goldappdoc)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.GoldAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Doc1_Name = goldappdoc.Doc1_Name;
                        entity.Doc1 = goldappdoc.Doc1;
                        entity.Doc2_Name = goldappdoc.Doc2_Name;
                        entity.Doc2 = goldappdoc.Doc2;
                        entity.Doc3_Name = goldappdoc.Doc3_Name;
                        entity.Doc3 = goldappdoc.Doc3;
                        entity.Doc4_Name = goldappdoc.Doc4_Name;
                        entity.Doc4 = goldappdoc.Doc4;
                        entity.Doc5_Name = goldappdoc.Doc5_Name;
                        entity.Doc5 = goldappdoc.Doc5;
                        entity.Doc6_Name = goldappdoc.Doc6_Name;
                        entity.Doc6 = goldappdoc.Doc6;
                        entity.Doc7_Name = goldappdoc.Doc7_Name;
                        entity.Doc7 = goldappdoc.Doc7;
                        entity.Doc8_Name = goldappdoc.Doc8_Name;
                        entity.Doc8 = goldappdoc.Doc8;
                        entity.Doc9_Name = goldappdoc.Doc9_Name;
                        entity.Doc9 = goldappdoc.Doc9;
                        entity.Doc10_Name = goldappdoc.Doc10_Name;
                        entity.Doc10 = goldappdoc.Doc10;
                        entity.Doc11_Name = goldappdoc.Doc11_Name;
                        entity.Doc11 = goldappdoc.Doc11;
                        entity.Doc12_Name = goldappdoc.Doc12_Name;
                        entity.Doc12 = goldappdoc.Doc12;
                        entity.Doc13_Name = goldappdoc.Doc13_Name;
                        entity.Doc13 = goldappdoc.Doc13;
                        entity.Doc14_Name = goldappdoc.Doc14_Name;
                        entity.Doc14 = goldappdoc.Doc14;
                        entity.Doc15_Name = goldappdoc.Doc15_Name;
                        entity.Doc15 = goldappdoc.Doc15;
                        entity.Doc16_Name = goldappdoc.Doc16_Name;
                        entity.Doc16 = goldappdoc.Doc16;
                        entity.Doc17_Name = goldappdoc.Doc17_Name;
                        entity.Doc17 = goldappdoc.Doc17;
                        entity.Doc18_Name = goldappdoc.Doc18_Name;
                        entity.Doc18 = goldappdoc.Doc18;
                        entity.Doc19_Name = goldappdoc.Doc19_Name;
                        entity.Doc19 = goldappdoc.Doc19;
                        entity.Doc20_Name = goldappdoc.Doc20_Name;
                        entity.Doc20 = goldappdoc.Doc20;

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
