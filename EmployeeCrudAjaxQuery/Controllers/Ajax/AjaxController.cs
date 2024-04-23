using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Entities;

namespace EmployeeCrudAjaxQuery.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private readonly Context _context;

        private readonly IEmployeeBusiness _business;
        public AjaxController(Context context,IEmployeeBusiness business)
        {
            this._context = context;
            this._business = business;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult EmployeeList()
        {
            var data = _context.Employee.ToList();
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            Employee emp = new Employee()
            {
                Name = employee.Name,
                City = employee.City,
                State = employee.State,
                Salary = employee.Salary,
            };
            this._context.Employee.Add(emp);
            this._context.SaveChanges();
            return new JsonResult("Data is Saved");
        }

        public JsonResult Delete(int id)
        {
            var data = _context.Employee.Where(e => e.Id == id).SingleOrDefault();
            this._context.Employee.Remove(data);
            _context.SaveChanges();
            return new JsonResult("Data Delted");
        }

        public JsonResult Edit(int id)
        {
            var data=this._context.Employee.Where(e=>e.Id==id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Employee employee)
        {
            this._context.Employee.Update(employee);
            this._context.SaveChanges();
            return new JsonResult("Record updated")
;        }
        
    }
}
