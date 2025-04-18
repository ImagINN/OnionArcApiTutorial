﻿using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Interfaces.AutoMapper;

namespace OnionArc.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
}
