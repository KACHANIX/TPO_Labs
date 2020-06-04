using System;

namespace TPO_Lab3_Mobile.Entities
{
    public class AlmsgivingsEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{String.Format("{0,9}", Type)}    {String.Format("{0,20}", Name)}    {Date.ToString("dd/MM/yyyy")}";
        }
    }
}