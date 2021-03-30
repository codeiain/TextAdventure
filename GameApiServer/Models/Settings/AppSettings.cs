
namespace GameApiServer.Models.Settings
{
    public class AppSettings
    {
        public AppSettings()
        {
            MongoSettings = new MongoSettings();
            RedisSettings = new RedisSettings();
        }

        public MongoSettings MongoSettings { get; set; }
        public RedisSettings RedisSettings { get; set; }
        
        public string GameServerAddress { get; set; }
    }
}