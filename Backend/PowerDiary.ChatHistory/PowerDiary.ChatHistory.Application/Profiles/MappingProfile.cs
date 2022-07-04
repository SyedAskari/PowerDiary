using AutoMapper;
using PowerDiary.ChatHistory.Application.Features.ChatRoom;
using PowerDiary.ChatHistory.Domain.Entities;

namespace PowerDiary.ChatHistory.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ChatRoomEvent, ChatRoomEventMinutesVm>()
                .ForMember(destination => destination.EventType, option => option.MapFrom(source => source.EventId))
                .ForMember(destination => destination.EventSenderName, option => option.MapFrom(source => source.Sender.Name))
                .ForMember(destination => destination.EventReceiverName, option => option.MapFrom(source => source.Receiver.Name))
                .ReverseMap();
        }
    }
}
