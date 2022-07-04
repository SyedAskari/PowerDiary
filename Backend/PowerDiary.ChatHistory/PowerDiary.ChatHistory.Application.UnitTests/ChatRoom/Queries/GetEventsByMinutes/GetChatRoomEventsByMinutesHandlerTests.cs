using AutoMapper;
using FluentAssertions;
using Moq;
using PowerDiary.ChatHistory.Application.Contracts.Persistance;
using PowerDiary.ChatHistory.Application.Features.ChatRoom;
using PowerDiary.ChatHistory.Application.Profiles;
using PowerDiary.ChatHistory.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PowerDiary.ChatHistory.Application.UnitTests.ChatRoom.Queries.GetEventsByMinutes
{
    public class GetChatRoomEventsByMinutesHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IChatRoomEventRepository> _mockChatRoomEventRepository;

        public GetChatRoomEventsByMinutesHandlerTests()
        {
            _mockChatRoomEventRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetChatRoomEventsByMinutesTest()
        {
            var handler = new GetChatRoomEventsByMinutesHandler(_mockChatRoomEventRepository.Object, _mapper);
            var getChatRoomEventsByMinutesQuery = new GetChatRoomEventsByMinutesQuery
            {
                Date = new DateTime(2024, 01, 01, 1, 10, 20)
            };

            var result = await handler.Handle(getChatRoomEventsByMinutesQuery, CancellationToken.None);

            result.Should().BeOfType<List<ChatRoomEventMinutesVm>>();
            result.Should().HaveCount(18);
        }
    }
}
