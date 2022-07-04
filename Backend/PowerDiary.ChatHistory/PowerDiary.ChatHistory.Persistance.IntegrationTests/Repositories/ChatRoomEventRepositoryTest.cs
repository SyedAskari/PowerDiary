using Microsoft.EntityFrameworkCore;
using PowerDiary.ChatHistory.Domain.Entities;
using PowerDiary.ChatHistory.Persistance.Repositories;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerDiary.ChatHistory.Persistance.IntegrationTests.Repositories
{
    public class ChatRoomEventRepositoryTest
    {
        private readonly ChatAppDbContext _chatAppDbContext;
        public ChatRoomEventRepositoryTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ChatAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _chatAppDbContext = new ChatAppDbContext(dbContextOptions);
        }

        [Fact]
        public async void GetChatRoomEventsByDay_Returns_AllEventsForThatDay()
        {
            var snow = new User { Id = 1, Name = "Snow" };
            var jermy = new User { Id = 2, Name = "Jermy" };

            var enter = new Event { Id = 1, Description = "Enter" };

            var dateOneChatRoomEvents = new List<ChatRoomEvent>
            {
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,
                }
            };

            var dateTwoChatRoomEvents = new List<ChatRoomEvent>
            {
                new ChatRoomEvent
                {
                    Id = 2,
                    TimeStamp = new DateTime(2024, 01, 02, 1, 12, 20),
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 3,
                    TimeStamp = new DateTime(2024, 01, 02, 1, 12, 20),
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
            };

            var chatRoomEventRepository = new ChatRoomEventRepository(_chatAppDbContext);
            var dateOne = new DateTime(2024, 01, 01, 1, 10, 20);
            var dateTwo = new DateTime(2024, 01, 02, 1, 12, 20);

            _chatAppDbContext.ChatRoomEvents.AddRange(dateOneChatRoomEvents);
            _chatAppDbContext.ChatRoomEvents.AddRange(dateTwoChatRoomEvents);
            _chatAppDbContext.SaveChanges();

            var eventsReturnedForDateOne = await chatRoomEventRepository.GetChatRoomEventsByDay(dateOne);
            var eventsReturnedForDateTwo = await chatRoomEventRepository.GetChatRoomEventsByDay(dateTwo);

            eventsReturnedForDateOne.Should().HaveCount(1);
            eventsReturnedForDateTwo.Should().HaveCount(2);

            eventsReturnedForDateOne.Should().BeEquivalentTo(dateOneChatRoomEvents);
            eventsReturnedForDateTwo.Should().BeEquivalentTo(dateTwoChatRoomEvents);
        }
    }
}
