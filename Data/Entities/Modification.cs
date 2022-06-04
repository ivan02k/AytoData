using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Modification:BaseClass
    {
        public int? GenerationId { get; set; }
        public Generation Generation { get; set; }
        public int? BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public int? EngineModelId { get; set; }
        public EngineModel EngineModel { get; set; }
        public int? GearBoxTypeId { get; set; }
        public GearBoxType GearBoxType { get; set; }
        public double Acceleration { get; set; }
        public double FuelConsumption { get; set; }
    }
}
