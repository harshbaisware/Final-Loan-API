using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class HomeAppDocController : ApiController
    {
        public IEnumerable<HomeAppDoc> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.HomeAppDocs.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.HomeAppDocs.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] HomeAppDoc homeappdoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.HomeAppDocs.Add(homeappdoc);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, homeappdoc);
                    message.Headers.Location = new Uri(Request.RequestUri + homeappdoc.ID.ToString());
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
                    var entity = entities.HomeAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.HomeAppDocs.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] HomeAppDoc homeappdoc)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.HomeAppDocs.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Doc1_Name = homeappdoc.Doc1_Name;
                        entity.Doc1 = homeappdoc.Doc1;
                        entity.Doc2_Name = homeappdoc.Doc2_Name;
                        entity.Doc2 = homeappdoc.Doc2;
                        entity.Doc3_Name = homeappdoc.Doc3_Name;
                        entity.Doc3 = homeappdoc.Doc3;
                        entity.Doc4_Name = homeappdoc.Doc4_Name;
                        entity.Doc4 = homeappdoc.Doc4;
                        entity.Doc5_Name = homeappdoc.Doc5_Name;
                        entity.Doc5 = homeappdoc.Doc5;
                        entity.Doc6_Name = homeappdoc.Doc6_Name;
                        entity.Doc6 = homeappdoc.Doc6;
                        entity.Doc7_Name = homeappdoc.Doc7_Name;
                        entity.Doc7 = homeappdoc.Doc7;
                        entity.Doc8_Name = homeappdoc.Doc8_Name;
                        entity.Doc8 = homeappdoc.Doc8;
                        entity.Doc9_Name = homeappdoc.Doc9_Name;
                        entity.Doc9 = homeappdoc.Doc9;
                        entity.Doc10_Name = homeappdoc.Doc10_Name;
                        entity.Doc10 = homeappdoc.Doc10;
                        entity.Doc11_Name = homeappdoc.Doc11_Name;
                        entity.Doc11 = homeappdoc.Doc11;
                        entity.Doc12_Name = homeappdoc.Doc12_Name;
                        entity.Doc12 = homeappdoc.Doc12;
                        entity.Doc13_Name = homeappdoc.Doc13_Name;
                        entity.Doc13 = homeappdoc.Doc13;
                        entity.Doc14_Name = homeappdoc.Doc14_Name;
                        entity.Doc14 = homeappdoc.Doc14;
                        entity.Doc15_Name = homeappdoc.Doc15_Name;
                        entity.Doc15 = homeappdoc.Doc15;
                        entity.Doc16_Name = homeappdoc.Doc16_Name;
                        entity.Doc16 = homeappdoc.Doc16;
                        entity.Doc17_Name = homeappdoc.Doc17_Name;
                        entity.Doc17 = homeappdoc.Doc17;
                        entity.Doc18_Name = homeappdoc.Doc18_Name;
                        entity.Doc18 = homeappdoc.Doc18;
                        entity.Doc19_Name = homeappdoc.Doc19_Name;
                        entity.Doc19 = homeappdoc.Doc19;
                        entity.Doc20_Name = homeappdoc.Doc20_Name;
                        entity.Doc20 = homeappdoc.Doc20;

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
