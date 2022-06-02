using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Brand:StandartClass
    {
        public virtual List<BrandModel> BrandModels { get; set; }
    }
}
