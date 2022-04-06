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

        public void AddToDataBaseEngine()
        {
            MongoClient clientEngine = new MongoClient(App.ConnectionString);
            var v = clientEngine.GetDatabase(App.NameBase);
            var c = v.GetCollection<IEngine>(App.EngineCollection);
            Tankist?.Invoke("Двигатель добавлен в базу данных");
            c.InsertOne(this);
        }
        public async Task<List<IEngine>> TakeEngineList()
        {
            MongoClient mongoClientListEngine = new MongoClient(App.ConnectionString);
            var v = mongoClientListEngine.GetDatabase(App.NameBase);
            Tankist?.Invoke("Список двигателей получен из базы данных!");
            return await v.GetCollection<IEngine>(App.EngineCollection).FindAsync(x => true).Result.ToListAsync();
        }
    }
}
