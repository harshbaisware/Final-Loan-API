using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class PersonalController : ApiController
    {
        public IEnumerable<Personal> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Personals.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.Personals.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] Personal personal)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.Personals.Add(personal);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, personal);
                    message.Headers.Location = new Uri(Request.RequestUri + personal.ID.ToString());
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
                    var entity = entities.Personals.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.Personals.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] Personal personal)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.Personals.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.App_Name = personal.App_Name;
                        entity.App_Fath_Spou_Name = personal.App_Fath_Spou_Name;
                        entity.App_Mother_Name = personal.App_Mother_Name;
                        entity.App_Status = personal.App_Status;
                        entity.App_Pan = personal.App_Pan;
                        entity.App_Doc_Type = personal.App_Doc_Type;
                        entity.App_Doc_No = personal.App_Doc_No;
                        entity.App_Doc_Exp = personal.App_Doc_Exp;
                        entity.App_Ckyc_No = personal.App_Ckyc_No;
                        entity.App_Dob = personal.App_Dob;
                        entity.App_Gender = personal.App_Gender;
                        entity.App_Nationality = personal.App_Nationality;
                        entity.App_Religion = personal.App_Religion;
                        entity.App_Category = personal.App_Category;
                        entity.App_Disability = personal.App_Disability;
                        entity.App_Education = personal.App_Education;
                        entity.App_Marital_Status = personal.App_Marital_Status;
                        entity.App_Dependants_No = personal.App_Dependants_No;
                        entity.App_Email = personal.App_Email;
                        entity.App_Off_Email = personal.App_Off_Email;
                        entity.App_Telephone = personal.App_Telephone;
                        entity.App_Mobile = personal.App_Mobile;
                        entity.App_Pre_Addr = personal.App_Pre_Addr;
                        entity.App_Pre_Landmark = personal.App_Pre_Landmark;
                        entity.App_Pre_Pin = personal.App_Pre_Pin;
                        entity.App_Pre_City = personal.App_Pre_City;
                        entity.App_Pre_State = personal.App_Pre_State;
                        entity.App_Per_Addr = personal.App_Per_Addr;
                        entity.App_Per_Landmark = personal.App_Per_Landmark;
                        entity.App_Per_Pin = personal.App_Per_Pin;
                        entity.App_Per_City = personal.App_Per_City;
                        entity.App_Per_State = personal.App_Per_State;

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
