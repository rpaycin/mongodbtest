using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDbTest.MongoModel
{
    public class Car
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Brand { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
