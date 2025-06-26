﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Services.Contract;

namespace Talabat.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheService(IConnectionMultiplexer Redis)
        {
            _database = Redis.GetDatabase();
        }
        public async Task CacheResponseAsync(string cacheKey, object Response, TimeSpan ExpireTime)
        {
            if (Response is null) return;

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            var serializedResponse = JsonSerializer.Serialize(Response, options);

            await _database.StringSetAsync(cacheKey, serializedResponse, ExpireTime);
        }

        public async Task<string?> GetCachedResponse(string cacheKey)
        {
            var cacheResponse = await _database.StringGetAsync(cacheKey);

            if(cacheResponse.IsNullOrEmpty) return null;

            return cacheResponse;
        }
    }
}
