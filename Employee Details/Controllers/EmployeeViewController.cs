using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;
using PagedList.Mvc;
using PagedList;
namespace Employee_Details.Controllers
{
    public class EmployeeViewController : Controller
    {
        // GET: EmployeeView
        public ActionResult EmpViewIndex(int? i)
        {
            EmployeeDBHandle emp = new EmployeeDBHandle();
            var dt = emp.GetEmployeeDetails().ToPagedList(i??1,4); 
            return View(dt);
        }
    }
}