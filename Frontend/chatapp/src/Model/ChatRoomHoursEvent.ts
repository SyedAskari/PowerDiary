import { HighFive } from "./HighFive";

export interface ChatRoomHoursEvent {
    hour: number;
    totalEntered: number;
    totalLeft : number;
    totalComments: number;
    highFive: Array<HighFive>;
}