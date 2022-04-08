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
    public class Tank : ITanks
    {
        public Tank(string nameTank, string speedTank, string lengthTank, string yearOFIssueTank, string calibrTank, IArmor armorTank, IEngine engineTank, IGun gunTank)
        {
            NameTank = nameTank;
            SpeedTank = speedTank;
            LengthTank = lengthTank;
            YearOFIssueTank = yearOFIssueTank;
            CalibrTank = calibrTank;
            ArmorTank = armorTank;
            EngineTank = engineTank;
            GunTank = gunTank;
        }

        [BsonIgnore]
        [BsonIgnoreIfDefault]
        public ObjectId ID { get; set; }
        [BsonElement]
        public string NameTank { get; set; }
        [BsonElement]
        public string SpeedTank { get; set; }
        [BsonElement]
        public string LengthTank { get; set; }
        [BsonElement]
        public string YearOFIssueTank { get; set; }
        [BsonElement]
        public string CalibrTank { get; set; }
        [BsonElement]
        public IArmor ArmorTank { get; set; }
        [BsonElement]
        public IEngine EngineTank { get; set; }
        [BsonElement]
        public IGun GunTank { get; set; }
        public event Action<string> Tankist;
        public async Task AddToDataBaseTank()
        {
            if(await Check())
            {
                MongoClient mongoClientTank = new MongoClient(App.ConnectionString);
                var c = mongoClientTank.GetDatabase(App.NameBase);
                var b = c.GetCollection<Tank>(App.TankCollection);
                Tankist.Invoke("Успешное добавление в базу!");
                await b.InsertOneAsync(this);
            }
            else
            {
                Tankist.Invoke("ПОШЕЛ НАХУЙ!! ТАКОЙ УЖЕ ЕСТЬ ДОЛБАЕБ ЕБАНЫЙ");
            }
            
        }
        public static async Task<List<Tank>> TakeOfDataBasaTanks()
        {
            MongoClient mongoClientTakeTank = new MongoClient(App.ConnectionString);
            var c = mongoClientTakeTank.GetDatabase(App.NameBase);
            var b = c.GetCollection<Tank>(App.TankCollection);
            return await b.FindAsync(x => true).Result.ToListAsync();
        }
        private async Task<bool> Check()
        {
            var TankCollection = await Tank.TakeOfDataBasaTanks();
            foreach (var item in TankCollection)
            {
                if (NameTank == item.NameTank)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
