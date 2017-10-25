using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL dal;
        public HomeController(IParkDAL dal)
        {
            this.dal = dal;
        }
        

        // GET: Home
        public ActionResult Index()
        {
            List<Park> model = dal.GetAllParks();
            return View("Index", model);
        }
    }
}