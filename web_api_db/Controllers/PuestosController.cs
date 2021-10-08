using Microsoft.AspNetCore.mvc;
using System.linq;
using web_api_db.Models;
namespace web_api_db.Controllers{
    [Route("api/[]controller")]
    public class PuestosControllers  : Controllers{
        private Conexion dbConexion;

        public PuestosControllers (){

            dbConexion = Conectar.Create();
        }
        [httpGet]

        public ActionResult Get(){

            return Ok(dbConexion.Puestos.ToArray()) ;
        }
        [httpGet("{id}")]
        public ActionResult Get(int id){
             var puestos = dbConexion.Puestos.SingleOrDefault( a => a.id.puesto == id);
             if (puestos !=null){
                    return Ok(puestos);
             }else
             {
                 return NotFound(puestos);
             }
                             
        }
        [httpPost]

        public ActionResult Post([FromBody] Puestos puestos){
            if (ModelState.IsValid){
                dbConexion.Puestos.add(puestos);
                dbConexion.SaveChanges();
                return Ok();

            }else
            {
                return NotFound();
            }
        }
        [httpPut]

        public ActionResult Put([FromBody] Puestos puestos){
            var v_puestos = dbConexion.Puestos.SingleOrDefault(a => a.id.puesto == puesto.id_puestos);
            if (v_puestos != null && ModelState.Isvalid){
                dbConexion.Entry(v_puestos).CurrentValues.Set.Values(puestos);
                dbConexion.SaveChanges();
                
            }else{
                return NotFound();
            }
            
        }
        [httpDelete("{id}")]

        public ActionResult Delete(int id){
            var puestos = dbConexion.Puestos.SingleOrDefault(a => a.id.puesto == puestos.id);
            if (puestos !=null){
                dbConexion.Puestos.Remove(puestos);
                dbConexion.SaveChanges();
                return Ok();

                
            }else{
                return NotFound();
            }
        }

    }
     
}