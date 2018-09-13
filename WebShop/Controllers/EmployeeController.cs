using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData _employeeData;

        public EmployeeController(IEmployeesData employeeData)
        {
            _employeeData = employeeData;
        }

        public IActionResult Index()
        {
            return View(_employeeData.GetAll());
        }

        public IActionResult EmployeeDetails(int id)
        {
            var employee = _employeeData.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult EmployeeDelete(int id)
        {

            _employeeData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EmployeeEdit(int? id)
        {
            EmployeeView employeeView = null;
            if (id.HasValue)
            {
                employeeView = _employeeData.GetById(id.Value);
                if (employeeView is null)
                {
                    return NotFound();
                }
            }
            else
            {
                employeeView = new EmployeeView();
            }
            return View(employeeView);
        }

        [HttpPost]
        public IActionResult EmployeeEdit(EmployeeView employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id > 0)
                {
                    var item = _employeeData.GetById(employee.Id);
                    if (item is null)
                    {
                        return NotFound();
                    }
                    item.FirstName = employee.FirstName;
                    item.LastName = employee.LastName;
                    item.Patronymic = employee.Patronymic;
                    item.Birsday = employee.Birsday;
                    item.HiredDate = employee.HiredDate;
                }
                else
                {
                    _employeeData.AddNew(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
    }
}