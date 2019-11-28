using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Computer
    {
        public int Number { get; set; }
        public int AssembledYear { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public Computer(int number, int assembledYear, string building, int roomNo)
        {
            Number = number;
            AssembledYear = assembledYear;
            Building = building;
            RoomNo = roomNo;
        }
    }
}
