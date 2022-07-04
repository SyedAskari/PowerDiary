import {  useState } from "react";
import {
    getChatRoomEventsByMinutes,
    getChatRoomEventsByHours,
} from "../../services/chatHistoryService";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { ChatRoomEventVm } from "../../Model/ChatRoomEventVm";
import { getChatRoomEventByHoursRows } from "../../utilities/getChatRoomEventByHoursRows";
import { getChatRoomEventByMinutesRows } from "../../utilities/getChatRoomEventByMinutesRows";
import { getRandomInt } from "../../utilities/getRandomInt";
import styles from "./ChatHistory.module.css";
import useAsyncEffect from "use-async-effect";
import moment from "moment";

const columns: GridColDef[] = [
    {
        field: "Hour",
        headerName: "Time",
        width: 500,
        sortable: false,
        filterable: false,
        hideable: false,
        disableColumnMenu: true,
    },
    {
        field: "EventDescription",
        headerName: "Event Description",
        width: 500,
        sortable: false,
        filterable: false,
        hideable: false,
        disableColumnMenu: true,
    },
];


const ChatHistory = () => {

    const [chatRoomEventsByMinutesRows, setChatRoomEventsByMinutesRows] = useState<Array<ChatRoomEventVm>>();
    const [chatRoomEventsByHours, setChatRoomEventsByHours] = useState<Array<ChatRoomEventVm>>();
    const chatHistoryDate = moment("2024-01-01 13:50:44.2601056").format("YYYY-MM-DD HH:mm:ss");

    useAsyncEffect(async () => {
        try {
        
            const minutesEvents = await getChatRoomEventsByMinutes(chatHistoryDate);
            const hoursEvents = await getChatRoomEventsByHours(chatHistoryDate);

            if(minutesEvents.length) {
                const minuteRows = getChatRoomEventByMinutesRows(minutesEvents);
                setChatRoomEventsByMinutesRows(minuteRows);
            }

            if(hoursEvents.length) {
                const hoursRows = getChatRoomEventByHoursRows(hoursEvents);
                setChatRoomEventsByHours(hoursRows);
            }

        } catch (error: unknown) {
            console.log("An error has occured", error)
        }

    }, []);

    return (
        <>
            <div className={styles.gridlayout}>
            <h3>Chat History Data Aggregation by Minutes</h3>
            {chatRoomEventsByMinutesRows?.length ? (
                <DataGrid
                    getRowId={() => getRandomInt(50000)}
                    rows={chatRoomEventsByMinutesRows}
                    columns={columns}
                    rowHeight={25}
                />
            ) : null}
            </div>
            <div className={styles.gridlayout}>
            <h3>Chat History Data Aggregation by Hours</h3>
            {chatRoomEventsByHours?.length ? (
                <DataGrid
                    getRowId={() => getRandomInt(50000)}
                    rows={chatRoomEventsByHours}
                    columns={columns}
                    rowHeight={25}
                />
            ) : null}
            </div>         
        </>
    );
};

export default ChatHistory;

