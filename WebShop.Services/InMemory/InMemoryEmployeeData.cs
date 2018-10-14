using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Models;
using WebShop.Interfaces;

namespace WebShop.Services.InMemory
{
    public class InMemoryEmployeeData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeeData()
        {
            _employees = new List<EmployeeView>(3)
            {
             new EmployeeView
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Андрей",
                Patronymic = "Николаевич",
                Birsday = new DateTime(1990, 04, 22),
                HiredDate = new DateTime(2017, 12, 10)
            },
             new EmployeeView
            {
                Id = 2,
                LastName = "Петров",
                FirstName = "Сергей",
                Patronymic = "Алексеевич",
                Birsday = new DateTime(1988, 01, 30),
                HiredDate = new DateTime(2016, 02, 11)
            },
             new EmployeeView
            {
                Id = 3,
                LastName = "Соколов",
                FirstName = "Олег",
                Patronymic = "Иванович",
                Birsday = new DateTime(1993, 08, 02),
                HiredDate = new DateTime(2017, 10, 01)
            }
            };
        }

        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
                _employees.Remove(employee);
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public EmployeeView UpdateEmployee(int id, EmployeeView employee)
        {
            if (employee==null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            var data = _employees.FirstOrDefault(e => e.Id == id);
            if (data != null)
            {
                data.Birsday = employee.Birsday;
                data.FirstName = employee.FirstName;
                data.HiredDate = employee.HiredDate;
                data.LastName = employee.LastName;
                data.Patronymic = employee.Patronymic;
                return data;
            }
            else
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }
        }
    }
}
