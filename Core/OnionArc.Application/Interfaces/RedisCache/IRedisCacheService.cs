using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Interfaces.RedisCache;

public interface IRedisCacheService
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, DateTime? expiration = null);
    //Task RemoveAsync(string key);
    //Task<bool> ExistsAsync(string key);
    //Task<IEnumerable<string>> GetKeysAsync(string pattern);
    //Task ClearCacheAsync();
}
