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

            PartTimeEmployee pte = new PartTimeEmployee();
            pte.Id = 18999;
            pte.Name = "pimba";
            pte.StartDate = new DateTime(2019,11,11);
            pte.HourlyRate = 178.0f;
            Console.WriteLine("voy a inserttar");

           // blHandler.AddEmployee(pte);
            blHandler.DeleteEmployee(1);

            Console.WriteLine("mierda");
            Console.ReadKey();
            


        }
        

        private static void SetupDependencies()
        {

            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
                //blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
           
            
        }

        private static void SetupService()
        {
        }
    }
}
