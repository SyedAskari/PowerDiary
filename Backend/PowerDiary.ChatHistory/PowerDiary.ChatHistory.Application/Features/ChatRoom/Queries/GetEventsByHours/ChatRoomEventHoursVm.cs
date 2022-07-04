using PowerDiary.ChatHistory.Application.Features.ChatRoom.Queries.GetEventsByHours;

namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class ChatRoomEventHoursVm
    {
        public int Hour { get; set; }
        public int TotalEntered { get; set; }
        public int TotalLeft { get; set; }
        public int TotalComments { get; set; }
        public List<HighFiveDto> HighFive {get; set;}
    }
}
