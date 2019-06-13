using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace QuickReach.Ecommerce.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void Register_WithValidUser_CallRepositorySave()
        {
            //Arrange
            var mockuserRepository = new Mock<IUserRepository>();
            var mockLoginManager = new Mock<ILoginManager>();
            mockLoginManager.Setup((l) => l.ValidateUsername(It.IsAny<string>()) && l.ValidatePassword(It.IsAny<string>())).Returns(true);
            

            var mockUserRepository = new Mock<IUserRepository>();
            var sut = new UserService(mockLoginManager.Object, mockUserRepository.Object);

            var user = new User
            {
                Username = "cnazareno@blastasia.com",
                Password = "Bl@st123"
            };
            //Act
            sut.RegisterUser(user);
            //Assert
            mockUserRepository.Verify((r) => r.Save(user), Times.Once);
        }
        [Fact]
        public void RegisterUser_WithInvalidPassword_ThrowsInvalidException()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockLoginManager = new Mock<ILoginManager>();
            mockLoginManager.Setup((l) => l.ValidateUsername(It.IsAny<string>()) && l.ValidatePassword(It.IsAny<string>())).Throws<InvalidFormatPasswordException>();
            var user = new User
            {
                Username = "cnazareno@blastasia.com",
                Password = "Bl@st123"
            };
            var sut = new UserService(mockLoginManager.Object, mockUserRepository.Object);
            Assert.Throws<InvalidFormatPasswordException>(() => sut.RegisterUser(user));
            mockUserRepository.Verify((r) => r.Save(user), Times.Never);
        }
    }

}
