using System;
using System.Collections.Generic;

namespace TPO_Lab3_Backend.Models
{
    public partial class Bearer
    {
        public Bearer()
        {
            Almsgiving = new HashSet<Almsgiving>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Almsgiving> Almsgiving { get; set; }
    }
}
