namespace PowerDiary.ChatHistory.Domain.Entities
{
    public class ChatRoomEvent
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? EventDetails { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }

    }
}
