using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;
using System.IO;

namespace Employee_Details.Controllers
{
    public class EmployeeController : Controller
    {
        

        // GET: EmployeeModels
        public ActionResult EmployeeIndex()
        {
            EmployeeModel empmodel = new EmployeeModel();
            return View("Add_Edit",empmodel);
        }

        // GET: EmployeeModels/Details/5

        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeModels/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Edit([Bind(Include = "FirstName,LastName,Gender,DOB,Address,Photo")] EmployeeModel employeeModel, string submit)
        {
            EmployeeDBHandle db = new EmployeeDBHandle();
            int i = db.AddEmployee(employeeModel);
            if (i > 0)
            {
                ViewBag.Message = "Employee Saved Sucessfully";
            }
            return View("EmpViewIndex");
        }
        
        // GET: EmployeeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View();
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }
    }
}
