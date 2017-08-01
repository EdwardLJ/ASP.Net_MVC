using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Models;
using MvcApplication4.Data_Access_Layer;
using MvcApplication4.ViewModels;
using MvcAppliaction4;

namespace MvcApplication4
{
    public class EmployeeBusinessLayer
    {
       

        //显示数据库内容
        public List<Employee> GetEmployee()
        {
              SalesERPDAL salesDal = new SalesERPDAL();
              return salesDal.Employees.ToList();
        }

        //插入表格
        public Employee SaveEmployee(Employee e) 
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        //验证登录
        //public bool IsIsValidUser(UserDetails u) {
        //    if (u.UserName == "admin" && u.Password == "123")
        //    {
        //        return true;
        //    }
        //    else {
        //        return false;
        //    }
        //}
        public UserStatus GetUserValidity(UserDetails u) { 
            if(u.UserName=="admin"&&u.Password=="123"){
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "lj" && u.Password == "123")
            {
                return UserStatus.AuthentucatedUser;
            }
            else {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        //文件上传
        public void UploadEmployees(List<Employee> employees) {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.AddRange(employees);
            salesDal.SaveChanges();
        }


    }
}