using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerService.Models
{
    public class Order
    {
        [Key]
        public int SerialNo { get; set; }
        public int Order_Idd { get; set; }
        public int Total_Items{ get; set; }
        public float Total_Price { get; set; }
        public float Total_Tax { get; set; }
        public float Total_Sum_Tax { get; set; }
        public string Order_Status{ get; set; }
    }
}
