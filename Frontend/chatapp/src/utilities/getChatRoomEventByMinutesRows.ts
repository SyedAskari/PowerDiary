import { ChatRoomEventVm } from "../Model/ChatRoomEventVm";
import { ChatRoomMinutesEvent } from "../Model/ChatRoomMinutesEvent";
import { EventType } from "../Enum/EventTypes";
import moment from "moment";

export const getChatRoomEventByMinutesRows = (chatRoomEventsByMinutes: Array<ChatRoomMinutesEvent>): Array<ChatRoomEventVm> => {

    let eventRows: Array<ChatRoomEventVm> = [];
    chatRoomEventsByMinutes.forEach((event) => {

        let row: ChatRoomEventVm = {
            Hour: moment(event.timeStamp).format('h:mm A'),
            EventDescription: "",
        };

        if (event.eventType === EventType.Enter) {
            row.EventDescription = `${event.eventSenderName} enters the room`;
        }

        if (event.eventType === EventType.Leave) {
            row.EventDescription = `${event.eventSenderName} leaves`;
        }

        if (event.eventType === EventType.Comment) {
            row.EventDescription = `${event.eventSenderName} comments: "${event.eventDetails}"`;
        }

        if (event.eventType === EventType.HighFive) {
            row.EventDescription = `${event.eventSenderName} high-fives ${event.eventReceiverName}`;
        }

        eventRows.push(row);
    });

    return eventRows;
};
