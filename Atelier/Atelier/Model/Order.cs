using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atelier.Model
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public DateTime date_of_order { get; set; }
        public float prepaid_expense { get; set; }
        public float total_cost { get; set; }
        public int model { get; set; }
        public int client { get; set; }

        [ForeignKey("model")]
        public virtual Model Model { get; set; }

        [ForeignKey("client")]
        public virtual Client Client { get; set; }

    }
}
