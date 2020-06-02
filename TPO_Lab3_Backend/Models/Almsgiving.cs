using System;
using System.Collections.Generic;

namespace TPO_Lab3_Backend.Models
{
    public partial class Almsgiving
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int? BearerId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Bearer Bearer { get; set; }
    }
}
