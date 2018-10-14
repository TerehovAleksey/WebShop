using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebShop.Clients.Base;
using WebShop.Domain.Models;
using WebShop.Interfaces;

namespace WebShop.Clients.Services.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration confuguration): base(confuguration)
        {
            ServiceAddress = "api/employees";
        }

        protected sealed override string ServiceAddress { get; set; }

        public void AddNew(EmployeeView model)
        {
            var url = $"{ServiceAddress}";
            Post(url, model);
        }

        public void Delete(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            Delete(url);
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            var url = $"{ServiceAddress}";
            var list = Get<List<EmployeeView>>(url);
            return list;
        }

        public EmployeeView GetById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<EmployeeView>(url);
            return result;
        }

        public EmployeeView UpdateEmployee(int id, EmployeeView employee)
        {
            var url = $"{ServiceAddress}/{id}";
            var responce = Put(url, employee);
            var result = responce.Content.ReadAsAsync<EmployeeView>().Result;
            return result;
        }
    }
}
