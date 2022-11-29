using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbTest.MongoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*• Anlatım => https://www.youtube.com/watch?v=-AXT-UCthEU
	
	• Kurulum => https://www.mongodb.com/try/download/community
	• Sql management gibi Robo3T => https://studio3t.com/ veya mongo db nin compass arayüzü de aynı işi görüyor
	• Mongo db yi ister localden kullanabilirsin, istersen mongo db atlas(cloud) a hesap açarakta db ni cloudda tutarak kullanabilirsin

    cloud a erişim için https://cloud.mongodb.com/ girmen gerek

            Database boyutu 500mb kadar free*/
            MongoTest();
        }

        private static void MongoTest()
        {
            //mongo nun cloud unda database im saklanıyor. cloud a erişim için https://cloud.mongodb.com/ girmen gerek
            //mongoyu localde de saklayabilirsin
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://rpaycin:Resit1985@cluster0.istmlgq.mongodb.net/?retryWrites=true&w=majority");

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);

            //database e erişiyoruz
            var database = client.GetDatabase("CarPark");

            //tabloya erişim yapıyoruz
            var carCollection = database.GetCollection<Car>("Car");

            //tabloya kayıt atıyoruz
            var car = new Car
            {
                _id = ObjectId.GenerateNewId(),
                Brand = "Mercedes",
                Users = new List<User>
                {
                    new User
                    {
                        Age=38,
                        Name="Reşit"
                    }
                }
            };

            carCollection.InsertOne(car);
        }
    }
}
