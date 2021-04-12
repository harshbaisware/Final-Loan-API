using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class HomeDetailsController : ApiController
    {
        public IEnumerable<HomeDetail> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.HomeDetails.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.HomeDetails.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] HomeDetail homedetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.HomeDetails.Add(homedetail);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, homedetail);
                    message.Headers.Location = new Uri(Request.RequestUri + homedetail.ID.ToString());
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
                    var entity = entities.HomeDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.HomeDetails.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] HomeDetail homedetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.HomeDetails.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Prop_Type = homedetail.Prop_Type;
                        entity.Prop_Trans_Type = homedetail.Prop_Trans_Type;
                        entity.Prop_Builder_Name = homedetail.Prop_Builder_Name;
                        entity.Prop_Project_Name = homedetail.Prop_Project_Name;
                        entity.Prop_Building_Name = homedetail.Prop_Building_Name;
                        entity.Prop_Land_Area = homedetail.Prop_Land_Area;
                        entity.Prop_Cost = homedetail.Prop_Cost;
                        entity.Prop_Addr = homedetail.Prop_Addr;
                        entity.Prop_Landmark = homedetail.Prop_Landmark;
                        entity.Prop_Pin = homedetail.Prop_Pin;
                        entity.Prop_City = homedetail.Prop_City;
                        entity.Prop_State = homedetail.Prop_State;
                        entity.Prop_Country = homedetail.Prop_Country;
                        entity.Prop_Ownership = homedetail.Prop_Ownership;
                        entity.Prop_Seller_Name = homedetail.Prop_Seller_Name;
                        entity.Prop_Seller_Addr = homedetail.Prop_Seller_Addr;
                        entity.Prop_Const_Stage = homedetail.Prop_Const_Stage;
                        entity.Prop_Pur_Con_Cost = homedetail.Prop_Pur_Con_Cost;
                        entity.Prop_Reg_Cost = homedetail.Prop_Reg_Cost;
                        entity.Prop_Total_Cost = homedetail.Prop_Total_Cost;
                        entity.Prop_Stamp_Cost = homedetail.Prop_Stamp_Cost;
                        entity.Prop_Other_Cost = homedetail.Prop_Other_Cost;
                        entity.Prop_Own_Contrib = homedetail.Prop_Own_Contrib;

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
