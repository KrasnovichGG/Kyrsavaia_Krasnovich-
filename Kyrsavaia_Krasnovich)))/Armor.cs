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

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string NameArmor { get; set; }

        public event Action<string> Tankist;
        public Armor(string nameArmor)
        {
            NameArmor = nameArmor;
        }

        public async Task AddToDataBaseArmor()
        {
            if (await Check())
            {
                MongoClient clientArmor = new MongoClient(App.ConnectionString);
                var n = clientArmor.GetDatabase(App.NameBase);
                var c = n.GetCollection<Armor>(App.ArmorCollection);
                Tankist?.Invoke("Броня добавлена в базу данных");
                await c.InsertOneAsync(this);
            }
            else
            {
                //Работает..
                Tankist?.Invoke("Броня уже существует!!!");
            }
        }

        public async static Task<List<Armor>> TakeArmorList()
        {
            MongoClient mongoClientListArmor = new MongoClient(App.ConnectionString);
            var n = mongoClientListArmor.GetDatabase(App.NameBase);
            //Tankist?.Invoke("Список брони успешно получен!");
            return await n.GetCollection<Armor>(App.ArmorCollection).FindAsync(x => true).Result.ToListAsync();
        }

        private async Task<bool> Check()
        {
            var ArmorCollection = await Armor.TakeArmorList();
            foreach (var item in ArmorCollection)
            {
                if (NameArmor == item.NameArmor)
                    return false;

            }
            return true;
        }
    }
}
