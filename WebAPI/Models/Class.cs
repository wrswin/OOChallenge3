using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Class
    {
        public string ClassCode { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public Class(string classCode, string name, string building, int roomNo)
        {
            ClassCode = classCode;
            Name = name;
            Building = building;
            RoomNo = roomNo;
        }
    }
}
