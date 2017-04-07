using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver;



namespace DataAccessLayer
{
    public class DALEmployeesMongo : IDALEmployees
    {
        public void AddEmployee(EmployeeTPH emp)
        {
            const String conexion = "mongodb://localhost";
            var cliente = new MongoClient(conexion);
            var bd = cliente.GetDatabase("TAREANET");

            

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
    }
}
