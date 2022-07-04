using Microsoft.EntityFrameworkCore;
using PowerDiary.ChatHistory.Domain.Entities;

namespace PowerDiary.ChatHistory.Persistance
{
    public class ChatAppDbContext: DbContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ChatRoomEvent> ChatRoomEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatRoomEvent>().HasOne(u => u.Sender);
            modelBuilder.Entity<ChatRoomEvent>().HasOne(u => u.Receiver);


            var ali = new User { Id = 1, Name = "Ali" };
            var snow = new User { Id = 2, Name = "Snow" };
            var harry = new User { Id = 3, Name = "Harry" };
            var anam = new User { Id = 4, Name = "Anam" };
            var vareesha = new User { Id = 5, Name = "Vareesha" };


            var enter = new Event { Id = 1, Description = "Enter" };
            var leave = new Event { Id = 2, Description = "Leave" };
            var comment = new Event { Id = 3, Description = "Comment" };
            var highFive = new Event { Id = 4, Description = "High-Five" };

            List<ChatRoomEvent> chatRoomEnterEvents = GenerateChatRoomEnterEvents(ali, snow, harry, anam, vareesha, enter);
            List<ChatRoomEvent> chatRoomLeaveEvents = GenerateChatRoomLeaveEvents(ali, snow, harry, anam, vareesha, leave);
            List<ChatRoomEvent> chatRoomCommentEvents = GenerateChatRoomCommentEvents(ali, snow, harry, anam, vareesha, comment);
            List<ChatRoomEvent> chatRoomHighFiveEvents = GenerateChatRoomHighFiveEvents(ali, snow, anam, vareesha, highFive);

            modelBuilder.Entity<User>().HasData(ali);
            modelBuilder.Entity<User>().HasData(snow);
            modelBuilder.Entity<User>().HasData(harry);
            modelBuilder.Entity<User>().HasData(anam);
            modelBuilder.Entity<User>().HasData(vareesha);


            modelBuilder.Entity<Event>().HasData(enter);
            modelBuilder.Entity<Event>().HasData(leave);
            modelBuilder.Entity<Event>().HasData(comment);
            modelBuilder.Entity<Event>().HasData(highFive);

            modelBuilder.Entity<ChatRoomEvent>().HasData(chatRoomEnterEvents);
            modelBuilder.Entity<ChatRoomEvent>().HasData(chatRoomLeaveEvents);
            modelBuilder.Entity<ChatRoomEvent>().HasData(chatRoomCommentEvents);
            modelBuilder.Entity<ChatRoomEvent>().HasData(chatRoomHighFiveEvents);
        }

        private static List<ChatRoomEvent> GenerateChatRoomHighFiveEvents(User ali, User snow, User anam, User vareesha, Event highFive)
        {
            return new List<ChatRoomEvent>
            {
                 new ChatRoomEvent
                {
                    Id = 20,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 14, 20),
                    EventId = highFive.Id,
                    SenderId = anam.Id,
                    ReceiverId = ali.Id,
                    EventDetails = ""
                },
                  new ChatRoomEvent
                {
                    Id = 21,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 14, 20),
                    EventId = highFive.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = ali.Id,
                    EventDetails = ""
                },
                   new ChatRoomEvent
                {
                    Id = 22,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 26, 20),
                    EventId = highFive.Id,
                    SenderId = anam.Id,
                    ReceiverId = vareesha.Id,
                    EventDetails = ""
                },
                    new ChatRoomEvent
                {
                    Id = 23,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 20, 20),
                    EventId = highFive.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = anam.Id,
                    EventDetails = ""
                },
                     new ChatRoomEvent
                {
                    Id = 24,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 4, 20),
                    EventId = highFive.Id,
                    SenderId = snow.Id,
                    ReceiverId = anam.Id,
                    EventDetails = ""
                },
                      new ChatRoomEvent
                {
                    Id = 25,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 4, 20),
                    EventId = highFive.Id,
                    SenderId = snow.Id,
                    ReceiverId = vareesha.Id,
                    EventDetails = ""
                },
                       new ChatRoomEvent
                {
                    Id = 26,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 14, 20),
                    EventId = highFive.Id,
                    SenderId = anam.Id,
                    ReceiverId = snow.Id,
                    EventDetails = ""
                },
                      new ChatRoomEvent
                {
                    Id = 27,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 14, 20),
                    EventId = highFive.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = snow.Id,
                    EventDetails = ""
                },
            };
        }

        private static List<ChatRoomEvent> GenerateChatRoomCommentEvents(User ali, User snow, User harry, User anam, User vareesha, Event comment)
        {
            return new List<ChatRoomEvent>
            {
                 new ChatRoomEvent
                {
                    Id = 14,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 20, 20),
                    EventId = comment.Id,
                    SenderId = anam.Id,
                    ReceiverId = vareesha.Id,
                    EventDetails = "Hey - Vareesha how are you"
                },
                  new ChatRoomEvent
                {
                    Id = 15,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 12, 20),
                    EventId = comment.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = anam.Id,
                    EventDetails = "Hey - Anam how are you"
                },
                   new ChatRoomEvent
                {
                    Id = 16,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 10, 20),
                    EventId = comment.Id,
                    SenderId = ali.Id,
                    ReceiverId = harry.Id,
                    EventDetails = "Hey - Harry how are you"
                },
                    new ChatRoomEvent
                {
                    Id = 17,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 15, 20),
                    EventId = comment.Id,
                    SenderId = harry.Id,
                    ReceiverId = ali.Id,
                    EventDetails = "Hey - Ali how are you"
                },
                     new ChatRoomEvent
                {
                    Id = 18,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 20, 20),
                    EventId = comment.Id,
                    SenderId = snow.Id,
                    ReceiverId = ali.Id,
                    EventDetails = "Hey - Ali how are you"
                },
                      new ChatRoomEvent
                {
                    Id = 19,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 22, 20),
                    EventId = comment.Id,
                    SenderId = ali.Id,
                    ReceiverId = snow.Id,
                    EventDetails = "Hey - Snow how are you"
                },
            };
        }

        private static List<ChatRoomEvent> GenerateChatRoomLeaveEvents(User ali, User snow, User harry, User anam, User vareesha, Event leave)
        {
            return new List<ChatRoomEvent>
            {
                new ChatRoomEvent
                {
                    Id = 9,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    EventId = leave.Id,
                    SenderId = anam.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""
                },
                new ChatRoomEvent
                {
                    Id = 10,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    EventId = leave.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""
                },
                new ChatRoomEvent
                {
                    Id = 11,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 30, 20),
                    EventId = leave.Id,
                    SenderId = ali.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""
                },
                new ChatRoomEvent
                {
                    Id = 12,
                    TimeStamp = new DateTime(2024, 01, 01, 4, 10, 20),
                    EventId = leave.Id,
                    SenderId = snow.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""
                },
                new ChatRoomEvent
                {
                    Id = 13,
                    TimeStamp = new DateTime(2024, 01, 01, 4, 10, 20),
                    EventId = leave.Id,
                    SenderId = harry.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""
                }
            };
        }

        private static List<ChatRoomEvent> GenerateChatRoomEnterEvents(User ali, User snow, User harry, User anam, User vareesha, Event enter)
        {
            return new List<ChatRoomEvent>
            {
                new ChatRoomEvent
                {
                    Id = 1,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    EventId = enter.Id,
                    SenderId = anam.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 2,
                    TimeStamp = new DateTime(2024, 01, 01, 1, 10, 20),
                    EventId = enter.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 3,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 10, 20),
                    EventId = enter.Id,
                    SenderId = ali.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 4,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 10, 20),
                    EventId = enter.Id,
                    SenderId = snow.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 5,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 10, 20),
                    EventId = enter.Id,
                    SenderId = harry.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 6,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 12, 20),
                    EventId = enter.Id,
                    SenderId = anam.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 7,
                    TimeStamp = new DateTime(2024, 01, 01, 2, 12, 20),
                    EventId = enter.Id,
                    SenderId = vareesha.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                },
                new ChatRoomEvent
                {
                    Id = 8,
                    TimeStamp = new DateTime(2024, 01, 01, 3, 10, 20),
                    EventId = enter.Id,
                    SenderId = ali.Id,
                    ReceiverId = null,
                    Receiver = null,
                    EventDetails = ""

                }

            };
        }
    }
}
