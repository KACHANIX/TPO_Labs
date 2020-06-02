using System;

namespace TPO_Lab3_Backend.Entities
{
    public class AlmsgivingEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int? BearerId { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
    }
}