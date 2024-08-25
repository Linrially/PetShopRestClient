using System.Net;
using PetShopQa.Clients;
using PetShopQa.Messages;
using PetShopQa.Models;
using Shouldly;

namespace PetShopQa.Tests.XUnitTests
{
    public class Setup : IDisposable
    {
        public User User = User.Create();
        
        public Setup()
        {
            var createUserResponse = UserClient.UserCreate(User).Result;
            
            createUserResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
            
            var loginRequest = LoginUserRequest.Create(User.Username, User.Password);
            var loginResponse =  UserClient.UserLogin(loginRequest).Result;
            
            loginResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }

        public void Dispose()
        {
            var logoutResponse = UserClient.UserLogout().Result;
            
            logoutResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
    }
}