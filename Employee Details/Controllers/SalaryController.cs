using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Details.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult SalaryIndex()
        {
            return View();
        }
    }
}