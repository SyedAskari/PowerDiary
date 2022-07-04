using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Persistance.Repositories;

namespace PowerDiary.ChatHistory.Persistance
{
    public static class PersistanceServiceCollection
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatAppDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("PowerDiaryChatAppDatabaseConnectionString"));
            });

            services.AddScoped<IChatRoomEventRepository, ChatRoomEventRepository>();

            return services;
        }
    }
}
