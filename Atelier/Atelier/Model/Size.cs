using System.ComponentModel.DataAnnotations;

namespace Atelier.Model
{
    public class Size
    {
        [Key]
        public int size_id { get; set; }
        public string size_text { get; set; }
    }
}
