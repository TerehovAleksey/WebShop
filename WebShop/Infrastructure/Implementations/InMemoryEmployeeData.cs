using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastructure.Implementations
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

        public void Commit()
        {
            throw new NotImplementedException();
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
    }
}
