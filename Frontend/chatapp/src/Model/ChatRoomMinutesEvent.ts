export interface ChatRoomMinutesEvent {
    timeStamp: Date;
    eventType: number;
    eventDetails? : string;
    eventSenderName: string;
    eventReceiverName: string
}