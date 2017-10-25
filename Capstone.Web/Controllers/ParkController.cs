using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        private IParkDAL dal;
        public ParkController(IParkDAL dal)
        {
            this.dal = dal;
        }

        // GET: Park
        public ActionResult Detail(string id)
        {
            Park p = dal.GetPark(id);
            List<Weather> w = dal.GetWeather(id);
            PW pw = new PW(p, w);
            return View("Detail", pw);
        }

    }
}