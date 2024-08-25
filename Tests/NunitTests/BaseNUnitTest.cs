using System.Net;
using PetShopQa.Clients;
using PetShopQa.Messages;
using PetShopQa.Models;
using Shouldly;

namespace PetShopQa.Tests.NunitTests
{
    [TestFixture]
    public class BaseNUnitTest
    {
        protected User User;

        [SetUp]
        public async Task CreateSettings()
        {
            User = User.Create();
            var createUserResponse = await UserClient.UserCreate(User);
            
            createUserResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
            
            var loginRequest = LoginUserRequest.Create(User.Username, User.Password);
            var loginResponse = await UserClient.UserLogin(loginRequest);
            
            loginResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }

        [TearDown]
        public async Task DeleteSettings()
        {
            var logoutResponse = await UserClient.UserLogout();
            
            logoutResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
    }
}