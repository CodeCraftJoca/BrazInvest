using Infrastructure.Db.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using models;
using Moq;
using Services.Data;
using System;

namespace YourNamespace.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void AddUser_ValidData_ReturnsUser()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = userService.AddUser("john_doe", "Password123", "john@example.com");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("john_doe", result.UserName);
            // Add more assertions as needed based on the expected behavior of your application
        }

        [TestMethod]
        public void AddUser_InvalidEmail_ThrowsArgumentException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
                userService.AddUser("john_doe", "Password123", "invalid-email")
            );
        }

        // Add more test methods to cover different scenarios, such as invalid passwords, usernames, etc.
    }
}
