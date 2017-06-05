using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalCalc.Api.Models
{
    public class DextroseConcentration
    {
        public DextroseConcentration()
        {
            FluidInfusion = new HashSet<FluidInfusion>();
        }

        public int Id { get; set; }
        public string Concentration { get; set; }
        public decimal KcalMl { get; set; }

        public ICollection<FluidInfusion> FluidInfusion { get; set; }
    }
}
