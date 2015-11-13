using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PublicEventsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Date { get; set; }
        public int Num_of_tickets { get; set; }

    }


    public class EventDBContext : DbContext
    {
        public DbSet<PublicEventsModel> Events { get; set; }
    }
}