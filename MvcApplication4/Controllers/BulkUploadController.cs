using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Filter;
using MvcApplication4.ViewModels;
using MvcApplication4.Models;
using System.IO;

namespace MvcApplication4.Controllers
{
    public class BulkUploadController : Controller
    {
        //
        // GET: /BulkUploadController/
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        public ActionResult Upload(FileUploadViewModel model) { 
            List<Employee> employees = GetEmployees(model);
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model) { 
             List<Employee> employees = new List<Employee>();
             StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
             csvreader.ReadLine(); // Assuming first line is header
             while (!csvreader.EndOfStream)
             {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
               }
               return employees;
        }

    }
}
