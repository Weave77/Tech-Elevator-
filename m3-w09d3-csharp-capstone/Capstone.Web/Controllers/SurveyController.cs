using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        // GET: Detail
        public ActionResult Survey()
        {
            SurveyModel thisSurvey = new SurveyModel();
            return View();
        }

        [HttpPost]
        public ActionResult Survey(SurveyModel thisSurvey)
        {
            SurveySqlDAL sql = new SurveySqlDAL(connectionString);
            sql.SurveyPost(thisSurvey);
            return RedirectToAction("FavoriteParks");

        }

        public ActionResult FavoriteParks()
        {
            SurveySqlDAL sql = new SurveySqlDAL(connectionString);
            List<SurveyModel> thisList = sql.BestParks();
            return View("FavoriteParks", thisList);
        }
    }
}