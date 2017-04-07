using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
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
