using Microsoft.EntityFrameworkCore;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Domain.Entities;

namespace PowerDiary.ChatHistory.Persistance.Repositories
{
    public class ChatRoomEventRepository : IChatRoomEventRepository
    {
        private readonly ChatAppDbContext _chatAppDbContext;
        public ChatRoomEventRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }
        public async Task<List<ChatRoomEvent>> GetChatRoomEventsByDay(DateTime date)
        {
            var chatRoomEvents = await _chatAppDbContext.ChatRoomEvents
                .AsNoTracking()
                .Where(e => e.TimeStamp.Day == date.Day)
                .Where(e => e.TimeStamp.Year == date.Year )
                .Where(e => e.TimeStamp.Month == date.Month)
                .Include(chatRoomEvent => chatRoomEvent.Sender)
                .Include(chatRoomEvent => chatRoomEvent.Receiver)
                .ToListAsync();

            return chatRoomEvents;
        }
    }
}
