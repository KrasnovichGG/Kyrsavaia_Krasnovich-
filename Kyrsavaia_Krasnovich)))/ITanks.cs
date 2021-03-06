using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public interface ITanks
    {
        public ObjectId ID { get; }
        public string NameTank { get; set; }
        public string SpeedTank { get; set; }
        public string LengthTank { get; set; }
        public string YearOFIssueTank { get; set; }
        public string CalibrTank { get; set; }
        public event Action<string> Tankist;
        IArmor ArmorTank { get; set; }
        IEngine EngineTank { get; set; }
        IGun GunTank { get; set; }
    }
}
