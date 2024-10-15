using System.ComponentModel.DataAnnotations;


namespace Atelier.Model
{
    public class Material
    {
        [Key]
        public int material_id { get; set; }
        public string material_text { get; set; }
    }
}
