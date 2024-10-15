using System.ComponentModel.DataAnnotations;

namespace Atelier.Model
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public string client_name { get; set; }
        public string client_surname { get; set; }
        public string client_phone { get; set; }
    }
}
