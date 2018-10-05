using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;
using WebShop.Domain.Models;
using WebShop.Domain;

namespace WebShop.Controllers
{
    [Authorize(Roles = Constants.Roles.User)]
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

        [Authorize(Roles = Constants.Roles.Administrator)]
        public IActionResult EmployeeDelete(int id)
        {

            _employeeData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = Constants.Roles.Administrator)]
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
        [Authorize(Roles = Constants.Roles.Administrator)]
        public IActionResult EmployeeEdit(EmployeeView employee)
        {
            if (employee.HiredDate > System.DateTime.Now)
            {
                ModelState.AddModelError("HiredDate", "Ошибка даты приёма на работу");
            }
            if (employee.Birsday > System.DateTime.Now.AddYears(-18))
            {
                ModelState.AddModelError("HiredDate", "Нельзя брать на работу лиц младше 18 лет");
            }

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