namespace PowerDiary.ChatHistory.Application.Features.ChatRoom
{
    public class ChatRoomEventMinutesVm
    {
        public DateTime TimeStamp { get; set; }
        public int EventType { get; set; }
        public string? EventDetails { get; set; }
        public string EventSenderName { get; set; }
        public string? EventReceiverName { get; set; }

    }
}
