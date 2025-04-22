using MediatR;
using OnionArc.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Beheviors;

public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IRedisCacheService redisCacheService;

    public RedisCacheBehevior(IRedisCacheService redisCacheService)
    {
        this.redisCacheService = redisCacheService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ICacheableQuery cacheableQuery)
        {
            string cacheKey = cacheableQuery.CacheKey;
            double cacheTime = cacheableQuery.CacheTime;

            var cacheData = await redisCacheService.GetAsync<TResponse>(cacheKey);
            if (cacheData != null)
            {
                return cacheData;
            }

            var response = await next();
            if (response != null)
            {
                await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
            }

            return response;
        }

        return await next();
    }
}
