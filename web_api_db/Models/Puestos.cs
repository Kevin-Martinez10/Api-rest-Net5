using System.ComponentModel.DataAnnotations;
namespace web_api_db.Models{
    public class Puestos{
        [key]

        public int id_puestos {get;set;}

        public string puesto {get;set;}
    }
}