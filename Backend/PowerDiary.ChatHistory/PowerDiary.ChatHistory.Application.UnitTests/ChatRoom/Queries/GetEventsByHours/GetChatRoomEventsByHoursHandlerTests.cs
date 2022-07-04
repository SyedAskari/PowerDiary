using FluentAssertions;
using Moq;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Application.Features.ChatRoom;
using PowerDiary.ChatHistory.Application.Features.ChatRoom.Queries.GetEventsByHours;
using PowerDiary.ChatHistory.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PowerDiary.ChatHistory.Application.UnitTests.ChatRoom.Queries.GetEventsByHours
{
    public class GetChatRoomEventsByHoursHandlerTests
    {
        private readonly Mock<IChatRoomEventRepository> _chatRoomEventRepository;
        public GetChatRoomEventsByHoursHandlerTests()
        {
            _chatRoomEventRepository = RepositoryMocks.GetCategoryRepository();
        }

        [Fact]
        public async Task GetChatRoomEventsByHoursTest()
        {
            var handler = new GetChatRoomEventsByHoursHandler(_chatRoomEventRepository.Object);
            var getChatRoomEventsByHourQuery = new GetChatRoomEventsByHoursQuery { Date = DateTime.Now };

            var expectedResult = new List<ChatRoomEventHoursVm>
            {
                new ChatRoomEventHoursVm 
                {
                    Hour = 1,
                    TotalComments = 2,
                    TotalEntered = 2,
                    TotalLeft = 2,
                    HighFive = new List<HighFiveDto>
                    {
                        new HighFiveDto
                        {
                            HighFiveSent = 1,
                            SenderId = 1,
                        },
                        new HighFiveDto
                        {
                            HighFiveSent = 2,
                            SenderId= 2,
                        }
                    }
                },
                new ChatRoomEventHoursVm 
                {
                    Hour = 5,
                    TotalComments = 2,
                    TotalEntered = 2,
                    TotalLeft = 2,
                    HighFive = new List<HighFiveDto>
                    {
                        new HighFiveDto
                        {
                            HighFiveSent = 1,
                            SenderId = 1,
                        },
                        new HighFiveDto
                        {
                            HighFiveSent = 2,
                            SenderId= 2,
                        }
                    }
                },
            };

            var result = await handler.Handle(getChatRoomEventsByHourQuery, CancellationToken.None);

            result.Should().BeOfType<List<ChatRoomEventHoursVm>>();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
