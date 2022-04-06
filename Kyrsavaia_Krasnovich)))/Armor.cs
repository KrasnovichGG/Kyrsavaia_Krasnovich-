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
    public class Armor : IArmor
    {
        public Armor(string nameArmor)
        {
           Name = nameArmor;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }

        public event Action<string> Tankist;

        public void AddToDataBaseArmor()
        {
            MongoClient clientArmor = new MongoClient(App.ConnectionString);
            var n = clientArmor.GetDatabase(App.NameBase);
            var c = n.GetCollection<IArmor>(App.ArmorCollection);
            Tankist?.Invoke("Броня добавлена в базу данных");
            c.InsertOne(this);
        }
        public async Task<List<IArmor>> TakeArmorList()
        {
            MongoClient mongoClientListArmor = new MongoClient(App.ConnectionString);
            var n = mongoClientListArmor.GetDatabase(App.NameBase);
            Tankist?.Invoke("Список брони успешно получен!");
            return await n.GetCollection<IArmor>(App.ArmorCollection).FindAsync(x => true).Result.ToListAsync();
        }


    }
}
