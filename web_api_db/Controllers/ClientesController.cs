using Microsoft.AspNetCore.mvc;
using System.ling;
using web_api_db.Models;
namespace web_api_db.Controllers{
    [Route("api/[]controller")]
    public class ClientesControllers  : Controllers{
        private Conexion dbConexion;

        public ClientesControllers (){

            dbConexion = Conectar.Create();
        }
        [httpGet]

        public ActionResult Get(){

            return Ok(dbConexion.Clientes.ToArray()) ;
        }
        [httpGet("{id}")]
        public ActionResult Get(int id){
             var clientes = dbConexion.Clientes.SingleOrDefault( a => a.id.cliente == id);
             if (clientes !=null){
                    return Ok(clientes);
             }else
             {
                 return NotFound(clientes);
             }
                             
        }
        [httpPost]

        public ActionResult Post([FromBody] Clientes clientes){
            if (ModelState.IsValid){
                dbConexion.Clientes.add(clientes);
                dbConexion.SaveChanges();
                return Ok();

            }else
            {
                return NotFound();
            }
        }
        [httpPut]

        public ActionResult Put([FromBody] Clientes clientes){
            var v_clientes = dbConexion.Clientes.SingleOrDefault(a => a.id.cliente == clientes.id_clientes);
            if (v_clientes != null && ModelState.Isvalid){
                dbConexion.Entry(v_clientes).CurrentValues.Set.Values(clientes);
                dbConexion.SaveChanges();
                
            }else{
                return NotFound();
            }
            
        }
        [httpDelete("{id}")]

        public ActionResult Delete(int id){
            var clientes = dbConexion.Clientes.SingleOrDefault(a => a.id.cliente == clientes.id);
            if (clientes !=null){
                dbConexion.Clientes.Remove(clientes);
                dbConexion.SaveChanges();
                return Ok();

                
            }else{
                return NotFound();
            }
        }

    }
     
}