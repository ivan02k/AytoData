using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class EngineModel:StandartClass
    {
        [Required]
        public int Power { get; set; }
        [Required]
        public int NumberCylinders { get; set; }
        [Required, MaxLength(20)]
        public string FuelType { get; set; }
        public virtual List<Modification> Modifications { get; set; }
    }
}
