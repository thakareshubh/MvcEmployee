using BuisnessLayer.InterFace;
using BuisnessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpBl iEmpBl;
        public EmployeeController(IEmpBl iEmpBl)
        {
            this.iEmpBl = iEmpBl;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();
            allEmployees = this.iEmpBl.GetAllEmployees().ToList();
            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                this.iEmpBl.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Update employee details
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = this.iEmpBl.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                this.iEmpBl.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Delete Employee 
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = this.iEmpBl.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            this.iEmpBl.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
