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
            ParkSqlDAL sql = new ParkSqlDAL(connectionString);
            ParkModel thisPark = new ParkModel();
            thisPark = sql.SelectedParkDecriptiveDetails(id);
            return View("Detail", thisPark);
        }
    }
}