using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerDiary.ChatHistory.Application.Features.ChatRoom;

namespace PowerDiary.ChatHistory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomEventController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatRoomEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getChatRoomEventsByMinutes", Name = "GetChatRoomEventsByMinutes")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ChatRoomEventMinutesVm>>> GetChatRoomEventsByMinutes(DateTime date)
        {
            var getChatRoomEventsByMinutesQuery = new GetChatRoomEventsByMinutesQuery
            { 
                Date = date
            };
            var chatRoomEventVm = await _mediator.Send(getChatRoomEventsByMinutesQuery);
            return Ok(chatRoomEventVm);
        }

        [HttpGet("getChatRoomEventsByHours", Name = "GetChatRoomEventsByHours")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ChatRoomEventHoursVm>>> GetChatRoomEventsByHours(DateTime date)
        {
            var getChatRoomEventsByHoursQuery = new GetChatRoomEventsByHoursQuery
            {
                Date = date
            };
            var chatRoomEventVm = await _mediator.Send(getChatRoomEventsByHoursQuery);
            return Ok(chatRoomEventVm);
        }
    }
}
