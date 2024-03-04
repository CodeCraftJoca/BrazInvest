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
        public void AddUser_InvalidEmail_ThrowsArgumentException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                userService.AddUser("john_doe", "Password123", "invalid-email");
            }, "Email does not meet the requirements, please check and try again");
        }

        [TestMethod]
        public void AddUser_InvalidPassword_ThrowsArgumentException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                userService.AddUser("john_doe", "123", "john@example.com");
            }, "Password does not meet the requirements, please check and try again");
        }

        [TestMethod]
        public void AddUser_InvalidUsername_ThrowsArgumentException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                userService.AddUser("123", "Password123", "john@example.com");
            }, "User does not meet the requirements, please check and try again");
        }

    }
}
