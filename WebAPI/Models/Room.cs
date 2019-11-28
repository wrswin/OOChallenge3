using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Room
    {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }

        public Room(string building, int roomNo, int capacity)
        {
            Building = building;
            RoomNo = roomNo;
            Capacity = capacity;
        }
    }
}
