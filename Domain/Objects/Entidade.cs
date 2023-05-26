using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objects
{
    public class Entidade
    {
        public Guid Id { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
