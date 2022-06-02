using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Generation:StandartClass
    {
        public int? BrandModelId { get; set; }
        public BrandModel BrandModel { get; set; }
        public string YearFactury { get; set; }
        public virtual List<Modification> Modifications { get; set; }
    }
}
