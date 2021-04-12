using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class EmpEduHomeController : ApiController
    {
        public IEnumerable<EmpEduHome> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.EmpEduHomes.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.EmpEduHomes.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] EmpEduHome empeduhome)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.EmpEduHomes.Add(empeduhome);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, empeduhome);
                    message.Headers.Location = new Uri(Request.RequestUri + empeduhome.ID.ToString());
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
                    var entity = entities.EmpEduHomes.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.EmpEduHomes.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] EmpEduHome empeduhome)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.EmpEduHomes.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Org_Res_Own = empeduhome.Org_Res_Own;
                        entity.Org_Employment_Nat = empeduhome.Org_Employment_Nat;
                        entity.Org_Nat = empeduhome.Org_Nat;
                        entity.Org_Emp_Busi_Nat = empeduhome.Org_Emp_Busi_Nat;
                        entity.Org_Designation = empeduhome.Org_Designation;
                        entity.Org_Current_Year = empeduhome.Org_Current_Year;
                        entity.Org_Total_Year = empeduhome.Org_Total_Year;
                        entity.Org_Name = empeduhome.Org_Name;
                        entity.Org_Address = empeduhome.Org_Address;
                        entity.Org_Pin = empeduhome.Org_Pin;
                        entity.Org_City = empeduhome.Org_City;
                        entity.Org_State = empeduhome.Org_State;
                        entity.Org_Country = empeduhome.Org_Country;
                        entity.Org_Phone = empeduhome.Org_Phone;
                        entity.Org_UAN = empeduhome.Org_UAN;

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
