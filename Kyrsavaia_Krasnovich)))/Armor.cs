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
    public class Armor
    {
        public Armor(string nameArmor)
        {
           NameArmor = nameArmor;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string NameArmor { get; set; }
        public void AddToDataBaseArmor()
        {
            MongoClient clientArmor = new MongoClient(App.ConnectionString);
            var n = clientArmor.GetDatabase(App.NameBase);
            var c = n.GetCollection<Armor>(App.ArmorCollection);
            c.InsertOne(this);
        }
        public async static Task<List<Armor>> TakeArmorList()
        {
            MongoClient mongoClientListArmor = new MongoClient(App.ConnectionString);
            var n = mongoClientListArmor.GetDatabase(App.NameBase);
            return await n.GetCollection<Armor>(App.ArmorCollection).FindAsync(x => true).Result.ToListAsync();
        }
    }
}
