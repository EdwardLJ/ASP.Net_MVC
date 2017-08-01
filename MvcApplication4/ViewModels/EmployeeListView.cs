using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.ViewModels
{
    public class EmployeeListView:BaseViewModel
    {
        public List<EmployeeModel2> Employees { get; set; }
        
    }
}