using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atelier.Model
{
    public class Fitting
    {
        [Key]
        public int fitting_id { get; set; }
        public DateTime fitting_date { get; set; }
        public int order_id { get; set; }

        [ForeignKey("order_id")]

        public virtual Order order { get; set; }
    }
}
