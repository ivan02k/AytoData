using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BodyType:StandartClass
    {
        [Required]
        public int Doors { get; set; }
        [Required]
        public int Seats { get; set; }
        public virtual List<Modification> Modifications { get; set; }
    }
}
