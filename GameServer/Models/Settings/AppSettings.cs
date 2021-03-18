
namespace GameServer.Models.Settings
{
    public class AppSettings
    {
        public AppSettings()
        {
            MongoSettingsDb = new MongoSettings();
            RedisSettings = new RedisSettings();
        }

        public MongoSettings MongoSettingsDb { get; set; }
        public RedisSettings RedisSettings { get; set; }
    }
}