using System.ComponentModel.DataAnnotations;

namespace CrudUdemy.Models
{
    public class Gestor
    {
        [Key]
        public int id { get; set; }
        public int lanzamiento { get; set; }
        public string nombre { get; set; }
        public string desarrollador { get; set; }

    }
}
