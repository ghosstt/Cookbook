using Cookbook.Api.Features.Auth.Controllers;
using Cookbook.Api.Features.Auth.Dto;
using Cookbook.Api.Features.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cookbook.Api.Tests
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Login_ShouldReturnLoginResult()
        {
            // Arrange
            var loginDto = new LoginDto()
            {
                UserName = "",
                Password = ""
            };

            var expected = new LoginResult()
            {
                Token = string.Empty
            };

            var mockMediator = new Mock<IMediator>();

            mockMediator
                .Setup(m => m.Send(It.IsAny<Login>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected)
                .Verifiable("Not sent");

            // mockMediator.Verify(m => m.Send(It.IsAny<Login>(), It.IsAny<CancellationToken>()), Times.Once());

            var controller = new AuthController(mockMediator.Object);

            // Act
            var loginResult = await controller.Login(loginDto);

            // Assert
            var result = Assert.IsType<OkObjectResult>(loginResult);
            var result2 = Assert.IsType<LoginResult>(result.Value);
            Assert.Equal(expected, result2);
        }
    }
}
