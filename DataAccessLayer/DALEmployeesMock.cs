using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesMock : IDALEmployees
    {
        private List<EmployeeTPH> employeesRepository = new List<EmployeeTPH>()
        {
            new PartTimeEmployee(){HourlyRate = 100},
            new PartTimeEmployee(){HourlyRate = 150},
            new PartTimeEmployee(){HourlyRate = 200},
            new PartTimeEmployee(){HourlyRate = 250},
            new PartTimeEmployee(){HourlyRate = 300},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
        };

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
            return employeesRepository;
        }

        public EmployeeTPH GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
