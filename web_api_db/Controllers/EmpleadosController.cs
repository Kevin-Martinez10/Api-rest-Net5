using Microsoft.AspNetCore.mvc;
using System.linq;
using web_api_db.Models;
namespace web_api_db.Controllers{
    [Route("api/[]controller")]
    public class EmpleadosControllers  : Controllers{
        private Conexion dbConexion;

        public EmpleadosControllers (){

            dbConexion = Conectar.Create();
        }
        [httpGet]

        public ActionResult Get(){

            return Ok(dbConexion.Empleados.ToArray()) ;
        }
        [httpGet("{id}")]
        public ActionResult Get(int id){
             var empleados = dbConexion.Empleados.SingleOrDefault( a => a.id.empleado == id);
             if (empleados !=null){
                    return Ok(empleados);
             }else
             {
                 return NotFound(empleados);
             }
                             
        }
        [httpPost]

        public ActionResult Post([FromBody] Empleados empleados){
            if (ModelState.IsValid){
                dbConexion.Empleados.add(empleados);
                dbConexion.SaveChanges();
                return Ok();

            }else
            {
                return NotFound();
            }
        }
        [httpPut]

        public ActionResult Put([FromBody] Empleados empleados){
            var v_empleados = dbConexion.Empleados.SingleOrDefault(a => a.id.empleado == empleados.id_empleados);
            if (v_empleados != null && ModelState.Isvalid){
                dbConexion.Entry(v_empleados).CurrentValues.Set.Values(empleados);
                dbConexion.SaveChanges();
                
            }else{
                return NotFound();
            }
            
        }
        [httpDelete("{id}")]

        public ActionResult Delete(int id){
            var empleados = dbConexion.Empleados.SingleOrDefault(a => a.id.empleado == empleados.id);
            if (empleados !=null){
                dbConexion.Empleados.Remove(empleados);
                dbConexion.SaveChanges();
                return Ok();

                
            }else{
                return NotFound();
            }
        }

    }
     
}