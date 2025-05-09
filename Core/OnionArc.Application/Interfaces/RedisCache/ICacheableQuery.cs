﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Interfaces.RedisCache;

public interface ICacheableQuery
{
    string CacheKey { get; }
    double CacheTime { get; }
}
