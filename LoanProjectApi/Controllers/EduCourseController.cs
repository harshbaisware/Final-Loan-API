using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanDataAccess;

namespace LoanProjectApi.Controllers
{
    public class EduCourseController : ApiController
    {
        public IEnumerable<EduCourse> Get()
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.EduCourses.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (TrustyloandbEntities entities = new TrustyloandbEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.EduCourses.FirstOrDefault(e => e.P_ID == id);
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

        public HttpResponseMessage Post([FromBody] EduCourse educourse)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.EduCourses.Add(educourse);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, educourse);
                    message.Headers.Location = new Uri(Request.RequestUri + educourse.ID.ToString());
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
                    var entity = entities.EduCourses.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entities.EduCourses.Remove(entity);
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


        public HttpResponseMessage Put(int id, [FromBody] EduCourse educourse)
        {
            try
            {
                using (TrustyloandbEntities entities = new TrustyloandbEntities())
                {
                    var entity = entities.EduCourses.FirstOrDefault(e => e.P_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with P_Id " + id.ToString() + " Not Found!");
                    }
                    else
                    {
                        entity.St_Ssc_Inst = educourse.St_Ssc_Inst;
                        entity.St_Ssc_Year = educourse.St_Ssc_Year;
                        entity.St_Ssc_Per = educourse.St_Ssc_Per;
                        entity.St_Ssc_Class = educourse.St_Ssc_Class;
                        entity.St_Ssc_Money_Won = educourse.St_Ssc_Money_Won;
                        entity.St_Hsc_Inst = educourse.St_Hsc_Inst;
                        entity.St_Hsc_Year = educourse.St_Hsc_Year;
                        entity.St_Hsc_Per = educourse.St_Hsc_Per;
                        entity.St_Hsc_Class = educourse.St_Hsc_Class;
                        entity.St_Hsc_Money_Won = educourse.St_Hsc_Money_Won;
                        entity.St_LD_Inst = educourse.St_LD_Inst;
                        entity.St_LD_Year = educourse.St_LD_Year;
                        entity.St_LD_Per = educourse.St_LD_Per;
                        entity.St_LD_Class = educourse.St_LD_Class;
                        entity.St_LD_Money_Won = educourse.St_LD_Money_Won;
                        entity.St_Exam_Score = educourse.St_Exam_Score;
                        entity.St_College_Details = educourse.St_College_Details;
                        entity.St_City = educourse.St_City;
                        entity.St_State = educourse.St_State;
                        entity.St_District = educourse.St_District;
                        entity.St_Pin_Code = educourse.St_Pin_Code;
                        entity.St_Country = educourse.St_Country;
                        entity.St_Admission_Status = educourse.St_Admission_Status;
                        entity.St_Univ_Name = educourse.St_Univ_Name;
                        entity.St_Univ_Person = educourse.St_Univ_Person;
                        entity.St_Course_Name = educourse.St_Course_Name;
                        entity.St_Course_Appr = educourse.St_Course_Appr;
                        entity.St_Admsn = educourse.St_Admsn;
                        entity.St_Course_Cat = educourse.St_Course_Cat;
                        entity.St_Course_Type = educourse.St_Course_Type;
                        entity.St_Course_Start = educourse.St_Course_Start;
                        entity.St_Course_End = educourse.St_Course_End;
                        entity.St_Morat1 = educourse.St_Morat1;
                        entity.St_Morat2 = educourse.St_Morat2;
                        entity.St_Total_Morat = educourse.St_Total_Morat;
                        entity.St_Emi_Repay = educourse.St_Emi_Repay;
                        entity.St_Loan_Period = educourse.St_Loan_Period;
                        entity.St_Int_Serv = educourse.St_Int_Serv;
                        entity.St_Exp_Income = educourse.St_Exp_Income;
                        entity.St_Clg_Name = educourse.St_Clg_Name;
                        entity.St_Course_Persuid = educourse.St_Course_Persuid;
                        entity.St_Compl_Date = educourse.St_Compl_Date;

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
