using Moq;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PowerDiary.ChatHistory.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {

        public static Mock<IChatRoomEventRepository> GetCategoryRepository()
        {
         
            var snow = new User { Id = 1, Name = "Snow" };
            var jermy = new User { Id = 2, Name = "Jermy" };

            var enter = new Event { Id = 1, Description = "Enter" };
            var leave = new Event { Id = 2, Description = "Leave" };
            var comment = new Event { Id = 3, Description = "Comment" };
            var highFive = new Event { Id = 4, Description = "High-Five" };


            var chatRoomEvents = new List<ChatRoomEvent>
            {
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    Event = enter,                   
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,                 
                },
                new ChatRoomEvent
                {
                    Id = 2,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 12, 20),
                    Event = enter,
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 15, 20),
                    Event = comment,
                    EventId = comment.Id,
                    EventDetails = "Hi Snow - How are you",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 15, 20),
                    Event = comment,
                    EventId = comment.Id,
                    EventDetails = "Hi Jermy - I am good",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = jermy,
                    ReceiverId = jermy.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 16, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 18, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = jermy,
                    ReceiverId = jermy.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 18, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 19, 20),
                    Event = leave,
                    EventId = leave.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 20, 20),
                    Event = leave,
                    EventId = leave.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 10, 20),
                    Event = enter,
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 2,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 12, 20),
                    Event = enter,
                    EventId = enter.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 15, 20),
                    Event = comment,
                    EventId = comment.Id,
                    EventDetails = "Hi Snow - How are you",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 15, 20),
                    Event = comment,
                    EventId = comment.Id,
                    EventDetails = "Hi Jermy - I am good",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = jermy,
                    ReceiverId = jermy.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 16, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 18, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = jermy,
                    ReceiverId = jermy.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 18, 20),
                    Event = highFive,
                    EventId = highFive.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = snow,
                    ReceiverId = snow.Id,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 19, 20),
                    Event = leave,
                    EventId = leave.Id,
                    EventDetails = "",
                    Sender = jermy,
                    SenderId = jermy.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 5, 20, 20),
                    Event = leave,
                    EventId = leave.Id,
                    EventDetails = "",
                    Sender = snow,
                    SenderId = snow.Id,
                    Receiver = null,
                    ReceiverId = null,
                },
            };

            var mockChatRoomRepository = new Mock<IChatRoomEventRepository>();
            mockChatRoomRepository.Setup(repo => repo.GetChatRoomEventsByDay(It.IsAny<DateTime>())).ReturnsAsync(chatRoomEvents);

            return mockChatRoomRepository;
        }

    }
}
