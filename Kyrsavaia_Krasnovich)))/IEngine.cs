using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public interface IEngine
    {
        public ObjectId Id { get; }
        public string Name { get; set; }
        public Task AddToDataBaseEngine();
        public event Action<string> Tankist;
    }
}
