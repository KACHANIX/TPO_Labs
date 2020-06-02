using System.Collections.Generic;

namespace TPO_Lab3_Backend.Entities
{
    public class BearerProfile
    {
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public List<AlmsgivingsEntity> Almsgivings { get; set; }
    }
}