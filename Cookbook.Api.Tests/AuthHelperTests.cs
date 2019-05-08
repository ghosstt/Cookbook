using Cookbook.Api.Helpers;
using System;
using Xunit;

namespace Cookbook.Api.Tests
{
    public class AuthHelperTests
    {
        [Fact]
        public void VerifyPasswordHash_ShouldVerify()
        {
            // Arrange
            string password = "pass1234";

            // Act
            AuthHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            bool verified = AuthHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);

            // Assert
            Assert.True(verified);
        }
    }
}
