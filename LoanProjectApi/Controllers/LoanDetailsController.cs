using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class LoanDetailsController : ApiController
    {
        public IEnumerable<LoanDetail> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.LoanDetails.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.LoanDetails.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message: "Data with Id " + id.ToString() + " Not Found!");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] LoanDetail loandetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.LoanDetails.Add(loandetail);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, loandetail);
                    message.Headers.Location = new Uri(Request.RequestUri + loandetail.ID.ToString());
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
                    var entity = entities.LoanDetails.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.LoanDetails.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] LoanDetail loandetail)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.LoanDetails.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data with Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Personal_Interest_Rate = loandetail.Personal_Interest_Rate;
                        entity.Personal_Loan_Tenure = loandetail.Personal_Loan_Tenure;
                        entity.Personal_Loan_Amount = loandetail.Personal_Loan_Amount;
                        entity.Personal_Processing_Fees = loandetail.Personal_Processing_Fees;
                        entity.Education_Interest_Rate = loandetail.Education_Interest_Rate;
                        entity.Education_Loan_Type = loandetail.Education_Loan_Type;
                        entity.Education_Loan_Amount = loandetail.Education_Loan_Amount;
                        entity.Education_Concession = loandetail.Education_Concession;
                        entity.Home_InterestRate_1 = loandetail.Home_InterestRate_1;
                        entity.Home_InterestRate_2 = loandetail.Home_InterestRate_2;
                        entity.Home_InterestRate_3 = loandetail.Home_InterestRate_3;
                        entity.Home_Processing_Fees = loandetail.Home_Processing_Fees;
                        entity.Gold_Min_Loan = loandetail.Gold_Min_Loan;
                        entity.Gold_Max_Loan = loandetail.Gold_Max_Loan;
                        entity.Gold_Margin = loandetail.Gold_Margin;
                        entity.Gold_Processing_Fees = loandetail.Gold_Processing_Fees;
                        entity.Clients = loandetail.Clients;
                        entity.Loan_Approved = loandetail.Loan_Approved;
                        entity.Hours_Support = loandetail.Hours_Support;
                        entity.Hard_Workers = loandetail.Hard_Workers;
                        entity.Trusty_City = loandetail.Trusty_City;
                        entity.Trusty_State = loandetail.Trusty_State;
                        entity.Trusty_Country = loandetail.Trusty_Country;
                        entity.Trusty_Mail = loandetail.Trusty_Mail;
                        entity.Trusty_Phone = loandetail.Trusty_Phone;

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
