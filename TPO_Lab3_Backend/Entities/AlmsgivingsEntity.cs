using System;

namespace TPO_Lab3_Backend.Entities
{
    public class AlmsgivingsEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
    }
}