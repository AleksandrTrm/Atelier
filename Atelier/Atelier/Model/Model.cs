using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atelier.Model
{
    public class Model
    {
        [Key]
        public int model_id { get; set; }
        public int size { get; set; }
        public int color { get; set; }
        public int material { get; set; }
        public string model_title { get; set; }

        [ForeignKey("size")]
        public virtual Size Size { get; set; }

        [ForeignKey("color")]
        public virtual Color Color { get; set; }

        [ForeignKey("material")]
        public virtual Material Material { get; set; }
    }
}
