using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4;
using MvcApplication4.ViewModels;
using MvcApplication4.Models;
using MvcApplication4.Filter;

namespace MvcApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test2/
        [HeaderFooterFilter]
        [Authorize]
        public ActionResult Index()
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            EmployeeListView empViewlist = new EmployeeListView();
            List<Employee> empList = empBal.GetEmployee();
            List<EmployeeModel2> empViewModels = new List<EmployeeModel2>();


        

            foreach(Employee emp in empList){
                EmployeeModel2 empViewModel = new EmployeeModel2();
                empViewModel.EmpName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "Yellow";
                }
                else {
                    empViewModel.SalaryColor = "Green";
                }
                empViewModels.Add(empViewModel);
            }
      
             empViewlist.Employees = empViewModels;
             return View("Index",empViewlist);
        }

        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult AddNew() 
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
       
            return View("CreateEmployee", employeeListViewModel);
        }

        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;

   


                        if (e.Salary == null)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;          
                        
                        }
                        return View("CreateEmployee",vm);
                    }
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        public ActionResult GetAddNewLink() {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                  return  View("AddNewLink");
            }else{
                 return new EmptyResult();
            }
        }
    }
}
