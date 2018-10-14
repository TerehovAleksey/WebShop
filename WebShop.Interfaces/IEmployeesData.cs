using System.Collections.Generic;
using WebShop.Domain.Models;

namespace WebShop.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> GetAll();

        EmployeeView GetById(int id);

        EmployeeView UpdateEmployee(int id, EmployeeView employee);

        void AddNew(EmployeeView model);

        void Delete(int id);
    }


}
