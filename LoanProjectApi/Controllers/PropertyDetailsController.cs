using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class PropertyDetailsController : ApiController
    {
        public IEnumerable<PropertyDetail> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PropertyDetails.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.PropertyDetails.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] PropertyDetail propertydetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.PropertyDetails.Add(propertydetail);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, propertydetail);
                    message.Headers.Location = new Uri(Request.RequestUri + propertydetail.ID.ToString());
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
                    var entity = entities.PropertyDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.PropertyDetails.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] PropertyDetail propertydetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.PropertyDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Ag_Prop_Type = propertydetail.Ag_Prop_Type;
                        entity.Ag_Prop_Classif = propertydetail.Ag_Prop_Classif;
                        entity.Ag_Building_Age = propertydetail.Ag_Building_Age;
                        entity.Ag_Market_Value = propertydetail.Ag_Market_Value;
                        entity.Ag_Regis_Value = propertydetail.Ag_Regis_Value;
                        entity.Ag_Prop_Land_Area = propertydetail.Ag_Prop_Land_Area;
                        entity.Ag_Buildup_Area = propertydetail.Ag_Buildup_Area;
                        entity.Ag_Prop_Addr = propertydetail.Ag_Prop_Addr;
                        entity.Ag_Landmark = propertydetail.Ag_Landmark;
                        entity.Ag_Pin = propertydetail.Ag_Pin;
                        entity.Ag_City = propertydetail.Ag_City;
                        entity.Ag_State = propertydetail.Ag_State;
                        entity.Ag_Country = propertydetail.Ag_Country;
                        entity.Ag_Rev_Mortage = propertydetail.Ag_Rev_Mortage;
                        entity.Ag_Lumpsum_Amount = propertydetail.Ag_Lumpsum_Amount;
                        entity.Ag_Annuity_Periodicity = propertydetail.Ag_Annuity_Periodicity;

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
