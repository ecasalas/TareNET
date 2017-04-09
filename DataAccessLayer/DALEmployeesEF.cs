//using DataAccessLayer.Model;
using DataAccessLayer.Model;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//probando git
namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            if (emp is Shared.Entities.PartTimeEmployee)
            {
                AddPartTimeEmployee((Shared.Entities.PartTimeEmployee)emp);

            }
            else
            {
                AddFullTimeEmployee((Shared.Entities.FullTimeEmployee)emp);
            }
        }

        public void DeleteEmployee(int id)
        {
            Model.Practico1TSIEntities db = new Practico1TSIEntities();
            var emp = db.EmployeesTPH.Find(id);
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

        }

        public void UpdateEmployee(Employee emp)
        {
            using (var db = new Model.Practico1TSIEntities())
            {
                var objEmp = db.EmployeesTPH.Find(emp.Id);
                db.EmployeesTPH.Attach(objEmp);
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            //creo lista vacia de tipo shared para retornar
            List<Employee> empList = new List<Employee>();
            using (var db = new Model.Practico1TSIEntities())
            {
                var empQuery = from emp in db.EmployeesTPH.OfType<Model.PartTimeEmployee>()
                               select emp;

                var objEmp = new Shared.Entities.PartTimeEmployee();
                foreach (var emp in empQuery)
                {


                    objEmp.Id = emp.EmployeeID;
                    objEmp.Name = emp.Name;
                    objEmp.StartDate = emp.StartDate;
                    objEmp.HourlyRate = emp.HourlyRate;
                    empList.Add(objEmp);
                }

                var empQueryF = from empF in db.EmployeesTPH.OfType<Model.FullTimeEmployee>()
                                select empF;
                var objEmp2 = new Shared.Entities.FullTimeEmployee();
                foreach (var empF in empQueryF)
                {
                    objEmp2.Id = empF.EmployeeID;
                    objEmp2.Name = empF.Name;
                    objEmp2.StartDate = empF.StartDate;
                    objEmp2.Salary = empF.Salary;
                    empList.Add(objEmp);
                }

            }
            return empList;
        }

        public Employee GetEmployee(int id)
        {
            Model.Practico1TSIEntities db = new Model.Practico1TSIEntities();
            var empQuery = from Employee in db.EmployeesTPH
                           where Employee.EmployeeID == id
                           select Employee;

            Employee emp;

            if (empQuery is Model.PartTimeEmployee)
            {
                Model.PartTimeEmployee objEmp = (Model.PartTimeEmployee)empQuery.Single();
                var retorno = new Shared.Entities.PartTimeEmployee();
                retorno.Id = objEmp.EmployeeID;
                retorno.Name = objEmp.Name;
                retorno.StartDate = objEmp.StartDate;
                retorno.HourlyRate = objEmp.HourlyRate;
                emp = retorno;
            }
            else
            {
                Model.FullTimeEmployee objEmp = (Model.FullTimeEmployee)empQuery.Single();
                var retorno = new Shared.Entities.FullTimeEmployee();
                retorno.Id = objEmp.EmployeeID;
                retorno.Name = objEmp.Name;
                retorno.StartDate = objEmp.StartDate;
                retorno.Salary = objEmp.Salary;
                emp = retorno;
            }


            return emp;
        }
        public void AddPartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var context = new Practico1TSIEntities();
            var t = new Model.PartTimeEmployee();

            t.Name = emp.Name;
            //t.EmployeeID = emp.Id;
            t.StartDate = emp.StartDate;
            t.HourlyRate = emp.HourlyRate;
            context.EmployeesTPH.Add(t);
            context.SaveChanges();
        }

        public void AddFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var bd = new Model.Practico1TSIEntities();
            var t = new Model.FullTimeEmployee();


            t.Name = emp.Name;
            t.EmployeeID = emp.Id;
            t.StartDate = emp.StartDate;
            t.Salary = (Int16)emp.Salary;
            bd.EmployeesTPH.Add(t);
            bd.SaveChanges();
        }
    }
}
