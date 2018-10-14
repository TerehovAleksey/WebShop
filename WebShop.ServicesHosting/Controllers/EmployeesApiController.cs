using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Models;
using WebShop.Interfaces;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesApiController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        [HttpPost]
        public void AddNew([FromBody]EmployeeView model)
        {
            _employeesData.AddNew(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeesData.Delete(id);
        }

        [HttpGet]
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employeesData.GetAll();
        }

        [HttpGet("{id}")]
        public EmployeeView GetById(int id)
        {
            return _employeesData.GetById(id);
        }

        [HttpPut("{id}")]
        public EmployeeView UpdateEmployee(int id, [FromBody]EmployeeView employee)
        {
            return _employeesData.UpdateEmployee(id, employee);
        }
    }
}