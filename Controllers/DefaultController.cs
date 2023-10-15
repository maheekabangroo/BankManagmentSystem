//using BankManagementSystem;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Linq;
//using System.Web.Http;
//using Test.Context;

//namespace Test.Controllers
//{
//    public class DefaultController : ApiController
//    {
//        //Creating Instance of DatabaseContext class
//        private DatabaseContext db = new DatabaseContext();

//        //Creating a method to return Json data
//        [HttpGet]
//        public IHttpActionResult Get()
//        {
//            try
//            {
//                //Prepare data to be returned using Linq as follows
//                var result = from Login in db.Login
//                             select new
//                             {
//                                 Login.LoginId,
//                                 Login.Username,
//                                 State = from state in db.States
//                                         where state.CountryId == country.CountryId
//                                         select new
//                                         {
//                                             state.StateId,
//                                             state.Name,
//                                             City = from city in db.Cities
//                                                    where city.StateId == state.StateId
//                                                    select new
//                                                    {
//                                                        city.CityId,
//                                                        city.Name
//                                                    }
//                                         }
//                             };
//                return Ok(result);
//            }
//            catch (Exception)
//            {
//                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned
//                return InternalServerError();
//            }
//        }
//    }
//}