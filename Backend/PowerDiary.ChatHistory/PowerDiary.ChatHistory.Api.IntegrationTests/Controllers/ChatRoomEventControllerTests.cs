using PowerDiary.ChatHistory.Api.IntegrationTests.Base;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using PowerDiary.ChatHistory.Application.Features.ChatRoom;
using System;
using System.Globalization;

namespace PowerDiary.ChatHistory.Api.IntegrationTests.Controllers
{
    public class ChatRoomEventControllerTests : IClassFixture<PowerDiaryWebApplicationFactory<Program>>
    {
        private readonly PowerDiaryWebApplicationFactory<Program> _factory;
        public ChatRoomEventControllerTests(PowerDiaryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetChatRoomEventsByMinutes_Returns_SuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var date = JsonConvert.SerializeObject(DateTime.Now.Date);

            var response = await client.GetAsync($"getChatRoomEventsByMinutes?date=2024-01-01%2005%3A00%3A00.0000000");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ChatRoomEventMinutesVm>>(responseString);

            result.Should().BeOfType<List<ChatRoomEventMinutesVm>>();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetChatRoomEventsByHours_Returns_SuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("getChatRoomEventsByHours?date=2024-01-01%2005%3A00%3A00.0000000");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ChatRoomEventHoursVm>>(responseString);

            result.Should().BeOfType<List<ChatRoomEventHoursVm>>();
            result.Should().NotBeEmpty();
        }

    }
}
