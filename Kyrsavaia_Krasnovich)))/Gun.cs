﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public class Gun : IGun
    {
        public Gun(string nameGun)
        {
            Name = nameGun;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        public event Action<string> Tankist;
        public void AddToDataBaseGun()
        {
            MongoClient mongoClientGun = new MongoClient(App.ConnectionString);
            var c = mongoClientGun.GetDatabase(App.NameBase);
            var b = c.GetCollection<IGun>(App.GunCollection);
            Tankist.Invoke("Орудие добавлено в базу данных!");
            b.InsertOne(this);
        }
        public async static Task<List<IGun>> TakeGunList()
        {
            MongoClient mongoClientTakeGun = new MongoClient(App.ConnectionString);
            var c = mongoClientTakeGun.GetDatabase(App.NameBase);
            return await c.GetCollection<IGun>(App.GunCollection).FindAsync(x => true).Result.ToListAsync();
        }

        public async static Task<Gun> GetGun(string name)
        {
            var c = await Gun.TakeGunList();
            if(c != null)
                return (Gun)c.Find(x => x.Name == name);
            return new Gun("HUI");
        }
    }
}
