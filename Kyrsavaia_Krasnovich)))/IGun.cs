using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public  interface IGun
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Task AddToDataBaseGun();
        public event Action<string> Tankist;
    }
}
