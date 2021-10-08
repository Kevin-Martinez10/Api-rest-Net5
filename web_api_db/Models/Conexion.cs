using Microsoft.EntityFrameworkCore;

namespace web_api_db.Models{
    class Conexion : DbContext{

        public Conexion(DbContextOptions<Conexion> options) : base (options) {}
        public Dbset<Clientes> Clientes {get;set;}
        public Dbset<Clientes> Puestos {get;set;}
        public Dbset<Clientes> Empleados {get;set;}

    }
    class Conectar{
        private const string cadenaConexion = "server=localhost; port=3306; database=de_empresa; userid=usr_empresa ; pwd=Empres@123";
        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion (constructor.options);
            return cn;
        } 
    }
    
}