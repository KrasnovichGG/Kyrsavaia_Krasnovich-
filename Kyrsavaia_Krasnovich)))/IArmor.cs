using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public interface IArmor 
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public void AddToDataBaseArmor();
        public Task<List<IArmor>> TakeArmorList();
        event Action<string> Tankist;
    }
}
