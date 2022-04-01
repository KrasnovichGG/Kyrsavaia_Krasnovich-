using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core;
using MongoDB.Driver;
using MongoDB.Libmongocrypt;

namespace Kyrsavaia_Krasnovich___
{
    public class Users
    {
        public Users(string userName, string mailUser, string password)
        {
            UserName = userName;
            MailUser = mailUser;
            Password = password;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string UserName { get; set; }
        [BsonElement]
        public string MailUser { get; set; }
        [BsonElement]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;

        public void AddToDataBase()
        {
            MongoClient mongoClient = new MongoClient(App.ConnectionString);
            var n = mongoClient.GetDatabase(App.NameBase);
            var c = n.GetCollection<Users>(App.UserCollection);
            c.InsertOne(this);
        }
        public async static Task<List<Users>> TakeList()
        {
            MongoClient mongoClientList = new MongoClient(App.ConnectionString);
            var n = mongoClientList.GetDatabase(App.NameBase);
            return await n.GetCollection<Users>(App.UserCollection).FindAsync(x => true).Result.ToListAsync();
        }
    }
}
