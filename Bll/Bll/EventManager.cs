using Bll.DTO;
using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class EventManager
    {
        public List<EventHeaderData> GetAllEvent()
        {
            using (var context = new EventDBEntities())
            {
                var allEvent = (from p in context.EVENT
                                  select new EventHeaderData
                                  {
                                      Id = p.EVENT_ID,
                                      Name = p.NAME,
                                      Date = p.DATE,
                                      Tickets =(int) p.NUM_OF_TICKET
                                  }).ToList();
                Console.WriteLine(allEvent);
                return allEvent;
            }
        }

    }
}
