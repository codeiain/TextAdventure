using System;
using System.IO;
using GameServer.Models;
using GameServer.Models.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GameServer.Services
{
    public class CartridgeService : ICartridgeService
    {
        private AppSettings _config;
        private IHostingEnvironment _env;
        
        public CartridgeService(IOptions<AppSettings> config, IHostingEnvironment env)
        {
            _config = config.Value;
            _env = env;
        }

        public Root GetCartridge(string fileName)
        {
            var webRoot = _env.WebRootPath;
            var file = System.IO.Path.Combine(_config.CartridgeLocation, fileName);
            string json = File.ReadAllText(file);
            Root jsonObject = JsonConvert.DeserializeObject<Root>(json);
            return jsonObject;
        }
    }
}