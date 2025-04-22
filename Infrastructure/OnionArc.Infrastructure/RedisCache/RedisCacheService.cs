using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionArc.Application.Interfaces.RedisCache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Infrastructure.RedisCache;

public class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer redisConnection;
    private readonly IDatabase database;
    private readonly RedisCacheSettings settings;

    public RedisCacheService(IOptions<RedisCacheSettings> options)
    {     
        this.settings = options.Value;
        ConfigurationOptions opt = ConfigurationOptions.Parse(settings.ConnectionString);
        redisConnection = ConnectionMultiplexer.Connect(opt);
        database = redisConnection.GetDatabase();
    }

    public async Task<T> GetAsync<T>(string key)
    {
        RedisValue value = await database.StringGetAsync(key);

        if (value.HasValue)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        return default(T);
    }

    public async Task SetAsync<T>(string key, T value, DateTime? expiration = null)
    {
        TimeSpan timeUnitExpiration = expiration.HasValue ? expiration.Value - DateTime.Now : TimeSpan.FromMinutes(5);

        await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration); 
    }
}
