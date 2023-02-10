using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
    }
}
