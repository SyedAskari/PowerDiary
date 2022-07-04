using MediatR;

namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class GetChatRoomEventsByHoursQuery: IRequest<List<ChatRoomEventHoursVm>>
    {
        public DateTime Date { get; set; }
    }
}
