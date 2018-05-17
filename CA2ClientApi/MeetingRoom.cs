using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Client
{
    class MeetingRoom
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }

        public override string ToString()
        {
            return "Id: " + RoomId + "\tName: " + Name + "\n\tSize: " + Size + "\tLocation: " + Location + "\tEquipment: " + Equipment;
        }
    }
}
