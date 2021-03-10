using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class LoanEduController : ApiController
    {
        public IEnumerable<LoanEdu> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.LoanEdus.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.LoanEdus.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] LoanEdu loanedu)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.LoanEdus.Add(loanedu);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, loanedu);
                    message.Headers.Location = new Uri(Request.RequestUri + loanedu.ID.ToString());
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
                    var entity = entities.LoanEdus.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.LoanEdus.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] LoanEdu loanedu)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.LoanEdus.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Edu_Tut_Fees = loanedu.Edu_Tut_Fees;
                        entity.Edu_Living_Expen = loanedu.Edu_Living_Expen;
                        entity.Edu_Travel_Expen = loanedu.Edu_Travel_Expen;
                        entity.Edu_Other_Expen = loanedu.Edu_Other_Expen;
                        entity.Edu_Total_Expen = loanedu.Edu_Total_Expen;
                        entity.Edu_Own_Inc = loanedu.Edu_Own_Inc;
                        entity.Edu_Scholar_Inc = loanedu.Edu_Scholar_Inc;
                        entity.Edu_Other_Inc = loanedu.Edu_Other_Inc;
                        entity.Edu_Loan_Required = loanedu.Edu_Loan_Required;
                        entity.Edu_Disburs_Details = loanedu.Edu_Disburs_Details;
                        entity.Edu_Mode = loanedu.Edu_Mode;
                        entity.Edu_Dd_In_Favour_Of = loanedu.Edu_Dd_In_Favour_Of;
                        entity.Edu_Payable_At_For = loanedu.Edu_Payable_At_For;
                        entity.Edu_DD_Amount = loanedu.Edu_DD_Amount;
                        entity.Edu_Tt_Swift_Code = loanedu.Edu_Tt_Swift_Code;
                        entity.Edu_Rtgs_Neft = loanedu.Edu_Rtgs_Neft;
                        entity.Edu_University_Ac = loanedu.Edu_University_Ac;

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
