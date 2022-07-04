using PowerDiary.ChatHistory.Domain.Entities;

namespace PowerDiary.ChatHistory.Application.Contracts.Persistance
{
    public interface IChatRoomEventRepository
    {
        Task<List<ChatRoomEvent>> GetChatRoomEventsByDay(DateTime date);
    }
}
