using RepositoryUsingEFinMVC.DAL;
using RepositoryUsingEFinMVC.GenericRepository;
using RepositoryUsingEFinMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryUsingEFinMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IGenericRepository<Employee> repository = null;

        public EmployeeController()
        {
            this.repository = new GenericRepository<Employee>();
        }
        public EmployeeController(IGenericRepository<Employee> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        // GET: Employee
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEmployee(int EmployeeID)
        {
            Employee model = repository.GetById(EmployeeID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int EmployeeID)
        {
            Employee model = repository.GetById(EmployeeID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int EmployeeID)
        {
            repository.Delete(EmployeeID);
            repository.Save();
            return RedirectToAction("Index", "Employee");
        }
    }

}