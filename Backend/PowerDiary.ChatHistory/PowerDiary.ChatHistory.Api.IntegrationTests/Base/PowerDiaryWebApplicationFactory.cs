using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PowerDiary.ChatHistory.Domain.Entities;
using PowerDiary.ChatHistory.Persistance;
using System;
using System.Linq;
using System.Net.Http;

namespace PowerDiary.ChatHistory.Api.IntegrationTests.Base
{
    public class PowerDiaryWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                services.AddDbContext<ChatAppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("PowerDiaryDbContextInMemoryTest");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider;
                    var context = scopedService.GetRequiredService<ChatAppDbContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            });

        }

        public HttpClient GetAnonymousClient()
        {
            var  uri = new Uri("https://localhost:7112/api/ChatRoomEvent/");
            var client = CreateClient();

            client.BaseAddress = uri;

            return client;
        }
    }
}
