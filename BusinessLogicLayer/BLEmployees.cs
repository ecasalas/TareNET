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

        public void AddEmployee(Employee emp)
        {

            _dal.AddEmployee(emp);
            //throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            _dal.UpdateEmployee(emp);
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lemp = _dal.GetAllEmployees();

            return lemp;
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _dal.GetEmployee(id);
            return emp;
            throw new NotImplementedException();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            try
            {
                Employee emp = _dal.GetEmployee(idEmployee);

                if (emp is FullTimeEmployee)
                {
                    Console.WriteLine("El empleado de id"+idEmployee+" es Full Time");
                }
                else if ( emp is null)
                {
                    Console.WriteLine("El empleado que usted selecciono, no se encuentra en la base de datos");
                }
                else
                {
                    double rate = new PartTimeEmployee().HourlyRate;
                    return rate * hours;
                }
            }
            catch
            {
                //esto mepa que es cualquier cagada... revisar
            }
            throw new NotImplementedException();
        }
    }
}
