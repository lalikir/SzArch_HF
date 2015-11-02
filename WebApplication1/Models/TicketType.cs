using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TicketType
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Category_name { get; set; }
        public int Price { get; set; }
        public int Num_of_ticket { get; set; }

    }
}