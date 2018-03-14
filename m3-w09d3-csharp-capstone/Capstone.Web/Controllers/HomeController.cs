using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ParkSqlDAL sql = new ParkSqlDAL();
            List<ParkModel> newList = sql.NationalParksList();
            return View(newList);
        }

        public ActionResult Detail()
        {
            return View("Detail");
        }
    }
}