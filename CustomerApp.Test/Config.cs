
namespace CustomerApp.Test
{
    public static class Config
    {
        public static string ConnectionString { get; } = "mongodb://localhost:27017";

        public static string DatabaseName { get;  } = "CustomerMongoTest";

    }
}
