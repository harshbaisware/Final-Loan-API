using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class GstinController : ApiController
    {
        public IEnumerable<Gstin> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Gstins.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.Gstins.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] Gstin gstin)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.Gstins.Add(gstin);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, gstin);
                    message.Headers.Location = new Uri(Request.RequestUri + gstin.ID.ToString());
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
                    var entity = entities.Gstins.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.Gstins.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] Gstin gstin)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.Gstins.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Gst_Reg = gstin.Gst_Reg;
                        entity.Gst_Exem = gstin.Gst_Exem;
                        entity.Gst_Exem_Reason = gstin.Gst_Exem_Reason;
                        entity.Gst_Exem_date = gstin.Gst_Exem_date;
                        entity.Gst_Reg_Date = gstin.Gst_Reg_Date;
                        entity.Gst_Reg_Type = gstin.Gst_Reg_Type;
                        entity.Gst_Eco_Zone = gstin.Gst_Eco_Zone;
                        entity.Gst_default = gstin.Gst_default;
                        entity.Gstin_Addr = gstin.Gstin_Addr;
                        entity.Gst_Pin = gstin.Gst_Pin;
                        entity.Gst_City = gstin.Gst_City;
                        entity.Gst_State = gstin.Gst_State;
                        entity.Gst_Country = gstin.Gst_Country;

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
