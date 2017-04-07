using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;


namespace DataAccessLayer
{
    public class DALEmployeesMongo : IDALEmployees

        
    {
        public void AddEmployee(Employee emp)
        {
            try
            {
                string con = ConexionMongo();
                MongoClient cliente = new MongoClient(con);
                IMongoDatabase db = cliente.GetDatabase("practico");
                IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");


                if (emp is FullTimeEmployee)
                {
                    col.InsertOne(new Empleados { EMP_ID = emp.Id, NAME = emp.Name, START_DATE = emp.StartDate, SALARY = new FullTimeEmployee().Salary, RATE = null, TYPE_EMP = 1 });
                }
                else
                {
                    col.InsertOne(new Empleados { EMP_ID = emp.Id, NAME = emp.Name, START_DATE = emp.StartDate, SALARY = null, RATE = new PartTimeEmployee().HourlyRate, TYPE_EMP = 2 });

                }
            }
            catch
            {
                Console.WriteLine("Problema al agregar el empleado de id: " + emp.Id + " y nombre " + emp.Name + " a la base de datos Mongodb");
            }

        }

        public void DeleteEmployee(int id)
        {
            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            try
            {
                //hago filtro diciendo, traeme el documento con el id que me pasan EMP_ID es un campo de ese documento en mongo
                var filtro = Builders<Empleados>.Filter.Eq("EMP_id", id);

                // var elminar =  col.DeleteManyAsync(filtro); este es para elminiar todos los wque cumplan con la condicion del filtro, pero al ser unica la id,usamos deleteone , creo....
                var elminar = col.DeleteOne(filtro);

                Console.WriteLine("El empleadodo con id: " + id + " fue eliminado de la base de datos MongoDB");
            }catch
            {
                Console.WriteLine("Problemas al eliminar empleado de id: " + id + " de la base de datos MongoDB");
            }

        }

        public void UpdateEmployee(Employee emp)
        {

            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            try
            {
                var filtro = Builders<Empleados>.Filter.Eq("EMP_ID", emp.Id);

                if (emp is FullTimeEmployee)
                {
                    var update = Builders<Empleados>.Update.Set("NAME", emp.Id).Set("START_DATE", emp.StartDate).Set("SALARY", new FullTimeEmployee().Salary).Set("RATE", "null").Set("TYPE_EMP", 1);
                    var res = col.UpdateOne(filtro, update);
                }
                else
                {
                    var update = Builders<Empleados>.Update.Set("NAME", emp.Id).Set("START_DATE", emp.StartDate).Set("SALARY", "null").Set("RATE", new PartTimeEmployee().HourlyRate).Set("TYPE_EMP", 2);
                    var resultado = col.UpdateOne(filtro, update);
                }
                //como soy una pija todavia no se como hacer lo de ver si es fullemployee o parttime
            }catch
            {
                Console.WriteLine("Problemas al modificar empleado de id: " + emp.Id + " en la base de datos MongoDB");
            }

            //throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()

        {
            try
            {
                string con = ConexionMongo();
                MongoClient cliente = new MongoClient(con);
                IMongoDatabase db = cliente.GetDatabase("practico");
                IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

                var coll = db.GetCollection<Empleados>("Empleados").AsQueryable();

                List<Employee> empleados = new List<Employee>();

                for (int i = 0; i < empleados.Count(); i++)
                {
                    return empleados;
                }
            }
            catch
            {
                Console.WriteLine("Problema al listar todos los empleados de la base de datos MongoDB");
                return null;
            }

            return null;//wtf esto me lo puso a prepo

        }

        //Ver con los pibes, no se como setearle las cosas y mi cabeza no da mas
        public Employee GetEmployee(int id)
        {

            //sin terminar

            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            

            try
            {
             
                var filtro = Builders<Empleados>.Filter.And(
                    Builders<Empleados>.Filter.Eq("EMP_id", id),
                    Builders<Empleados>.Filter.Eq("TYPE_EMP",1)
                    );

                                //ahora tengo que ver si es full o part , y crear uno de esos 2
                //ARREGLAR BIEN CON LA AYUDA DE LOS PIBES,MI MENTE NO DA MAS POR HOY
                if (filtro is null)

                {
                    var filtro2 = Builders<Empleados>.Filter.And(
                    Builders<Empleados>.Filter.Eq("EMP_id", id),
                    Builders<Empleados>.Filter.Eq("TYPE_EMP", 2)
                    );

                    if (filtro2 !=null)
                    {
                        PartTimeEmployee pt = new PartTimeEmployee();
                        pt.Id = id;
                        pt.Name = null;
                        pt.StartDate = new DateTime();//chuco
                        pt.HourlyRate = 0;//chuco
                        return pt;
                    }else
                    {
                        Console.WriteLine("No existe dicho empleado");
                    }

                }
                else
                {
                    FullTimeEmployee ft = new FullTimeEmployee();
                    ft.Id = id;
                    ft.Salary = 0;
                    ft.Name = null;
                    ft.StartDate = new DateTime();
                    return ft;
                }


            }
            catch
            {
                Console.WriteLine("No se pudo encontrar empleado de id: " + id + " en la base de datos MongoDB");
                    
            }

            
            throw new NotImplementedException();

    }

        public string ConexionMongo() { 
    
        string con = "mongodb://127.0.0.1:27017";
        return con;

        //throw new NotImplementedException();
    }

        public class Empleados
        {
            public ObjectId _id { get; set; }
            public int EMP_ID { get; set; }
            public string NAME { get; set; }
            public DateTime START_DATE { get; set; }
            public  int? SALARY { get; set; }
            public double? RATE { get; set; }
            public int TYPE_EMP { get; set; }
        }


    }
}

