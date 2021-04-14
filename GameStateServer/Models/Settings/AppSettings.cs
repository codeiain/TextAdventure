
namespace GameStateServer.Models.Settings
{
    public class AppSettings
    {
        public AppSettings()
        {
            MongoSettings = new MongoSettings();

        }

        public MongoSettings MongoSettings { get; set; }

        
        public string CartridgeLocation { get; set; }
    }
}