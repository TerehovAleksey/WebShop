using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> GetAll();

        EmployeeView GetById(int id);

        void Commit();

        void AddNew(EmployeeView model);

        void Delete(int id);
    }


}
