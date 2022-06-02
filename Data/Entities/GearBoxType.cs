using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class GearBoxType:StandartClass
    {
        public virtual List<Modification> Modifications { get; set; }
    }
}
