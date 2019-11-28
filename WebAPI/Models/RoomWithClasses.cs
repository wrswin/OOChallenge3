using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RoomWithClasses : Room
    {
        public ICollection<Class> Classes { get; set; }

        public RoomWithClasses(string building, int roomNo, int capacity) : base(building, roomNo, capacity)
        {
            
        }
    }
}
