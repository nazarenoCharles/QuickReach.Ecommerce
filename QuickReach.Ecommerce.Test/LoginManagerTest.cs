using System;
using Xunit;


namespace QuickReach.Ecommerce.Test
{
    public class LoginManagerTest
    {
        [Theory]
        //[InlineData("cnazareno@gmail.com", false)]
        //[InlineData("cnazareno@blastasia.com",false)]
        //[InlineData("notemail@asdasd.com",false)]
        [InlineData("notEmail@asdasd.comcom", false)]
        [InlineData("notEmail@asdasd..com", false)]
       // [InlineData("notEmail@asdasd.com", false)]
        [InlineData("", false)]
        public void Validate_WithInvalidUsername_ShouldFail(string username, bool expected)
        {
            var sut = new LoginManager();
            var actual = sut.ValidateUsername(username);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("cnazareno@gmail.com", true)]
        [InlineData("cnazareno@blastasia.com", true)]
        [InlineData("notemail@asdasd.com", true)]
        public void Validate_WithInvalidUsername_ShouldPass(string username, bool expected)
        {
            var sut = new LoginManager();
            var actual = sut.ValidateUsername(username);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("Nals", false)]
        [InlineData("", false)]
       // [InlineData("Bl@st123", false)]
        [InlineData("Blast123", false)]
        [InlineData("falsedata", false)]
        [InlineData("thisdata", false)]
        
        public void Validate_WithInvalidPassword_ShouldFail(string password, bool expected)
        {
            var sut = new LoginManager();
            var actual = sut.ValidatePassword(password);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("Bl@st123", true)]
        [InlineData("P@ssword123", true)]
        [InlineData("MyP@ssis123", true)]
        //[InlineData("falsedata", true)]
        public void Validate_WithValidPassword_ShouldWork(string password, bool expected)
        {
            var sut = new LoginManager();
            

            var actual = sut.ValidatePassword(password);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Validate_WithValidUsernameAndPassword()
        {
            var sut = new LoginManager();
            var username = "cnazareno@blastasia.com";
            var password = "Bl@st123";
            var expected = true;

            var actual = sut.Validate(username, password);

            Assert.Equal(expected, actual);
        }
    }
}
