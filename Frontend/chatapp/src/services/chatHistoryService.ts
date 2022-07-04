import { ChatRoomMinutesEvent } from "../Model/ChatRoomMinutesEvent";

const url = "https://localhost:7112/api/ChatRoomEvent/";

export async function getChatRoomEventsByMinutes(date: string): Promise<Array<ChatRoomMinutesEvent>> {

    const getChatRoomEventsByMinutesUrl = `${url}getChatRoomEventsByMinutes?date=${date}`;

    const response = await fetch(getChatRoomEventsByMinutesUrl, {
        method: "GET",
        headers: {"Content-Type": "application/json"}
    });

    if(response.ok) return response.json();
    throw response;
}

export async function getChatRoomEventsByHours(date: string): Promise<any> {
    const getChatRoomEventsByHours = `${url}getChatRoomEventsByHours?date=${date}`;
    
    const response = await fetch(getChatRoomEventsByHours, {
        method: "GET",
        headers: {"Content-Type": "application/json"}
    });

    if(response.ok) return response.json();

    throw response;
}