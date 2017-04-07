using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceEmployees : IServiceEmployees
    {
        private static IBLEmployees blHandler;

        public ServiceEmployees()
        {
            blHandler = Program.blHandler;
        }

        public void AddEmployee(EmployeeTPH emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeTPH emp)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTPH> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeTPH GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            throw new NotImplementedException();
        }
    }
}
