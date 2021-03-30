using System;
using CacheServer.Models.Settings;
using ServiceStack.Redis;

namespace CacheServer
{
    public class RedisCacheProvider : ICacheProvider
    {

        private readonly AppSettings _config;
        RedisEndpoint _endPoint;

        public RedisCacheProvider(AppSettings config)
        {
            _config = config;
            _endPoint = new RedisEndpoint(_config.RedisSettings.Host, int.Parse(_config.RedisSettings.Port), _config.RedisSettings.Password, long.Parse(_config.RedisSettings.DatabaseID));
        }

        public void Set<T>(string key, T value)
        {
            this.Set(key, value, TimeSpan.Zero);
        }

        public void Set<T>(string key, T value, TimeSpan timeout)
        {
            using (RedisClient client = new RedisClient(_endPoint))
            {
                client.As<T>().SetValue(key, value, timeout);
            }
        }

        public T Get<T>(string key)
        {
            T result = default(T);

            using (RedisClient client = new RedisClient(_endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }

        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }

        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
    }
}