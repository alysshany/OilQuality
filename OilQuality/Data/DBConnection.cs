using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace OilQuality.Data
{
    public class DBConnection
    {
        public static void AddToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            collection.InsertOne(user);
        }

        public static void DeleteUserFromDataBase(User userData)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var user = collection.DeleteOne(x => x == userData);
        }

        public static void AddTaskToDataBase(Task task)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Task>("CollectionOfTasks");
            collection.InsertOne(task);
        }

        public static void AddEquipmentToDataBase(Equipment equipment)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Equipment>("CollectionOfEquipments");
            collection.InsertOne(equipment);
        }

        public static void DeleteEquipmnetFromDataBase(Equipment equipment)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Equipment>("CollectionOfEquipments");
            var user = collection.DeleteOne(x => x == equipment);
        }

        public static void DeleteAnalyzeFromDataBase(Analyze analyze)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            var user = collection.DeleteOne(x => x.Title == analyze.Title);
        }

        public static void AddAnalyzeToDataBase(Analyze analyze)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            collection.InsertOne(analyze);
        }

        public static Analyze FindAnalyzeByTitle(string title)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            var analyze = collection.Find(x => x.Title == title).FirstOrDefault();
            return analyze;
        }

        public static Equipment FindEquipmentByTitle(string title)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Equipment>("CollectionOfEquipments");
            var equipment = collection.Find(x => x.Title == title).FirstOrDefault();
            return equipment;
        }

        public static User FindUserByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }

        public static List<User> ImportAllWorkersWithoutAdmin()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName != "Администратор").ToList();
            return list;
        }

        public static List<User> ImportOnlyWorkers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName == "Лаборант").ToList();
            return list;
        }

        public static List<User> ImportOnlyManagers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName == "Заведующий").ToList();
            return list;
        }

        public static List<User> ImportOnlyAdmins()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName == "Администратор").ToList();
            return list;
        }

        public static List<User> ImportAllLabWorkers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName == "Лаборант").ToList();
            return list;
        }

        public static List<Equipment> ImportAllEquipments()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Equipment>("CollectionOfEquipments");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static List<Task> ImportTasksOfWorker(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Task>("CollectionOfTasks");
            var list = collection.Find(x => (x.Worker.Login == user.Login) && (x.isDone == false)).ToList();
            return list;
        }

        public static List<Analyze> ImportOnlyApplications()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == false)).ToList();
            return list;
        }

        public static List<Analyze> ImportOnlyAnalyzes()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == true)).ToList();
            return list;
        }

        public static List<Analyze> ImportOnlyAnalyzesOfWorker(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == true) && (x.WorkerData == user)).ToList();
            return list;
        }

        public static void ReplaceUser(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var filter = new BsonDocument("_id", user.Id);
            var collection = database.GetCollection<User>("CollectionOfUsers");
            collection.ReplaceOne(filter, user);
        }

        public static void ReplaceTask(Task task)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var filter = new BsonDocument("_id", task.Id);
            var collection = database.GetCollection<Task>("CollectionOfTasks");
            collection.ReplaceOne(filter, task);
        }

        public static void ReplaceAnalyze(Analyze analyze)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OilQuality");
            var filter = new BsonDocument("_id", analyze.Id);
            var collection = database.GetCollection<Analyze>("CollectionOfAnalyzes");
            collection.ReplaceOne(filter, analyze);
        }
    }
}
