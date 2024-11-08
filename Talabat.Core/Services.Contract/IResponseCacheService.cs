using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Services.Contract
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object Response, TimeSpan ExpireTime);

        Task<string?> GetCachedResponse(string cacheKey);
    }
}
