using MongoDB.Driver;

namespace Knight.API.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;
        public MongoDbService(IConfiguration configuration)
        {
            _configuration = configuration;
                        
            var uri = _configuration.GetConnectionString("DbConnection");
            var client = new MongoClient(uri);
            _database = client.GetDatabase(new MongoUrl(uri).DatabaseName);
        }

        public IMongoDatabase? Database => _database;
    }
}
