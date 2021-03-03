using MongoDB.Driver;

namespace CustomerApp.Test.Util
{
    public static class DropDataBase
    {
        public static void Drop() => Drop(Config.DatabaseName);
        public static void Drop(string name)
        {
            var database = new MongoClient(Config.ConnectionString);
            database.DropDatabase(name);    
        }

    }
}
