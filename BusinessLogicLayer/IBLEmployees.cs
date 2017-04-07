using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBLEmployees
    {
        void AddEmployee(EmployeeTPH emp);

        void DeleteEmployee(int id);

        void UpdateEmployee(EmployeeTPH emp);

        List<EmployeeTPH> GetAllEmployees();

        EmployeeTPH GetEmployee(int id);

        double CalcPartTimeEmployeeSalary(int idEmployee, int hours);
    }
}
