using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public  class Engine : IEngine
    {
        public Engine(string nameEngine)
        {
            Name = nameEngine;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }

        public event Action<string> Tankist;

        public async Task AddToDataBaseEngine()
        {
            if (await Check())
            {
                MongoClient clientEngine = new MongoClient(App.ConnectionString);
                var v = clientEngine.GetDatabase(App.NameBase);
                var c = v.GetCollection<IEngine>(App.EngineCollection);
                Tankist?.Invoke("Двигатель добавлен в базу данных");
                c.InsertOne(this);
            }
            else
            {
                Tankist?.Invoke("Такой двигатель уже существует!!!");
            }
        }
        public async static Task<List<IEngine>> TakeEngineList()
        {
            MongoClient mongoClientListEngine = new MongoClient(App.ConnectionString);
            var v = mongoClientListEngine.GetDatabase(App.NameBase);
            return await v.GetCollection<IEngine>(App.EngineCollection).FindAsync(x => true).Result.ToListAsync();
        }

        private async Task<bool> Check()
        {
            var EngineCollection = await Engine.TakeEngineList();
            foreach (var item in EngineCollection)
            {
                if (this.Name == item.Name)
                    return false ;
            }
            return true ;
        }

        public async static Task<Engine> GetEngine(string name)
        {
            var c = await Engine.TakeEngineList();
            if(c != null)
                return (Engine)c.Find(x => x.Name == name);
            return new Engine("HUI");
        }
    }
}
