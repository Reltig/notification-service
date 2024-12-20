﻿using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BaseMicroservice.Middlewares;

public class TraceIdMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = Activity.Current?.TraceId.ToString() ?? "no-trace-id";
        context.Response.Headers.Append("X-Trace-Id", traceId);
        await next(context);
    }
}