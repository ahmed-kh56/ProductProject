using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Common
{
    public interface IAuditable
    {
        DateTime? LastUpdate { get; }
        public DateTime CreatedAt { get; }


    }
}
