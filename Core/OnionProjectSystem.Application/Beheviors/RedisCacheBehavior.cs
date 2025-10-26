using MediatR;
using OnionProjectSystem.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Beheviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService _redisCacheService;
        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cacheData = await _redisCacheService.GetAsync<TResponse>(cacheKey);

                if (cacheData is not null)
                {
                    return cacheData;
                }
                var response =await next();

                if (response is not null)
                {
                    await _redisCacheService.SetAsync(cacheKey, response, DateTime.UtcNow.AddMinutes(cacheTime));
                }
                return response;
            }
            return await next();
        }
    }
}
