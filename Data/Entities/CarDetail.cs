using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CarDetail:BaseClass
    {
        public int? ModificationId { get; set; }
        public Modification Modification { get; set; }
        public double Acceleration { get; set; }
        public double FuelConsumption { get; set; }
    }
}
