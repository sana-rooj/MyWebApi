using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerService.Models
{
    public class OrderInfo
    {
        public List<int> ProductIds { get; set; } = new List<int>();
        public string Status { get; set; }
    }
}
