using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParkDAL dal;
        public SurveyController(IParkDAL dal)
        {
            this.dal = dal;
        }
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TakeSurvey()
        {
            Park model = new Park();
            return View("TakeSurvey", model);
        }
        [HttpPost]
        public ActionResult TakeSurvey(Park completedSurvey)
        {
            dal.SaveSurvey(completedSurvey);
            return RedirectToAction("SurveyResult");
        }
        public ActionResult SurveyResult(List<Park> model)
        {
            List<Park> model2 = dal.GetSurveyResults();
            return View("SurveyResult", model2);
        }
    }
}