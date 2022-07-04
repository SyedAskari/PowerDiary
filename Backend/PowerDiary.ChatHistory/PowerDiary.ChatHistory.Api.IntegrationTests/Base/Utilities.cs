using PowerDiary.ChatHistory.Domain.Entities;
using PowerDiary.ChatHistory.Persistance;
using System;
using System.Collections.Generic;

namespace PowerDiary.ChatHistory.Api.IntegrationTests.Base
{
    public class Utilities
    {
         public static void InitializeDbForTests(ChatAppDbContext chatAppDbContext)
        {
            var snow = new User { Id = 1, Name = "Snow" };
            var jermy = new User { Id =2, Name = "Jermy" };

            var enter = new Event { Id= 1,  Description = "Enter" };
            var leave = new Event { Id =2, Description = "Leave" };
            var comment = new Event { Id = 3, Description = "Comment" };
            var highFive = new Event { Id = 4,   Description = "High-Five" };


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
                    Id = 3,
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
                    Id = 4,
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
                    Id = 5,
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
                    Id = 6,
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
                    Id = 7,
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
                    Id = 8,
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
                    Id = 9,
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
                    Id = 10,
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
                    Id = 11,
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
                    Id = 12,
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
                    Id = 13,
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
                    Id = 14,
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
                    Id = 15,
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
                    Id = 16,
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
                    Id = 17,
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
                    Id = 18,
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

            chatAppDbContext.AddRange(chatRoomEvents);
            chatAppDbContext.SaveChanges();
        }
    }
}
