﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PowerDiary.ChatHistory.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
