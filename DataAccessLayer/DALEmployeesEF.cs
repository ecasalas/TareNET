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
        public void AddEmployee(EmployeeTPH emp)
        {
            if (emp is Shared.Entities.PartTimeEmployee) {
                AddPartTimeEmployee((Shared.Entities.PartTimeEmployee)emp);
        
            }
            else
            {
                AddFullTimeEmployee((Shared.Entities.FullTimeEmployee)emp);
            }
        }

        public void DeleteEmployee(int id)
        {
            TAREANETEntities1 db = new TAREANETEntities1();
            var emp = db.Employees.Find(id);
            db.Employees.Attach(emp);
            db.SaveChanges();
            
        }

        public void UpdateEmployee(EmployeeTPH emp)
        {
            using (var db = new TAREANETEntities1())
            {
                var objEmp = db.Employees.Find(emp.Id);
                db.Employees.Attach(objEmp);
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<EmployeeTPH> GetAllEmployees()
        {
            //creo lista vacia de tipo shared para retornar
            List<EmployeeTPH> empList = new List<EmployeeTPH>();
            using (var db = new TAREANETEntities1())
            {
                var empQuery = from emp in db.Employees.OfType< Model.PartTimeEmployee>()
                               select emp;

                var objEmp = new Shared.Entities.PartTimeEmployee();
                foreach (var emp in empQuery)
                {

                    
                    objEmp.Id = emp.EmployeId;
                    objEmp.Name = emp.Name;
                    objEmp.StartDate = emp.StartDate;
                    objEmp.HourlyRate = emp.HourlyRate;
                    empList.Add(objEmp);
                }

                var empQueryF = from empF in db.Employees.OfType<Model.FullTimeEmployee>()
                           select empF;
                var objEmp2 = new Shared.Entities.FullTimeEmployee();
                foreach(var empF in empQueryF)
                {
                    objEmp2.Id = empF.EmployeId;
                    objEmp2.Name = empF.Name;
                    objEmp2.StartDate = empF.StartDate;
                    objEmp2.Salary = empF.Salary;
                    empList.Add(objEmp);
                }

            }
            return empList;
        }

        public EmployeeTPH GetEmployee(int id)
        {
            TAREANETEntities1 db = new TAREANETEntities1();
            var empQuery = from Employee in db.Employees
                           where Employee.EmployeId == id
                           select Employee;
            
            EmployeeTPH emp;
            
            if (empQuery is Model.PartTimeEmployee)
            {
                Model.PartTimeEmployee objEmp = (Model.PartTimeEmployee)empQuery.Single();
                var retorno = new Shared.Entities.PartTimeEmployee();
                retorno.Id = objEmp.EmployeId;
                retorno.Name = objEmp.Name;
                retorno.StartDate = objEmp.StartDate;
                retorno.HourlyRate = objEmp.HourlyRate;
                emp = retorno;
            }
            else
            {
                Model.FullTimeEmployee objEmp = (Model.FullTimeEmployee)empQuery.Single();
                var retorno = new Shared.Entities.FullTimeEmployee();
                retorno.Id = objEmp.EmployeId;
                retorno.Name = objEmp.Name;
                retorno.StartDate = objEmp.StartDate;
                retorno.Salary = objEmp.Salary;
                emp = retorno;
            }

            
            return emp;
        }
        public void AddPartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var context = new TAREANETEntities1();
            var t = new Model.PartTimeEmployee();

            t.Name = emp.Name;
            t.EmployeId = emp.Id;
            t.StartDate = emp.StartDate;
            t.HourlyRate = emp.HourlyRate;
            context.Employees.Add(t);
        }

        public void AddFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var bd = new TAREANETEntities1();
            var t = new Model.FullTimeEmployee();
            

            t.Name = emp.Name;
            t.EmployeId = emp.Id;
            t.StartDate = emp.StartDate;
            t.Salary = emp.Salary;
            bd.Employees.Add(t);
        }
    }
}
