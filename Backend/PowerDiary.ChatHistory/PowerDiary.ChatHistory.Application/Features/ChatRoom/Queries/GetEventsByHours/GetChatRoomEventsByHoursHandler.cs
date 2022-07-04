using MediatR;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Application.Enums;
using PowerDiary.ChatHistory.Application.Exceptions;
using PowerDiary.ChatHistory.Application.Features.ChatRoom.Queries.GetEventsByHours;
using PowerDiary.ChatHistory.Domain.Entities;

namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class GetChatRoomEventsByHoursHandler : IRequestHandler<GetChatRoomEventsByHoursQuery, List<ChatRoomEventHoursVm>>
    {
        private readonly IChatRoomEventRepository _chatRoomEventRepository;

        public GetChatRoomEventsByHoursHandler(IChatRoomEventRepository chatRoomEventRepository)
        {
            _chatRoomEventRepository = chatRoomEventRepository;
        }

        public async Task<List<ChatRoomEventHoursVm>> Handle(GetChatRoomEventsByHoursQuery request, CancellationToken cancellationToken)
        {
            var events = await _chatRoomEventRepository.GetChatRoomEventsByDay(request.Date);

            if (events.Count == 0)
            {
                throw new NotFoundException(nameof(request.Date), request.Date);
            }

            var chatRoomEventsByHours = AggregateEventsByHours(events);
            return chatRoomEventsByHours;
        }

        private List<ChatRoomEventHoursVm> AggregateEventsByHours(List<ChatRoomEvent> chatRoomEvents)
        {
            var chatRoomEventHoursVm = chatRoomEvents
                .OrderBy(chatRoomEvent => chatRoomEvent.TimeStamp.Hour)
                .GroupBy(chatRoomEvent => chatRoomEvent.TimeStamp.Hour)
                .Select(group => new ChatRoomEventHoursVm
                {
                    Hour = group.Key,
                    TotalEntered = group.Count(e => e.EventId == (int)EventType.Enter),
                    TotalLeft = group.Count(e => e.EventId == (int)EventType.Leave),
                    TotalComments = group.Count(e => e.EventId == (int)EventType.Comment),
                    HighFive = AggregateHighFive(group)
                });

            return chatRoomEventHoursVm.ToList();
        }

        private static List<HighFiveDto> AggregateHighFive(IGrouping<int, ChatRoomEvent> group)
        {
            return group.Where(e => e.EventId == (int)EventType.HighFive)
                        .GroupBy(g => g.SenderId)
                        .Select(g => new HighFiveDto()
                        {
                            HighFiveSent = g.Count(),
                            SenderId = g.Key
                        }).ToList();
        }
    }
}
