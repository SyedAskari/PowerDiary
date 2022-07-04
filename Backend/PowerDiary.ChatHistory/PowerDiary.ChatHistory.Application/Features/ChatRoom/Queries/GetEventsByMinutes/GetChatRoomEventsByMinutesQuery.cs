using MediatR;

namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class GetChatRoomEventsByMinutesQuery: IRequest<List<ChatRoomEventMinutesVm>>
    {
        public DateTime Date { get; set; }
    }
}
