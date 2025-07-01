using FirstConnectToAtlat.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FirstConnectToAtlat.Models;

namespace FirstConnectToAtlat.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var mongoclient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongodatabase = mongoclient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _userCollection = mongodatabase.GetCollection<User>(mongoDbSettings.Value.UserCollectionName);
        }
        public async Task<List<User>> GetAllUsers()
        {
         var users = await _userCollection.Find(_ => true).ToListAsync();
            return users;
        }

        public async Task<User?> GetByEmail(string email)
        {
           var user= await _userCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
            return user;
        }
        public async Task CreateNewUser(User newuser)
        {       
            await _userCollection.InsertOneAsync(newuser);
        }
    }
}
