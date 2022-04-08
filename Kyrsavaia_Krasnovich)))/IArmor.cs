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
        public string NameArmor { get; set; }
        public Task AddToDataBaseArmor();
        event Action<string> Tankist;
    }
}
