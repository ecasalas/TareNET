using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using Shared.Entities;
using MongoDB.Driver;
using MongoDB.Bson;



namespace ServiceLayer
{
    class Program
    {
        public static IBLEmployees blHandler;



        static void Main(string[] args)
        {

            SetupDependencies();
            SetupService();

            FullTimeEmployee  pte = new FullTimeEmployee();
            pte.Id = 2;
            pte.Name = "Jorge";
            pte.StartDate = new DateTime(2019,11,11);
            pte.Salary = 17800;
            Console.WriteLine("voy a inserttar");

            // blHandler.AddEmployee(pte);
            // blHandler.DeleteEmployee(1);
            double emp = blHandler.CalcPartTimeEmployeeSalary(3,10);

            Console.WriteLine("Calculo de sueldo: "+emp);
            Console.ReadKey();
            


        }
        

        private static void SetupDependencies()
        {

            //blHandler = new BLEmployees( new DataAccessLayer.DALEmployeesEF());
               blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
           
            
        }

        private static void SetupService()
        {
        }
    }
}
