using AutoMapper;
using MediatR;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Application.Exceptions;

namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class GetChatRoomEventsByMinutesHandler : IRequestHandler<GetChatRoomEventsByMinutesQuery, List<ChatRoomEventMinutesVm>>
    {
        private readonly IChatRoomEventRepository _chatRoomEventRepository;
        private readonly IMapper _mapper;
        public GetChatRoomEventsByMinutesHandler(IChatRoomEventRepository chatRoomEventRepository, IMapper mapper)
        {
            _chatRoomEventRepository = chatRoomEventRepository;
            _mapper = mapper;
        }
        public async Task<List<ChatRoomEventMinutesVm>> Handle(GetChatRoomEventsByMinutesQuery request, CancellationToken cancellationToken)
        {
            var events = await _chatRoomEventRepository.GetChatRoomEventsByDay(request.Date);

            if(events.Count == 0)
            {
                throw new NotFoundException(nameof(request.Date), request.Date);
            }

            var chatRoomEventsByMinutes = events.OrderBy(chatRoomEvent => chatRoomEvent.TimeStamp);
            return _mapper.Map<List<ChatRoomEventMinutesVm>>(chatRoomEventsByMinutes);
        }
    }
}
