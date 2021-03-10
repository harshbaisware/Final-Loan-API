using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class FinancialController : ApiController
    {
        public IEnumerable<Financial> Get()
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Financials.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (loandbEntities entities = new loandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.Financials.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] Financial financial)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.Financials.Add(financial);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, financial);
                    message.Headers.Location = new Uri(Request.RequestUri + financial.ID.ToString());
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
                    var entity = entities.Financials.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.Financials.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] Financial financial)
        {
            try
            {
                using (loandbEntities entities = new loandbEntities())
                {
                    var entity = entities.Financials.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.Fin_Status = financial.Fin_Status;
                        entity.Fin_Inc_Gross = financial.Fin_Inc_Gross;
                        entity.Fin_Inc_Net = financial.Fin_Inc_Net;
                        entity.Fin_Inc_Othr = financial.Fin_Inc_Othr;
                        entity.Fin_Inc_Total = financial.Fin_Inc_Total;
                        entity.Fin_Bank1_Name = financial.Fin_Bank1_Name;
                        entity.Fin_Bank1_Branch = financial.Fin_Bank1_Branch;
                        entity.Fin_Bank1_Ac_Type = financial.Fin_Bank1_Ac_Type;
                        entity.Fin_Bank1_Ac_No = financial.Fin_Bank1_Ac_No;
                        entity.Fin_Bank2_Name = financial.Fin_Bank2_Name;
                        entity.Fin_Bank2_Branch = financial.Fin_Bank2_Branch;
                        entity.Fin_Bank2_Ac_Type = financial.Fin_Bank2_Ac_Type;
                        entity.Fin_Bank2_Ac_No = financial.Fin_Bank2_Ac_No;
                        entity.Fin_Deposits_Inv = financial.Fin_Deposits_Inv;
                        entity.Fin_Shares_Inv = financial.Fin_Shares_Inv;
                        entity.Fin_Insurance_Inv = financial.Fin_Insurance_Inv;
                        entity.Fin_Mutual_Funds_Inv = financial.Fin_Mutual_Funds_Inv;
                        entity.Fin_Others_Inv = financial.Fin_Others_Inv;
                        entity.Fin_Total_Inv = financial.Fin_Total_Inv;

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
