using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoDeAula.Domain.Entities
{
    public abstract class Basis
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateOn { get; set; } = DateTime.UtcNow;
    }
}
