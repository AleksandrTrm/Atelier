using System.ComponentModel.DataAnnotations;

namespace Atelier.Model
{
    public class Color
    {
        [Key]
        public int color_id { get; set; }
        public string color_text { get; set; }
    }
}
