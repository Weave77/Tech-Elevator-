using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";

        // GET: Home
        public ActionResult Index()
        {
            ParkSqlDAL sql = new ParkSqlDAL(connectionString);
            List<ParkModel> newList = sql.NationalParksList();
            return View(newList);
        }

        public ActionResult Detail(string id)
        {


            if (id == null)
            {
                id = "CVNP";
            }
            ParkSqlDAL ParkSql = new ParkSqlDAL(connectionString);



            var tempValue = Session["tempValue"];
            if (tempValue == null)
            {
                tempValue = 0;
            }
            WeatherSqlDAL sqlweather = new WeatherSqlDAL(connectionString);
            ParkModel park = ParkSql.SelectedParkDecriptiveDetails(id);
            park.WeatherList = sqlweather.SpecificParkWeather(id);

            Session["tempValue"] = tempValue;           
            park.TempValueProperty = (int)tempValue;

            ViewBag.WeatherData = park.WeatherList;

            return View("Detail", park);
        }

        [HttpPost]
        public ActionResult Detail(ParkModel newPark)
        {
            int tempValue = newPark.TempValueProperty;
            Session["tempValue"] = tempValue;

            return View("Detail", newPark);
        }
    }
}