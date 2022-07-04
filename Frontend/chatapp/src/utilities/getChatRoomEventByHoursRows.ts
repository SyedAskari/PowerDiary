import { HighFive } from './../Model/HighFive';
import { ChatRoomEventVm } from "../Model/ChatRoomEventVm";
import { ChatRoomHoursEvent } from "../Model/ChatRoomHoursEvent";
import { convertTime } from "./convertTime";

export const getChatRoomEventByHoursRows = (chatRoomEventsByMinutes: Array<ChatRoomHoursEvent>): Array<ChatRoomEventVm> => {

    let eventRows: Array<ChatRoomEventVm> = [];

    chatRoomEventsByMinutes.forEach((event) => {

        let eventRowsPerEvent: Array<ChatRoomEventVm> = [];
        let aggregatedHour = convertTime(event.hour);

        if (event.totalEntered > 0) {
            eventRowsPerEvent.push({ EventDescription: `${event.totalEntered} entered` });
        }

        if (event.totalLeft > 0) {
            eventRowsPerEvent.push({ EventDescription: `${event.totalLeft} left` });
        }

        if (event.totalComments > 0) {
            eventRowsPerEvent.push({ EventDescription: `${event.totalComments} comments` });
        }

        if (event.highFive.length) {
            event.highFive.forEach((highFive: HighFive) => {
                eventRowsPerEvent.push({ EventDescription: `1 person high-fived ${highFive.highFiveSent} other people` });
            });
        }

        if(eventRowsPerEvent.length) {
            eventRowsPerEvent[0].Hour = aggregatedHour;
        }
        eventRows.push(...eventRowsPerEvent);
    });

    return eventRows;
};
