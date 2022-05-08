using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        EmployeeEntities _db;
        public EmployeeAPIController()
        {
            _db = new EmployeeEntities();
        }

        //Create Employee
        public string Post(Employee employee)
        {
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return "Employee details saved successfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Get All Employees
        public IEnumerable<Employee> Get()
        {
            return _db.Employees.ToList();
        }

        //Get Employee by Id
        public Employee Get(int Id)
        {
            Employee employee = _db.Employees.Find(Id);
            
            if(employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        //Update Employee
        public string Put(int Id, Employee employee)
        {
            try
            {
                var existingEmployee = _db.Employees.Find(Id);

                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    _db.Entry(existingEmployee).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();

                    return "Employee details updated successfully.";
                }
                else
                {
                    return $"Employee details not avialable with Id : {Id}";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Delete Employee
        public string Delete(int Id)
        {
            try
            {
                Employee employee = _db.Employees.Find(Id);

                if (employee != null)
                {
                    _db.Employees.Remove(employee);
                    _db.SaveChanges();
                    return "Employee details deleted successfully.";
                }
                else
                {
                    return $"Employee details not avialable with Id : {Id}";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
