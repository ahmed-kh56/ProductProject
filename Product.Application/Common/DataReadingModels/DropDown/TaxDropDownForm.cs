using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.DropDown
{
    public class TaxDropDownForm
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Rate { get; private set; }
    }
}
