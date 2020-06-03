using System;

namespace TPO_Lab3_Mobile.Entities
{
    public class AlmsgivingsEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public override string ToString()
        {
            return $"{Id} {Type} {Name} {Date}";
        }
    }
}